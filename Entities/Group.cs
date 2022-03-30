using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Entities
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
        [JsonIgnore]
        public virtual Gender Gender { get; set; }
        [JsonIgnore]
        public virtual User Manager { get; set; }
        [JsonIgnore]
        public virtual Status StatusNavigation { get; set; }
        [JsonIgnore]
        public virtual ICollection<SentedMessege> SentedMesseges { get; set; }
        [JsonIgnore]
        public virtual ICollection<SentedSystemMessege> SentedSystemMesseges { get; set; }
    }
}
