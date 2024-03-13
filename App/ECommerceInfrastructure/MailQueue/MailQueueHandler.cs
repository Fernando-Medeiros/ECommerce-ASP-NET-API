using ECommerceMail.Service;

namespace ECommerceInfrastructure.MailQueue;

public static class MailQueueHandler
{
    private static readonly List<MailTemplate> QueueTemplate = [];

    public static bool HasTemplate() => QueueTemplate.Count != 0;

    public static void InsertTemplate(MailTemplate item) => QueueTemplate.Add(item);

    public static List<MailTemplate> GetRangeTemplate(int take = 15)
    {
        int limit = Math.Min(take, QueueTemplate.Count);

        var templates = QueueTemplate.GetRange(0, limit);
        QueueTemplate.RemoveRange(0, limit);
        return templates;
    }
}
