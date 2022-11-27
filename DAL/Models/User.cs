using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Models
{
    public partial class User
    {
        public User()
        {
            PreviousTrips = new HashSet<PreviousTrip>();
        }

        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string City { get; set; }

        public virtual ICollection<PreviousTrip> PreviousTrips { get; set; }
    }
}
