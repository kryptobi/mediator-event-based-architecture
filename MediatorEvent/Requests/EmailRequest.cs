namespace MediatorEvent.Requests;

public class EmailRequest(string message)
{
    public string Message { get; set; } = message;
}