namespace Dukaan.Application.Dtos; 

public record MerchantLoginRequest
(
    string Email,
    string Password

); 

public record LoginRequestDTO(
    string Email,
    string Password
);

public record AuthResponseDTO(
    string Token,
    DateTime Expiration
);