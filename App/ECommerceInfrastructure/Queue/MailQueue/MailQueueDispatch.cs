using ECommerceMail.Contract;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ECommerceInfrastructure.Queue.MailQueue;

public sealed class MailQueueDispatch(
    IServiceProvider serviceProvider,
    ILogger<MailQueueDispatch> logger) : BackgroundService
{
    readonly IServiceProvider _serviceProvider = serviceProvider;

    readonly ILogger _logger = logger;

    protected override async Task ExecuteAsync(CancellationToken token)
    {
        while (token.IsCancellationRequested is false)
        {
            using var scope = _serviceProvider.CreateScope();

            var _mailService = scope.ServiceProvider.GetRequiredService<IMailService>();

            await SendQueueAsync(_mailService, token);

            await Task.Delay(TimeSpan.FromMinutes(1), token);
        }
    }

    private async Task SendQueueAsync(
        IMailService _mailService,
        CancellationToken cancellationToken)
    {
        if (MailQueueHandler.HasTemplate())
        {
            var templates = MailQueueHandler.GetRangeTemplate(60);

            foreach (var template in templates)
            {
                await _mailService.SendTemplateAsync(template, cancellationToken);
            }

            _logger.LogInformation(
                ">> Emails that were added to the queue and sent successfully - {take}, {time}",
                templates.Count, DateTimeOffset.Now);
        }
    }
}
