using ECommerceMailService.Contracts;

namespace ECommerceInfrastructure.Queue.MailQueue;

public sealed class MailQueueDispatch : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;

    private readonly ILogger _logger;

    public MailQueueDispatch(
        IServiceProvider serviceProvider,
        ILogger<MailQueueDispatch> logger)
    {
        _serviceProvider = serviceProvider;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            using var scope = _serviceProvider.CreateScope();

            var _mailService = scope.ServiceProvider.GetRequiredService<IMailService>();

            await SendQueueAsync(_mailService, stoppingToken);

            await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
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
