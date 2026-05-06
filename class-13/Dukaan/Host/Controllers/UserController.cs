using Dukaan.Application.Dtos;
using Dukaan.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
namespace Dukaan.Host.Controllers;

[ApiController]
[Route("/api/auth")]
public class UserLoginController : ControllerBase
{
  
  private readonly IAuthService _authenticaiton;

  public UserLoginController(IAuthService authenticaiton)
  {
        _authenticaiton=authenticaiton;
  }

  [HttpPost("login")] 
  public async Task<IActionResult> UserLogin(LoginRequestDTO request)
    {
        var response= await _authenticaiton.LoginAsync(request); 
        return Ok(response); 
    }
}