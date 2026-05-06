
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Dukaan.Application.Dtos;
using Dukaan.Domain.Entities;
using Dukaan.Infrastructure.Services;
using Dukaan.Infrastructure.Data.Model;
using Dukaan.Infrastructure.Data.Repositories; 
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

public class AutheService : IAuthService
{
    
    private readonly IConfiguration _config; 
    
    private readonly Repository<Tenant> _tenantRepository;
    private readonly UserManager<Merchant> _userManager;

     public AutheService(IConfiguration config, Repository<Tenant> tenantRepository,
     UserManager<Merchant> userManager )
    {
        _config=config; 
        _tenantRepository=tenantRepository;
        _userManager=userManager; 
    }

    public async Task<AuthResponseDTO> LoginAsync(LoginRequestDTO request)
    {
       var user = await _userManager.FindByEmailAsync(request.Email);

        if (user == null)
            throw new UnauthorizedAccessException("Invalid credentials");

        var isValid = await _userManager.CheckPasswordAsync(user, request.Password);

        if (!isValid)
            throw new UnauthorizedAccessException("Invalid credentials");

        
        var token=GenerateToken(user); 

        return new AuthResponseDTO(
                token,
                DateTime.UtcNow.AddHours(1)
            );
    }
    public string GenerateToken(Merchant merchant)
    {
        var secretKey = _config["Jwt:Key"];
        var keybyte=Encoding.UTF8.GetBytes(secretKey); 
        var key= new SymmetricSecurityKey(keybyte); 
        var credential= new SigningCredentials(key, SecurityAlgorithms.HmacSha256); 

        var claims = new Claim[]
        {
            new Claim("merchantid", merchant.Id.ToString()),
            new Claim("email", merchant.Email),
            new Claim("tenantid", merchant.TenantId.ToString())
        };

        var descriptor=new SecurityTokenDescriptor
        {
             Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddHours(1),
            SigningCredentials = credential

        };
        var tokenHandler= new JwtSecurityTokenHandler(); 
        var token=tokenHandler.CreateToken(descriptor);
        return tokenHandler.WriteToken(token); 
    }
}
