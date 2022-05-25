using BL;
using DTO;
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
    public class GroupController : Controller
    {

        IGroupBl gbl;
        public GroupController(IGroupBl gbl)
        {
            this.gbl = gbl;
        }

        [HttpGet("{groupId}")]
        public async Task<Group> Get(int groupId)
        {

            return await gbl.GetGroup(groupId);
        }
       


        [HttpGet("{userId}/User")]
        public async Task<Group> GetGroupById(int userId)
        {
            return await gbl.GetGroupByUserId(userId);
        }


        [HttpGet]
        public async Task<List<Group>> GetAllGroups()
        {
           
            return await gbl.GetAllGroups();
        }
        
        [HttpPost]
        public async Task<int> AddGroup([FromBody]Group g)
        {       
                return await gbl.AddGroup(g);
        }


        [HttpPut]
        public async Task<Group> UpdateGroup([FromBody] Group group)
        {
            return await gbl.UpdateGroup(group);
        }
       
    }
}
