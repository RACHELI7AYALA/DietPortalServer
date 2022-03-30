using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Entities
{
    public partial class Status
    {
        public Status()
        {
            Groups = new HashSet<Group>();
        }

        public string Status1 { get; set; }
        public int Id { get; set; }
        [JsonIgnore]
        public virtual ICollection<Group> Groups { get; set; }
    }
}
