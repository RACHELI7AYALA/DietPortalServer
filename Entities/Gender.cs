using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Entities
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
        [JsonIgnore]
        public virtual ICollection<Group> Groups { get; set; }
        [JsonIgnore]
        public virtual ICollection<User> Users { get; set; }
    }
}
