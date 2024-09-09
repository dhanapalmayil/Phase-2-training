using API_Mini_Project_Recruitment_Agency_.Interface;
using API_Mini_Project_Recruitment_Agency_.Models;
using API_Mini_Project_Recruitment_Agency_.Repository;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API_Mini_Project_Recruitment_Agency_.Service
{
    public class UserService
    {
        private readonly IUser _user;
        private readonly IConfiguration _config;

        public UserService(IUser user, IConfiguration config)
        {
            _user = user;
            _config = config;
        }

        public async Task<IEnumerable<ValidUser>> GetUsers()
        {
            return await _user.GetAllUsers();
        }

        public async Task<ValidUser> GetUserById(int id)
        {
            return await _user.GetUserById(id);
        }

        public async Task AddUser(ValidUser user)
        {
            await _user.AddUser(user);
        }

        public async Task UpdateUser(ValidUser user)
        {
            await _user.UpdateUser(user);
        }

        public async Task DeleteUser(int id)
        {
            await _user.DeleteUser(id);
        }

        public async Task<string> AuthenticateAsync(string email, string password)
        {
            var user = await _user.GetUserByEmail(email);
            if (user == null || user.Password != password) // Use hashed password in production
                return string.Empty;

            return GenerateToken(user);
        }

        public async Task RegisterAsync(ValidUser user)
        {
            await _user.AddUser(user);
        }

        private string GenerateToken(ValidUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: null,
                audience: null,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(30),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
