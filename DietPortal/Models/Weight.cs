using System;
using System.Collections.Generic;

#nullable disable

namespace DietPortal.Models
{
    public partial class Weight
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int GroupId { get; set; }
        public DateTime Date { get; set; }
        public double? CurrentWeight { get; set; }
        public double? Kg { get; set; }

        public virtual Group Group { get; set; }
        public virtual User User { get; set; }
    }
}
