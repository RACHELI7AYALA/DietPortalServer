using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
   public class PortalDl: IPortalDl
    {


        ProjectDBContext dbContext;
        public PortalDl(ProjectDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

       public async Task<List<int>> getUserInGroup(int groupId)
        {
           return  await dbContext.UserInGroups.Where(g => g.GroupId == groupId).Select(g => g.UserId).ToListAsync();
        }
        public async Task<List<SentedMessege>> getMesseges(int groupId)//add lazy??
        {
            return await dbContext.SentedMesseges.Where(g => g.GroupId == groupId).ToListAsync();
        }
        public async Task<int> AddMessege(SentedMessege m)
        {
            await dbContext.SentedMesseges.AddAsync(m);
            return await dbContext.SaveChangesAsync();

        }



    }
}
