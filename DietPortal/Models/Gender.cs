using System;
using System.Collections.Generic;

#nullable disable

namespace DietPortal.Models
{
    public partial class Gender
    {
        public Gender()
        {
            Groups = new HashSet<Group>();
            Users = new HashSet<User>();
        }

        public string Gender1 { get; set; }
        public int Id { get; set; }

        public virtual ICollection<Group> Groups { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
