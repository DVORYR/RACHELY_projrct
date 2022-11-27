using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Models
{
    public partial class SubArea
    {
        public SubArea()
        {
            Attractions = new HashSet<Attraction>();
            Restaurants = new HashSet<Restaurant>();
            TourGuides = new HashSet<TourGuide>();
        }

        public int IdSubArea { get; set; }
        public string Name { get; set; }
        public int Area { get; set; }

        public virtual Area AreaNavigation { get; set; }
        public virtual ICollection<Attraction> Attractions { get; set; }
        public virtual ICollection<Restaurant> Restaurants { get; set; }
        public virtual ICollection<TourGuide> TourGuides { get; set; }
    }
}
