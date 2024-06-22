using MediatorEvent.Requests;

var mediator = new ConcreteMediator();

// Register handlers
mediator.Register<EmailRequest, EmailRequestHandler>();
mediator.Register<NotificationRequest, NotificationRequestHandler>();

// Send requests
mediator.Send(new EmailRequest("Hello, this is an email!"));
mediator.Send(new NotificationRequest("Hello, this is a notification!"));