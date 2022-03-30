
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class UserInGroupDl :IUserInGroupDl
    {
        ProjectDBContext dbContext;
        public UserInGroupDl(ProjectDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

       
        public async Task<int> AddUserInGroup(UserInGroup userInGroup)
        {
            await dbContext.UserInGroups.AddAsync(userInGroup);
            return await dbContext.SaveChangesAsync();

        }
        public async Task DeleteUserInGroup(UserInGroup userInGroup)
        {

            dbContext.UserInGroups.Remove(userInGroup);
            await dbContext.SaveChangesAsync();

        }
        public async Task<List<UserInGroup>> GetAllUserGroups(int userId)
        {
            return await dbContext.UserInGroups.Where(u => u.UserId == userId).ToListAsync();
        }
        public async Task<List<User>> GetAllUsers(int groupId)
        {
            return await dbContext.UserInGroups.Where(u => u.GroupId == groupId).Select(u => u.User).ToListAsync();
        }
    }
}
