using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Models
{
    public partial class Area
    {
        public Area()
        {
            SubAreas = new HashSet<SubArea>();
            Transportations = new HashSet<Transportation>();
            TravelSites = new HashSet<TravelSite>();
        }

        public int IdArea { get; set; }
        public string Name { get; set; }

        public virtual ICollection<SubArea> SubAreas { get; set; }
        public virtual ICollection<Transportation> Transportations { get; set; }
        public virtual ICollection<TravelSite> TravelSites { get; set; }
    }
}
