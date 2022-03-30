using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Entities
{
    public partial class SystemMessege
    {
        public SystemMessege()
        {
            SentedSystemMesseges = new HashSet<SentedSystemMessege>();
        }

        public int Id { get; set; }
        public string MessegeContent { get; set; }
        [JsonIgnore]
        public virtual ICollection<SentedSystemMessege> SentedSystemMesseges { get; set; }
    }
}
