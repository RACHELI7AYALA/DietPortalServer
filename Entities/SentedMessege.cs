using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Entities
{
    public partial class SentedMessege
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public int UserId { get; set; }
        public DateTime Time { get; set; }
        public string Content { get; set; }
        [JsonIgnore]
        public virtual Group Group { get; set; }
        [JsonIgnore]
        public virtual User User { get; set; }
    }
}
