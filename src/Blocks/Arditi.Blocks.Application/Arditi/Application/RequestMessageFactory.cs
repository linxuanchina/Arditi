namespace Arditi.Application;

public interface IRequestMessageFactory<in TRequest, in TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : Response
{
    IMessage CreateMessage(TRequest request, TResponse response);
}
