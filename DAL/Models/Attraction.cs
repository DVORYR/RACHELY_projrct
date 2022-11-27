using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Models
{
    public partial class Attraction
    {
        public int IdAttractions { get; set; }
        public string Name { get; set; }
        public int AreaId { get; set; }
        public int Phone { get; set; }
        public string Address { get; set; }
        public double? Price { get; set; }

        public virtual SubArea Area { get; set; }
    }
}
