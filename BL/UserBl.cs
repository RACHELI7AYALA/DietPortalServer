﻿
using DL;
using DTO;
using Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BL
{
     public class UserBl:IUserBl
    {
        IUserDl udl;
        IGroupDl gdl;
        public UserBl( IUserDl udl, IGroupDl gdl)
        {
            this.udl=udl;
            this.gdl = gdl;
        }

        public async Task<User> GetUser(int id)
        {
            return await udl.GetUser(id);
        }

        public async Task<User> LogIn(string name, string password)
        {
  
            string firstName =name.Substring(0,name.IndexOf(" "));
            string lastName = name.Substring( name.IndexOf(" ")+1);
            return await udl.LogIn(firstName,lastName, password);
        }

       

        public async Task<List<User>> GetAllUsers()
        {
            return await udl.GetAllUsers();  
        }
        
        
        public async Task<int> AddUser(User u)
        {
           
            return await udl.AddUser(u);
        }

       public async Task<User> UpdateUser(User u)
        {
            return await udl.UpdateUser(u);
        }
        
        public async Task<List<UserWithKg>> GetUsersWithKg(int groupId)
        {
            return await udl.GetUsersWithKg(groupId);
        }
        public async Task<Group> GetGroupByUserId(int userId)
        {
            return await gdl.GetGroupByUserId(userId);
        }
       
    }

   
}
