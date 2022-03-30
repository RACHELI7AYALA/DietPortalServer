using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DL
{
    public interface IPortalDl
    {
        public  Task<List<int>> getUserInGroup(int groupId);
        public  Task<List<SentedMessege>> getMesseges(int groupId);
        public  Task<int> AddMessege(SentedMessege m);





    }
}