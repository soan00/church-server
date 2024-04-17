using churchApp.Interface;
using churchApp.Models;
using churchApp.Models.Tables;
using Microsoft.EntityFrameworkCore;

namespace churchApp.Repo
{
    public class AccountRepo : IAccount
    {
        
        private readonly ContexClass _db;

        public AccountRepo(ContexClass db)
        {
            _db = db;
        }
        public async Task<UserTables?> Login(LoginModel model)
        {
          var user= await _db.Users.Include(x=>x.Role).FirstOrDefaultAsync(x=>x.email==model.emailId && x.password==model.password);
         
                return user;
           
        }

        public async Task<bool> Signup(UserTables model)
        {
            if (model.email != null)
            {
                 _db.Users.Add(model);
                await _db.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<UserTables?> UserExist(string emailId)
        {
            return await _db.Users.FirstOrDefaultAsync(x => x.email == emailId);
        }
    }
}
