namespace MediatorEvent;

public class ConcreteMediator : IMediator
{
    private readonly Dictionary<Type, Type> _handlers = new();

    public void Register<TRequest, THandler>()
        where THandler : IRequestHandler<TRequest>, new()
    {
        _handlers[typeof(TRequest)] = typeof(THandler);
    }

    public void Send<TRequest>(TRequest request)
    {
        if (request is null)
            return;

        if (!_handlers.TryGetValue(request.GetType(), out var handlerType))
            return;
        
        var handler = Activator.CreateInstance(handlerType) as IRequestHandler<TRequest>;
        handler?.Handle(request);
    }
}