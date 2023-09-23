using cmsapplication.src.Models;

namespace cmsapplication.src.Interfaces;

public interface ITokenRepository
{
    string GenerateToken();
    bool ValidateToken(string Token);
}