using DL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class RatingBl : IRatingBl

    {
        IRatingDl rdl;
        public RatingBl(IRatingDl rdl)
        {
            this.rdl = rdl;
        }
        public async Task AddRequest(Rating r)
        {
            await rdl.AddRequest(r);
        }

      
    }
}
