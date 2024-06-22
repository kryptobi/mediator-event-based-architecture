namespace MediatorEvent.Interfaces;

public interface IMediator
{
    void Register<TRequest, THandler>()
        where THandler : IRequestHandler<TRequest>, new();

    void Send<TRequest>(TRequest request);
}