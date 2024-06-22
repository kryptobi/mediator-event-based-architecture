# Mediator Pattern Example

This repository contains a simple implementation of the Mediator Pattern in C#. The Mediator Pattern is used to reduce the complexity of communication between multiple objects or components. Instead of having objects refer to each other directly, they communicate through a mediator. This approach helps to decouple the components, making the system more modular and easier to maintain.

## Getting Started

To run this example, you need:

- .NET Core SDK installed on your machine.
- A code editor like Visual Studio or JetBrains Rider.

## Project Structure

The project is structured as follows:

- IMediator.cs: Defines the mediator interface.
- IRequestHandler.cs: Defines the request handler interface.
- ConcreteMediator.cs: Implements the mediator interface and manages the communication between components.
- EmailRequest.cs and NotificationRequest.cs: Define request types.
- EmailRequestHandler.cs and NotificationRequestHandler.cs: Implement request handlers for the respective request types.
- Program.cs: Contains the client code to demonstrate the usage of the mediator.

## Implementing Components

### Mediator Interface

Defines methods to register handlers and send requests.

```csharp
public interface IMediator
{
    void Register<TRequest, THandler>()
        where THandler : IRequestHandler<TRequest>, new();

    void Send<TRequest>(TRequest request);
}
```

### RequestHandler Interface

Defines a handler interface for processing requests.

```csharp
public interface IRequestHandler<TRequest>
{
    void Handle(TRequest request);
}
```

### Concrete Mediator

Implements the mediator interface and manages the communication between registered handlers.

```csharp
using System;
using System.Collections.Generic;

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
        if (_handlers.TryGetValue(request.GetType(), out var handlerType))
        {
            var handler = Activator.CreateInstance(handlerType) as IRequestHandler<TRequest>;
            handler?.Handle(request);
        }
    }
}
```

### Requests

Define simple request types with a Message property.

```csharp
public class EmailRequest
{
    public string Message { get; set; }

    public EmailRequest(string message)
    {
        Message = message;
    }
}

public class NotificationRequest
{
    public string Message { get; set; }

    public NotificationRequest(string message)
    {
        Message = message;
    }
}
```

### Handlers

Implement the IRequestHandler interface for specific request types.

```csharp
public class EmailRequestHandler : IRequestHandler<EmailRequest>
{
    public void Handle(EmailRequest request)
    {
        Console.WriteLine($"Handling EmailRequest: {request.Message}");
        // Simulate sending an email
        Console.WriteLine("Email sent successfully.");
    }
}

public class NotificationRequestHandler : IRequestHandler<NotificationRequest>
{
    public void Handle(NotificationRequest request)
    {
        Console.WriteLine($"Handling NotificationRequest: {request.Message}");
        // Simulate sending a notification
        Console.WriteLine("Notification sent successfully.");
    }
}
```

### Using the ConcreteMediator

- Register Handlers: Register the request handlers with the mediator.
- Send Requests: Send requests through the mediator.

```csharp
class Program
{
    static void Main(string[] args)
    {
        var mediator = new ConcreteMediator();

        // Register handlers
        mediator.Register<EmailRequest, EmailRequestHandler>();
        mediator.Register<NotificationRequest, NotificationRequestHandler>();

        // Send requests
        mediator.Send(new EmailRequest("Hello, this is an email!"));
        mediator.Send(new NotificationRequest("Hello, this is a notification!"));
    }
}
```

## Conclusion

The Mediator Pattern is a behavioral design pattern that helps to reduce the complexity and dependencies between multiple objects. By introducing a mediator object, objects no longer need to refer to each other directly, promoting loose coupling and enhancing code maintainability and readability.

When to use the Mediator Pattern:

- When the communication logic between multiple objects is complex.
- When you want to reduce the dependencies between interacting objects.
- When you need to centralize the control over how objects interact.
- By using the Mediator Pattern, you can create more modular and maintainable systems, making it easier to manage and extend the functionality without tightly coupling the components.
