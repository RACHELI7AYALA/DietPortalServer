using System;
using System.Collections.Generic;

#nullable disable

namespace DietPortal.Models
{
    public partial class SentedSystemMessege
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public int MessegeId { get; set; }
        public DateTime Time { get; set; }

        public virtual Group Group { get; set; }
        public virtual SystemMessege Messege { get; set; }
    }
}
