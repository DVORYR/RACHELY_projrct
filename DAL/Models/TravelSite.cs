using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Models
{
    public partial class TravelSite
    {
        public int IdTravelsite { get; set; }
        public string Name { get; set; }
        public int IdArea { get; set; }
        public string Address { get; set; }
        public double Time { get; set; }
        public bool Accessibility { get; set; }
        public bool Payment { get; set; }
        public int IdSiteType { get; set; }
        public string SuitableFor { get; set; }

        public virtual Area IdAreaNavigation { get; set; }
        public virtual Sitetype IdSiteTypeNavigation { get; set; }
        public virtual TravelItinerary TravelItinerary { get; set; }
    }
}
