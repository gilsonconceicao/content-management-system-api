namespace cmsapplication.src.Models.Read;

public interface AuthenticatedUserModel
{
    string Token { get; set;  }
    bool IsAuthenticated { get; set;  }
}
