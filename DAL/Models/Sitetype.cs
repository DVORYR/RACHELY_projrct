using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Models
{
    public partial class Sitetype
    {
        public Sitetype()
        {
            TravelSites = new HashSet<TravelSite>();
        }

        public int IdSiteType { get; set; }
        public string Name { get; set; }

        public virtual ICollection<TravelSite> TravelSites { get; set; }
    }
}
