using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Entities
{
    public partial class User
    {
        public User()
        {
            Groups = new HashSet<Group>();
            SentedMesseges = new HashSet<SentedMessege>();
        }

        public int Id { get; set; }
        public string IdentityNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Gender { get; set; }
        public double Weight { get; set; }
        public string Password { get; set; }
        public byte[] Profile { get; set; }
        //public string ProfileImaePath { get; set; }
        [JsonIgnore]
        public virtual Gender GenderNavigation { get; set; }
        [JsonIgnore]
        public virtual ICollection<Group> Groups { get; set; }
        [JsonIgnore]
        public virtual ICollection<SentedMessege> SentedMesseges { get; set; }
    }
}
