using cmsapplication.src.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace cmsapplication.src.Repositories;

public class TokenServices
{
    public string encoded_key = Settings.Settings.Secret;
    public IConfiguration _configuration;

    public TokenServices(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string GenerateToken(Person user)
    {
        var secret = Convert.FromBase64String(encoded_key);
        if (secret.Length < 32)
        {
            throw new ArgumentException("ERROR: Use a key of at least 32 bytes (256 bits) for HS256.");
        }
        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[] {
                new Claim("Password", user.Password),
                new Claim("Email", user.Email)
            }),
            Expires = DateTime.UtcNow.AddMinutes(7),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secret), SecurityAlgorithms.HmacSha256)
        };
        var sectoken = tokenHandler.CreateToken(tokenDescriptor);
        var stringtoken = tokenHandler.WriteToken(sectoken);
        return stringtoken;
    }

    public bool ValidateToken(string token)
    {
        var mySecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(encoded_key));

        var tokenHandller = new JwtSecurityTokenHandler();
        try
        {
            tokenHandller.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                ValidateIssuer = true,
                ValidateAudience = true,
                IssuerSigningKey = mySecurityKey
            }, out SecurityToken validatedToken);
        }
        catch
        {
            return false;
        }
        return true;
    }
}
