using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Models
{
    public partial class PreviousTrip
    {
        public PreviousTrip()
        {
            TravelItineraries = new HashSet<TravelItinerary>();
        }

        public int IdPreviousTrips { get; set; }
        public DateTime Date { get; set; }
        public string UserId { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<TravelItinerary> TravelItineraries { get; set; }
    }
}
