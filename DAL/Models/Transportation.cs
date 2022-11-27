using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Models
{
    public partial class Transportation
    {
        public int IdTransportation { get; set; }
        public string Name { get; set; }
        public int AreaId { get; set; }
        public int Phone { get; set; }
        public string Recommendations { get; set; }

        public virtual Area Area { get; set; }
    }
}
