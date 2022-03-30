using DTO;
using Entities;
using System.Threading.Tasks;

namespace BL
{
    public interface IPortalBl
    {
        public  Task<GroupDetails> getGroupDetails(int groupId);
        public  Task<int> AddMessege(SentedMessege m);
    }
}