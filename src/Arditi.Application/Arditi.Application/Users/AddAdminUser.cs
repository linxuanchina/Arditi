using FluentValidation;
using PasswordGenerator;

namespace Arditi.Application.Users;

public sealed record AddAdminUserResponse
{
    public string Password { get; set; } = null!;
}

public sealed record AddAdminUserRequest : IItemRequest<AddAdminUserResponse>
{
    public string Username { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public string? EmailAddress { get; set; }

    public Gender? Gender { get; set; }
}

public sealed class AddAdminUserRequestValidator : AbstractValidator<AddAdminUserRequest>
{
    public AddAdminUserRequestValidator()
    {
        RuleFor(request => request.Username).NotEmpty().Length(5, 20);
        RuleFor(request => request.PhoneNumber).PhoneNumber();
        RuleFor(request => request.EmailAddress).EmailAddress();
    }
}

public sealed class AddAdminUserHandler : ItemRequestHandler<AddAdminUserRequest, AddAdminUserResponse>
{
    protected override Task<AddAdminUserResponse> InnerHandle(AddAdminUserRequest request,
        CancellationToken cancellationToken)
    {
        var pwdGen = new Password(true, false, true, true, 16);
        var response = new AddAdminUserResponse { Password = pwdGen.Next() };
        //var response = new AddAdminUserResponse();
        return Task.FromResult(response);
    }
}
