namespace Arditi.Application;

public interface IRequestMessageFactory<in TRequest, in TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : Response
{
    IMessage Create(TRequest request, TResponse response);
}
