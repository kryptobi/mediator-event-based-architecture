namespace MediatorEvent.Requests;

public class NotificationRequest(string message)
{
    public string Message { get; set; } = message;
}