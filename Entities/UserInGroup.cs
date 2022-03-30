using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Entities
{
    public partial class UserInGroup
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int GroupId { get; set; }
        public byte[] FirstImage { get; set; }
        public byte[] LastImage { get; set; }
        [JsonIgnore]
        public virtual Group Group { get; set; }
        [JsonIgnore]
        public virtual User User { get; set; }
    }
}
