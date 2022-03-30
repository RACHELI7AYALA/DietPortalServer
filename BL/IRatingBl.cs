using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public interface IRatingBl
    {
        public Task AddRequest(Rating r);
    }
}
