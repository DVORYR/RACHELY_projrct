using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Models
{
    public partial class Restaurant
    {
        public int IdRestaurants { get; set; }
        public string Name { get; set; }
        public int AreaId { get; set; }
        public int Phone { get; set; }
        public string Address { get; set; }
        public string MeatyDairy { get; set; }

        public virtual SubArea Area { get; set; }
    }
}
