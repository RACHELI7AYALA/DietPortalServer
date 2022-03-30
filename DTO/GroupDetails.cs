using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace DTO
{
   public class GroupDetails
    {
        public List<UserWithKg> Userswithkg{ get; set; }
        public List<SentedMessege> Sentedmesseges { get; set; }
        public KeyValuePair<List<int>, double?> WeeklyGroupWinner { get; set; }
    

    }
}
