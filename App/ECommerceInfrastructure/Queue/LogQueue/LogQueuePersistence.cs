using ECommercePersistence.Contexts;

namespace ECommerceInfrastructure.Queue.LogQueue;

public sealed class LogQueuePersistence : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;

    private readonly ILogger _logger;

    public LogQueuePersistence(
        IServiceProvider serviceProvider,
        ILogger<LogQueuePersistence> logger)
    {
        _serviceProvider = serviceProvider;
        _logger = logger;
    }

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
        if (LogQueueHandler.HasLogRequest())
        {
            var logs = LogQueueHandler.GetRangeLogRequest(60);

            ctx.LogRequests.AddRange(logs);

            _logger.LogInformation(
                ">> LogRequests added to the queue to be saved - {take}, {time}",
                logs.Count, DateTimeOffset.Now);
        }

        if (LogQueueHandler.HasLogResponse())
        {
            var logs = LogQueueHandler.GetRangeLogResponse(60);

            ctx.LogResponses.AddRange(logs);

            _logger.LogInformation(
                ">> LogResponses added to the queue to be saved - {take}, {time}",
                logs.Count, DateTimeOffset.Now);
        }
    }
}
