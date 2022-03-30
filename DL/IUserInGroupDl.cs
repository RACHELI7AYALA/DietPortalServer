using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public interface IUserInGroupDl
    {
        public Task<int> AddUserInGroup(UserInGroup userInGroup);
        public Task<List<UserInGroup>> GetAllUserGroups(int userId);
        public Task DeleteUserInGroup(UserInGroup userInGroup);
        public Task<List<User>> GetAllUsers(int groupId);
    }
}
