using BL;
using Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace DietPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        IUserBl ubl;
        IUserInGroupBl uigbl;
        public UserController(IUserBl ubl,IUserInGroupBl uigbl)
        {

            this.ubl = ubl;
            this.uigbl = uigbl;
        }


        [HttpGet("{userId}")]
        public async Task<User> Get(int userId)
        {
          
            return await ubl.GetUser(userId);
        }
        [HttpGet ("{name}/{password}")]

        public async Task<User>LogIn(string name,string password)
        {
           
            User u= await ubl.LogIn(name,password);                                                      
                  return u;
        }

        [HttpGet("{id}/Group")]
        
        public async Task<List<User>> GetAllUsers(int id) 
        {
            return await uigbl.GetAllUsers(id);
        }
        [HttpGet]
        
        public async Task<List<User>> GetAllUsers()
        {
            return await ubl.GetAllUsers();
        }
        
        
        [HttpPost]


        public async Task AddUser([FromBody]User user)
        {          
           ubl.AddUser(user);
        }
        [HttpPost("/Group/{userInGroup}/{password?}")]

        public async Task<int> AddUserInGroup(UserInGroup userInGroup, string? password)
        {
            return await uigbl.AddUserInGroup(userInGroup, password);
        }

        [HttpDelete("/UserInGroup")]

        public async Task DeleteUserInGroup([FromBody] UserInGroup userInGroup)
        {
            await uigbl.DeleteUserInGroup(userInGroup);
        }

        [HttpPut]
     
        public async Task<User> UpdateUser([FromBody] User user)
        {
            return await ubl.UpdateUser(user);
        }

       


    }
}
