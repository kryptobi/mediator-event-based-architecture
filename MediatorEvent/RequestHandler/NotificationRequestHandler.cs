using MediatorEvent.Requests;

namespace MediatorEvent.RequestHandler;

public class NotificationRequestHandler : IRequestHandler<NotificationRequest>
{
    public void Handle(NotificationRequest request)
    {
        Console.WriteLine($"Handling NotificationRequest: {request.Message}");
    }
}