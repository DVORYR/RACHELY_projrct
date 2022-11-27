using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Models
{
    public partial class TravelItinerary
    {
        public int IdTravelItineraries { get; set; }
        public int IdPreviousTrips { get; set; }
        public int StartTime { get; set; }
        public int TravelSitesId { get; set; }

        public virtual PreviousTrip IdPreviousTripsNavigation { get; set; }
        public virtual TravelSite IdTravelItinerariesNavigation { get; set; }
    }
}
