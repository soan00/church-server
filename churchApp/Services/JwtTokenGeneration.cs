using churchApp.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Mail;
using System.Net;
using System.Security.Claims;
using System.Text;
using Newtonsoft.Json.Linq;

namespace churchApp.Services
{
    public class JwtTokenGeneration
    {
    

        public string GenerateJwtTokenAsync(LoginModel user)
        {
            var key = Encoding.ASCII.GetBytes("THIS_IS_MY_SECURITY_KEY_AND_THIS_IS_MY_KEY");
            var claim = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.NameId,user.emailId)
        };            
            var tokenDis = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claim),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };        
            var tokenHandler = new JwtSecurityTokenHandler();
            var token=tokenHandler.CreateToken(tokenDis);
            return tokenHandler.WriteToken(token);
        }
        public string? getEmailIdFromToken(string jwtToken)
        {

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.ReadJwtToken(jwtToken);

            // Retrieve the value of the "NameId" claim
            var value= token?.Claims.FirstOrDefault(x => x.Type == "nameid")?.Value;
            return value;
        }

        public  string sendVerificationEamil(string to)
        {
            try
            {
                // Sender's email address
                var fromAddress = new MailAddress("yourgmail@gmail.com", "Your Name");
                // Recipient's email address
                var toAddress = new MailAddress(to);

                // Gmail SMTP server details
                const string smtpServer = "smtp.gmail.com";
                const int smtpPort = 587; // or 465 for SSL

                // Gmail credentials (username and password)
                const string username = "yourgmail@gmail.com";
                const string password = "yourgmailpassword";

                // Create an instance of the SmtpClient class
                using (var smtp = new SmtpClient
                {
                    Host = smtpServer,
                    Port = smtpPort,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(username, password)
                })
                {
                    // Create a new instance of the MailMessage class
                    using (var message = new MailMessage(fromAddress, toAddress)
                    {
                        Subject = "",
                        Body = ""
                    })
                    {
                        // Send the email
                        smtp.Send(message);
                    }
                }

                return "Email sent successfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
