namespace MediatorEvent.Interfaces;

public interface IRequestHandler<in TRequest>
{
    void Handle(TRequest request);
}