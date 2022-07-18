namespace Arditi.Application;

public interface IRequestSender
{
    Task<TResponse> Send<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default)
        where TResponse : Response;
}

public sealed class RequestSender : IRequestSender
{
    private readonly MediatR.ISender _sender;

    public RequestSender(MediatR.ISender sender)
    {
        _sender = sender;
    }

    public Task<TResponse> Send<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default)
        where TResponse : Response
        => _sender.Send(request, cancellationToken);
}
