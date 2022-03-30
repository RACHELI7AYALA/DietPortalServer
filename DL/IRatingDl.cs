using Entities;
using System.Threading.Tasks;

namespace DL
{
 public  interface IRatingDl
    {
        public Task AddRequest(Rating r);
    }
}