using Electronic_Store_Api.DataModels;
using Electronic_Store_Api.Entities;
using Electronic_Store_Api.ViewModels;

namespace Electronic_Store_Api.Services
{
    public interface ILoginService
    {
        User EsUsersLogin(Login login, out int status, out string message); 
    }
}
