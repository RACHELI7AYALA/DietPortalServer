using DTO;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public interface IUserDl
    {
        public Task<User> GetUser(int id);
        public Task<User> LogIn(string firstName, string lastName, string password);
 
        public Task<List<User>> GetAllUsers();
        public Task<int> AddUser(User u);
        public Task<User> UpdateUser(User u);
        public Task<List<UserWithKg>> GetUsersWithKg(int groupId);
        public Task<List<UserWithKg>> GetAllUsersWithKg(int groupId);


    }
}
