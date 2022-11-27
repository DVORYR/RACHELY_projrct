using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Models
{
    public partial class TourGuide
    {
        public int IdTourGuides { get; set; }
        public string FullName { get; set; }
        public int Phone { get; set; }
        public int AreaId { get; set; }
        public string Gender { get; set; }
        public string Recommendations { get; set; }

        public virtual SubArea Area { get; set; }
    }
}
