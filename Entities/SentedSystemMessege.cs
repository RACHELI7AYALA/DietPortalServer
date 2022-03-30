using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Entities
{
    public partial class SentedSystemMessege
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public int MessegeId { get; set; }
        public DateTime Time { get; set; }
        [JsonIgnore]
        public virtual Group Group { get; set; }
        [JsonIgnore]
        public virtual SystemMessege Messege { get; set; }
    }
}
