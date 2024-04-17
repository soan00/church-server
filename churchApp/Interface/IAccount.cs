using churchApp.Models;
using churchApp.Models.Tables;

namespace churchApp.Interface
{
    public interface IAccount
    {
        Task<UserTables> Login(LoginModel model);
        Task<bool> Signup(UserTables model);
        Task<UserTables?> UserExist(string emailId);
    }
}
