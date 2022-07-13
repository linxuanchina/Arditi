namespace Arditi.Application.Accounts;

public sealed record CheckResponse
{
    public int Id { get; set; }

    public string Nickname { get; set; } = null!;
}

public sealed record CheckRequest : IItemRequest<CheckResponse>
{
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
}

public sealed class CheckHandler : ItemRequestHandler<CheckRequest, CheckResponse>
{
    protected override Task<CheckResponse> InnerHandle(CheckRequest request, CancellationToken cancellationToken)
    {
        return Task.FromResult(new CheckResponse { Id = 1, Nickname = "Jack" });
    }
}
