using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class RatingDl : IRatingDl
    {
        ProjectDBContext dbContext;
        public RatingDl(ProjectDBContext dbContext)
        {
            this.dbContext = dbContext;
        }
       public async Task AddRequest(Rating r)
        {
            await dbContext.Ratings.AddAsync(r);
            await dbContext.SaveChangesAsync();
         
        }
    }
}
