using Arditi.Application.Users;
using Arditi.Application;
using Microsoft.AspNetCore.Mvc;

namespace Arditi.WebHost.Controllers;

[Route("user")]
public sealed class UserController : JsonController
{
    private readonly IRequestSender _requestSender;

    public UserController(IRequestSender requestSender)
    {
        _requestSender = requestSender;
    }

    [HttpPost("/add-admin")]
    public async Task<IActionResult> AddAdminUser(AddAdminUserRequest request) =>
        Ok(await _requestSender.Send(request));
}
