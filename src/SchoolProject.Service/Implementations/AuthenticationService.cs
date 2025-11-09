using System.IdentityModel.Tokens.Jwt;
using System.Security;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SchoolProject.Domain.Entities.Identity;
using SchoolProject.Domain.Helpers;
using SchoolProject.Infrastructure.Abstractions;
using SchoolProject.Service.Abstractions;

namespace SchoolProject.Service.Implementations;

public class AuthenticationService(JwtSettings jwtSetting,
                                   IRefreshTokenRepository refreshTokenRepository,
                                   UserManager<User> userManager) : IAuthenticationService
{
    private readonly JwtSettings _jwtSettings = jwtSetting;
    private readonly IRefreshTokenRepository _refreshTokenRepository = refreshTokenRepository;
    private readonly UserManager<User> _userManager = userManager;

    public async Task<JwtResponse> GenerateToken(User user)
    {
        var Token = GenerateJwtToken(user);
        var RefreshToken = new RefreshToken
        {
            UserName = user.UserName!,
            ExpireAt = DateTime.UtcNow.AddDays(_jwtSettings.RefreshTokenExpiredInDays),
            TokenStr = GenerateRefreshToken()
        };

        var UserRefreshToken = new UserRefreshToken
        {
            Id = Guid.NewGuid(),
            AccessToken = Token,
            CreateAt = DateTime.UtcNow,
            ExpiryDate = RefreshToken.ExpireAt,
            RefreshToken = RefreshToken.TokenStr,
            UserId = user.Id
        };
        await _refreshTokenRepository.AddAsync(UserRefreshToken);
        return new JwtResponse
        {
            AccessToken = Token,
            RefreshToken = RefreshToken
        };
    }

    public async Task<JwtResponse> RefreshToken(string AccessToken, string RefreshToken)
    {
        var jwtToken = ReadToken(AccessToken);
        if (jwtToken is null || !jwtToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256))
            throw new SecurityException("InvalidToken");

        if (jwtToken.ValidTo > DateTime.UtcNow)
            throw new SecurityException("Token not expired");

        var userId = jwtToken.Claims.FirstOrDefault(u => u.Type == "Sub")!.Value;
        var userRefreshToken = await _refreshTokenRepository.GetTableNoTracking()
                                                .FirstOrDefaultAsync(t => t.AccessToken == AccessToken &&
                                                                          t.RefreshToken == RefreshToken &&
                                                                          t.UserId == userId) ?? throw new SecurityException("Invalid Token");
        if(userRefreshToken.ExpiryDate < DateTime.UtcNow)
            throw new SecurityException("Refresh Token is expired");

        var user = await _userManager.FindByIdAsync(userId) ?? throw new SecurityException("User not found");
        var Token = GenerateJwtToken(user);

        userRefreshToken.AccessToken = Token;
        await _refreshTokenRepository.UpdateAsync(userRefreshToken);
        return new JwtResponse
        {
            AccessToken = Token,
            RefreshToken = new()
            {
                UserName = user.UserName!,
                ExpireAt = userRefreshToken.ExpiryDate,
                TokenStr = RefreshToken
            }
        };
    }

    private JwtSecurityToken ReadToken(string Token)
    {
        var handler = new JwtSecurityTokenHandler();
        return handler.ReadJwtToken(Token);
    }

    public async Task<bool> ValidateToken(string AccessToken)
    {
        var handler = new JwtSecurityTokenHandler();
        var Parameters = new TokenValidationParameters()
        {
            ValidateIssuer = _jwtSettings.ValidateIssuer,
            ValidIssuer = _jwtSettings.Issuer,
            ValidateIssuerSigningKey = _jwtSettings.ValidateIssuerSigningKey,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret)),
            ValidAudience = _jwtSettings.Audience,
            ValidateAudience = _jwtSettings.ValidateAudience,
            ValidateLifetime = _jwtSettings.ValidateLifetime,
            ClockSkew = TimeSpan.Zero
        };
        var validToken = await handler.ValidateTokenAsync(AccessToken, Parameters);

        return validToken.IsValid;
    }

    private string GenerateRefreshToken()
    {
        var randomNumber = new byte[64];
        var randomGenerate = RandomNumberGenerator.Create();
        randomGenerate.GetBytes(randomNumber);
        return Convert.ToBase64String(randomNumber);
    }

    private string GenerateJwtToken(User user)
    {
        var Claims = new List<Claim>
        {
            new ("Sub", user.Id),
            new ("UserName", user.UserName!),
            new ("Email", user.Email!),
        };
        var jwtToken = new JwtSecurityToken(_jwtSettings.Issuer, _jwtSettings.Audience, Claims, null, DateTime.UtcNow.AddMinutes(_jwtSettings.TokenExpiredInMinutes),
                        new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret)), SecurityAlgorithms.HmacSha256));
        var Token = new JwtSecurityTokenHandler().WriteToken(jwtToken);
        return Token;
    }

}