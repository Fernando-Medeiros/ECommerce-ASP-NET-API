namespace ECommerce.Exceptions;

public class ExceptionResponse
{
    public string Message { get; set; }
    public int Status { get; set; }
    public DateTime CreatedAt { get; set; }

    public ExceptionResponse(string message, int status)
    {
        Message = message;
        Status = status;
        CreatedAt = DateTime.UtcNow;
    }
}
