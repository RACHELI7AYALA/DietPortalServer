using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public interface IUserInGroupBl
    {
        public Task<List<UserInGroup>> GetAllUserGroups(int userId);
        public Task<List<User>> GetAllUsers(int groupId);
        public Task<int> AddUserInGroup(UserInGroup userInGroup,string? password);
        public Task DeleteUserInGroup(UserInGroup userInGroup);
    }
}
