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
    public class PortalController : Controller
    {

        IPortalBl pbl;
        public PortalController(IPortalBl pbl)
        {
            this.pbl = pbl;
        }

        [HttpGet("{groupId}/Group")]
        public async Task<DTO.GroupDetails> getGroupDetails(int groupId)
        {
            return await pbl.getGroupDetails(groupId);
             
        }

        [HttpPost]
        public async Task<int> AddMessege([FromBody] SentedMessege sentedMessege)
        {

            return await pbl.AddMessege(sentedMessege);

        }
    


    }
}
