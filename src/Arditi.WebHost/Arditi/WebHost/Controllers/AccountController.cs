using Microsoft.AspNetCore.Mvc;

namespace Arditi.WebHost.Controllers;

[Route("account")]
public sealed class AccountController : JsonController
{
    [HttpPost("token")]
    public IActionResult Token()
    {
        return Ok("dfsds");
    }
}
