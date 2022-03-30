using System;
using System.Collections.Generic;

#nullable disable

namespace DietPortal.Models
{
    public partial class Status
    {
        public Status()
        {
            Groups = new HashSet<Group>();
        }

        public string Status1 { get; set; }
        public int Id { get; set; }

        public virtual ICollection<Group> Groups { get; set; }
    }
}
