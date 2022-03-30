using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Entities
{
    public partial class Weight
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int GroupId { get; set; }
        public DateTime Date { get; set; }
        public double? CurrentWeight { get; set; }
        public double? Kg { get; set; }
        [JsonIgnore]
        public virtual Group Group { get; set; }
        [JsonIgnore]
        public virtual User User { get; set; }
    }
}
