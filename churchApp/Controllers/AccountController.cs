using churchApp.Models;
using churchApp.Models.Tables;
using churchApp.Repo;
using churchApp.Services;
using Microsoft.AspNetCore.Mvc;


namespace churchApp.Controllers
{
 
    public class AccountController : Controller
    {
        private readonly AccountRepo repo;
        private readonly JwtTokenGeneration jwt;

        public AccountController(AccountRepo repo,JwtTokenGeneration jwt)
        {
            this.repo = repo;
            this.jwt = jwt;
        }
        [Route("[controller]/login")]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            try
            {
                var login=await repo.Login(model);
                if (login)
                {
                    var token=Generatoken(model);
                    return Ok(new {Token=token,email=model.emailId});
                }
                   
                else
                    return BadRequest("Please enter correct login details");
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [Route("[controller]/sigup")]
        [HttpPost]
        public async Task<IActionResult> Sigup([FromBody]UserTables model)
        {
            try {
                LoginModel lm = new LoginModel()
                {
                    emailId=model.email,
                    password=model.password
                };
                var checkUserExist = await repo.Login(lm);
                if (!checkUserExist)
                {
                    var sigup = await repo.Signup(model);
                    if (sigup)
                    {
                        return Ok(model);
                    }
                    else
                        return BadRequest("something want wrong");
                }
                return BadRequest("user Already exist");
                
            
            }catch (Exception ex) { throw new Exception(ex.Message); }
        }
        
        public string Generatoken(LoginModel model)
        {
            var token =  jwt.GenerateJwtTokenAsync(model);
            return token;
        }

    }
}
