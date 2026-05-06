using System.Security.Cryptography;
using Dukaan.Infrastructure.Data.Model;
using System.IdentityModel.Tokens;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Dukaan.Application.Dtos;


namespace Dukaan.Infrastructure.Services; 

public interface IAuthService
{
    Task<AuthResponseDTO> LoginAsync(LoginRequestDTO request);
}