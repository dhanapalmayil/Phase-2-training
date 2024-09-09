using API_Mini_Project_Recruitment_Agency_.Models;

namespace API_Mini_Project_Recruitment_Agency_.Interface
{
    public interface IUser
    {
        
        Task<IEnumerable<ValidUser>> GetAllUsers();
        Task<ValidUser> GetUserById(int id);
        Task AddUser(ValidUser user);
        Task UpdateUser(ValidUser user);
        Task DeleteUser(int id);
        Task<ValidUser> GetUserByEmail(string email);
    }
}

