using API_Mini_Project_Recruitment_Agency_.Interface;
using API_Mini_Project_Recruitment_Agency_.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Mini_Project_Recruitment_Agency_.Repository
{
    public class UserRepository : IUser
    {
        private readonly RecruitmentDbContext _context;

        public UserRepository(RecruitmentDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ValidUser>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<ValidUser> GetUserById(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task AddUser(ValidUser user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUser(ValidUser user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<ValidUser> GetUserByEmail(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}
