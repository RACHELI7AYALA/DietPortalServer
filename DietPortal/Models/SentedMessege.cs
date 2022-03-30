using System;
using System.Collections.Generic;

#nullable disable

namespace DietPortal.Models
{
    public partial class SentedMessege
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public int UserId { get; set; }
        public DateTime Time { get; set; }
        public string Content { get; set; }

        public virtual Group Group { get; set; }
        public virtual User User { get; set; }
    }
}
