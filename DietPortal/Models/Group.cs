using System;
using System.Collections.Generic;

#nullable disable

namespace DietPortal.Models
{
    public partial class Group
    {
        public Group()
        {
            SentedMesseges = new HashSet<SentedMessege>();
            SentedSystemMesseges = new HashSet<SentedSystemMessege>();
        }

        public int Id { get; set; }
        public string GroupName { get; set; }
        public int? ManagerId { get; set; }
        public bool IsOpen { get; set; }
        public string Password { get; set; }
        public DateTime StartDate { get; set; }
        public int NumOfWeeks { get; set; }
        public int Status { get; set; }
        public int? GenderId { get; set; }
        public int? MinAge { get; set; }
        public int? MaxAge { get; set; }

        public virtual Gender Gender { get; set; }
        public virtual User Manager { get; set; }
        public virtual Status StatusNavigation { get; set; }
        public virtual ICollection<SentedMessege> SentedMesseges { get; set; }
        public virtual ICollection<SentedSystemMessege> SentedSystemMesseges { get; set; }
    }
}
