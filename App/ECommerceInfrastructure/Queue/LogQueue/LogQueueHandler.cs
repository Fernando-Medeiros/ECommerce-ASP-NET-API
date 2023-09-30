using ECommerceInfrastructure.Persistence.Models;

namespace ECommerceInfrastructure.Queue.LogQueue;

public static class LogQueueHandler
{
    static readonly List<LogRequest> QueueRequest = new();

    static readonly List<LogResponse> QueueResponse = new();

    #region Request

    public static bool HasLogRequest() => QueueRequest.Count > 0;

    public static void InsertRequest(LogRequest item) => QueueRequest.Add(item);

    public static List<LogRequest> GetRangeLogRequest(int take = 15)
    {
        int limit = Math.Min(take, QueueRequest.Count);

        var loggers = QueueRequest.GetRange(0, limit);
        QueueRequest.RemoveRange(0, limit);
        return loggers;
    }
    #endregion


    #region Response

    public static bool HasLogResponse() => QueueResponse.Count > 0;

    public static void InsertResponse(LogResponse item) => QueueResponse.Add(item);

    public static List<LogResponse> GetRangeLogResponse(int take = 15)
    {
        int limit = Math.Min(take, QueueResponse.Count);

        var loggers = QueueResponse.GetRange(0, limit);
        QueueResponse.RemoveRange(0, limit);
        return loggers;
    }
    #endregion
}
