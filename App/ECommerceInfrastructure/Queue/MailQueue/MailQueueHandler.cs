using ECommerceMail.Contract;

namespace ECommerceInfrastructure.Queue.MailQueue;

public static class MailQueueHandler
{
    private static readonly List<BaseTemplate> QueueTemplate = new();

    public static bool HasTemplate() => QueueTemplate.Any();

    public static void InsertTemplate(BaseTemplate item) => QueueTemplate.Add(item);

    public static List<BaseTemplate> GetRangeTemplate(int take = 15)
    {
        int limit = Math.Min(take, QueueTemplate.Count);

        var templates = QueueTemplate.GetRange(0, limit);
        QueueTemplate.RemoveRange(0, limit);
        return templates;
    }
}
