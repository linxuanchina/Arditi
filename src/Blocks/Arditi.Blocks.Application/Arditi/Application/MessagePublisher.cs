namespace Arditi.Application;

public interface IMessagePublisher
{
    Task Publish<TMessage>(TMessage message, CancellationToken cancellationToken = default) where TMessage : IMessage;
}

public sealed class MessagePublisher : IMessagePublisher
{
    private readonly MediatR.IPublisher _publisher;

    public MessagePublisher(MediatR.IPublisher publisher)
    {
        _publisher = publisher;
    }

    public Task Publish<TMessage>(TMessage message, CancellationToken cancellationToken = default)
        where TMessage : IMessage =>
        _publisher.Publish(message, cancellationToken);
}
