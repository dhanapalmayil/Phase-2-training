using API_Demo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API_Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly SymmetricSecurityKey _key;
        private readonly EmployeeOrgContext _con;
        public TokenController(IConfiguration configuration, EmployeeOrgContext con)
        {
            _key = new SymmetricSecurityKey(UTF8Encoding.UTF8.GetBytes(configuration["Key"]!));
            _con = con;
        }

        [HttpPost]
        public string GenerateToken(ValidUser user)
        {
            string token = string.Empty;

                if (ValidateUser(user.email, user.password, user.role))
                {
                    var claims = new List<Claim>
                {
                    new Claim(JwtRegisteredClaimNames.NameId, user.userName!),
                    new Claim(JwtRegisteredClaimNames.Email, user.email),
                    new Claim(ClaimTypes.Role, user.role!) // Add the user's role as a claim
                };

                    var cred = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256);
                    var tokenDescription = new SecurityTokenDescriptor
                    {
                        SigningCredentials = cred,
                        Subject = new ClaimsIdentity(claims),
                        Expires = DateTime.Now.AddMinutes(2)
                    };

                    var tokenHandler = new JwtSecurityTokenHandler();
                    var createToken = tokenHandler.CreateToken(tokenDescription);
                    token = tokenHandler.WriteToken(createToken);
                }
                else
                {
                    return string.Empty;
                }

            

            return token;
        }

        // Static token generation for admin
      
        // Validate user based on email, password, and role
        private bool ValidateUser(string email, string password, string requiredRole)
        {
            var user = _con.ValidUsers.FirstOrDefault(u => u.email == email && u.password == password);
            return user != null && user.role == requiredRole;
        }
    }
    //public class TokenController : ControllerBase
    //{
    //    private readonly SymmetricSecurityKey _key;
    //    private readonly EmployeeOrgContext _con;
    //    public TokenController(IConfiguration configuration, EmployeeOrgContext con)
    //    {
    //        _key = new SymmetricSecurityKey(UTF8Encoding.UTF8.GetBytes(configuration["Key"]!));
    //        _con = con;
    //    }
    //    [HttpPost]
    //    public string GenerateToken(ValidUser user)
    //    {
    //        string token = string.Empty;
    //        if (ValidateUser(user.email, user.password))
    //        {
    //            var claims = new List<Claim>
    //              {
    //                  new Claim(JwtRegisteredClaimNames.NameId,user.userName!),
    //                  new Claim(JwtRegisteredClaimNames.Email,user.email)

    //              };
    //            var cred = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256);
    //            var tokenDescription = new SecurityTokenDescriptor
    //            {
    //                SigningCredentials = cred,
    //                Subject = new ClaimsIdentity(claims),
    //                Expires = DateTime.Now.AddMinutes(2)
    //            };
    //            var tokenHandler = new JwtSecurityTokenHandler();
    //            var createToken = tokenHandler.CreateToken(tokenDescription);
    //            token = tokenHandler.WriteToken(createToken);
    //            return token;
    //        }
    //        else
    //        {
    //            return string.Empty;
    //        }
    //    }
    //    private bool ValidateUser(string email, string password)
    //    {
    //        var users = _con.ValidUsers.ToList();
    //        var user = users.FirstOrDefault(u => u.email == email && u.password == password);
    //        if (user != null)
    //        {
    //            return true;
    //        }
    //        else
    //        {
    //            return false;
    //        }
    //    }
    //}
}
