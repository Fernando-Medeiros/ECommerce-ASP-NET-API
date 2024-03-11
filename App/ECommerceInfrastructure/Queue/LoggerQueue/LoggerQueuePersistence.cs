using ECommercePersistence.Context;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ECommerceInfrastructure.Queue.LoggerQueue;

public sealed class LoggerQueuePersistence(
    IServiceProvider serviceProvider,
    ILogger<LoggerQueuePersistence> logger) : BackgroundService
{
    readonly IServiceProvider _serviceProvider = serviceProvider;

    readonly ILogger _logger = logger;

    protected override async Task ExecuteAsync(CancellationToken token)
    {
        while (token.IsCancellationRequested is false)
        {
            using var scope = _serviceProvider.CreateScope();

            var context = scope.ServiceProvider.GetRequiredService<LoggerContext>();

            InsertLogs(context);

            await context.SaveChangesAsync(token);

            await Task.Delay(TimeSpan.FromMinutes(1), token);
        }
    }

    private void InsertLogs(LoggerContext ctx)
    {
        if (LoggerQueueHandler.HasLogRequest())
        {
            var logs = LoggerQueueHandler.GetRangeLogRequest(60);

            ctx.LogRequests.AddRange(logs);

            _logger.LogInformation(
                ">> LogRequests added to the queue to be saved - {take}, {time}",
                logs.Count, DateTimeOffset.Now);
        }

        if (LoggerQueueHandler.HasLogResponse())
        {
            var logs = LoggerQueueHandler.GetRangeLogResponse(60);

            ctx.LogResponses.AddRange(logs);

            _logger.LogInformation(
                ">> LogResponses added to the queue to be saved - {take}, {time}",
                logs.Count, DateTimeOffset.Now);
        }
    }
}
