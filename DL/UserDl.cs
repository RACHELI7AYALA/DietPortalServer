
using AutoMapper;
using DTO;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class UserDl : IUserDl
    {
        ProjectDBContext dbContext;
        IMapper mapper;
        public UserDl(ProjectDBContext dbContext,IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper=mapper;
        }

        public async Task<User> GetUser(int id)
        {
            return await dbContext.Users.SingleOrDefaultAsync(u => u.Id == id);
            
        }

        public async Task<User> LogIn(string firstName, string lastName, string password)
        {

            return await dbContext.Users.SingleOrDefaultAsync(u => u.FirstName == firstName && u.LastName == lastName && u.Password == password);

        }

       

        public async Task<List<User>> GetAllUsers()
        {
            return await dbContext.Users.ToListAsync();
        }

        public async Task<int> AddUser(User u)
        {
            await dbContext.Users.AddAsync(u);
            await dbContext.SaveChangesAsync();
            return u.Id;
            
        }
 
        public async Task<User> UpdateUser(User u)
        {
            var userToUpdate = await dbContext.Users.FindAsync(u.Id);
            if (userToUpdate == null)
                return null;
            dbContext.Entry(userToUpdate).CurrentValues.SetValues(u);
            await dbContext.SaveChangesAsync();
           
            return u;
        }
        
            public async Task<List<UserWithKg>>  GetUsersWithKg(int groupId) {

            return await dbContext.Weights.Where(w => w.GroupId == groupId/*&&( w.Date.AddDays(7) > DateTime.Now))*/).Join(dbContext.Users, w => w.UserId, u => u.Id,
                   (w, u) => /*mapper.Map<Weight,UserWithKg>(w)).ToListAsync();*/
                   new UserWithKg
                   {
                       Name = u.FirstName,
                       Id = u.Id,
                       Kg = w.Kg
                   }).ToListAsync();
        }
        public async Task<List<UserWithKg>> GetAllUsersWithKg(int groupId)
        {
            DateTime today = DateTime.Today;

            return await dbContext.Weights.Where(w => w.GroupId == groupId && w.Date.AddDays(7) >= today)‏.Join(dbContext.Users, w => w.UserId, u => u.Id,
                   (w, u) => /*mapper.Map<Weight,UserWithKg>(w)).ToListAsync();*/
                   new UserWithKg
                   {
                       Name = u.FirstName,
                       Id = u.Id,
                       Kg = w.Kg
                   }).ToListAsync();
        }



    }

}
