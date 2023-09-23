using AutoMapper;
using cmsapplication.src.Contexts;
using cmsapplication.src.Interfaces;
using cmsapplication.src.Models;
using cmsapplication.src.Models.Create;
using cmsapplication.src.Models.Read;
using cmsapplication.src.Models.Update;
using Microsoft.EntityFrameworkCore;

namespace cmsapplication.src.Repositories;
public class UserRepository  : IUserRepository
{
    private readonly DataBaseContext _context;
    public IMapper _mapper; 

    public UserRepository(DataBaseContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper; 
    }

    public async Task<string> CreateNewUser(UserCreateModel user)
    {
        User newUser = _mapper.Map<User>(user);
        await _context.AddAsync(newUser);
        return newUser.Id.ToString(); 
    }

    public void UpdateUserById(User currentUser, UserUpdateModel updateData)
    {
        currentUser.Email = updateData.Email;
        currentUser.PhoneNumber = updateData.PhoneNumber;
        currentUser.Name = updateData.Name;
    }

    public void DeleteUserById(User user)
    {
        _context.Remove(user);
    }

    public async Task<List<UserReadModel>> GetAllUsers()
    {
        List<User> users = await _context.users.ToListAsync(); 
        return _mapper.Map<List<User>, List<UserReadModel>>(users);
    }

    public async Task<User> GetUserById(Guid id)
    {
        return await _context.users.FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task<bool> DoesEmailOrUsernameExist(string email, string userName)
    {
        User findUser = await _context.users.FirstOrDefaultAsync(u => u.Email == email || u.UserName == userName);

        if (findUser != null)
        {
            return true;
        }
        return false;
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}
