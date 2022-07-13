namespace Arditi.Application;

public interface IMessageHandler<in TMessage> : MediatR.INotificationHandler<TMessage> where TMessage : IMessage
{
}

public abstract class MessageHandler<TMessage> : IMessageHandler<TMessage> where TMessage : IMessage
{
    public abstract Task Handle(TMessage message, CancellationToken cancellationToken);
}
