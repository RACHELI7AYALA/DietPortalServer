using System;
using System.Collections.Generic;

#nullable disable

namespace DietPortal.Models
{
    public partial class SystemMessege
    {
        public SystemMessege()
        {
            SentedSystemMesseges = new HashSet<SentedSystemMessege>();
        }

        public int Id { get; set; }
        public string MessegeContent { get; set; }

        public virtual ICollection<SentedSystemMessege> SentedSystemMesseges { get; set; }
    }
}
