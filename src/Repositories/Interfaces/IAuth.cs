using cmsapplication.src.Models.Create;
using cmsapplication.src.Models.Read;

namespace cmsapplication.src.Repositories.Interfaces;

public interface IAuth
{ 
    bool CheckUserExists(string Email); 
    AuthCreateModel GetPersonByEmailAndPassword(AuthCreateModel person);
    string Login(AuthCreateModel person);
}