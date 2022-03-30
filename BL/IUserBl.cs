using DTO;
using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL
{
    public interface IUserBl
    {
        public Task<User> GetUser(int id);
        public Task<User> LogIn(string email, string password);
       
        public Task<List<User>> GetAllUsers();
        public Task<int> AddUser(User u);
        public Task<User> UpdateUser(User u);
        
        public Task<List<UserWithKg>> GetUsersWithKg(int groupId);
        public  Task<int> GetGroupId(int userId);
       
    }
}