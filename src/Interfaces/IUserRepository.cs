using cmsapplication.src.Models;
using cmsapplication.src.Models.Create;
using cmsapplication.src.Models.Read;
using cmsapplication.src.Models.Update;
using Microsoft.AspNetCore.Mvc;

namespace cmsapplication.src.Interfaces;
public interface IUserRepository
{
    Task<User> GetUserById(Guid id);
    Task<List<UserReadModel>> GetAllUsers([FromQuery] int page, [FromQuery] int size);
    Task<string> CreateNewUser(UserCreateModel newUser);
    void UpdateUserById(User currentUser, UserUpdateModel newUser);
    void DeleteUserById(User user);
    Task<bool> DoesEmailOrUsernameExist (string email, string userName);
    Task SaveChangesAsync();
}
