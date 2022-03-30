using System;
using System.Collections.Generic;

#nullable disable

namespace DietPortal.Models
{
    public partial class UserInGroup
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int GroupId { get; set; }
        public byte[] FirstImage { get; set; }
        public byte[] LastImage { get; set; }

        public virtual Group Group { get; set; }
        public virtual User User { get; set; }
    }
}
