using MediatorEvent.Requests;

namespace MediatorEvent.RequestHandler;

public class EmailRequestHandler : IRequestHandler<EmailRequest>
{
    public void Handle(EmailRequest request)
    {
        Console.WriteLine($"Handling EmailRequest: {request.Message}");
    }
}