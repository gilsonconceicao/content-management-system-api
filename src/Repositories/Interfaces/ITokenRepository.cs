using cmsapplication.src.Models;

namespace cmsapplication.src.Repositories.Interfaces;

public interface ITokenRepository
{
    string GenerateToken(Person person);
}