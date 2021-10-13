using System;
using System.Collections.Generic;


namespace YadBeYadApp.Models
{
    public partial class Rate
    {
        public int RateId { get; set; }
        public int Rates { get; set; }
        public int AttractionId { get; set; }
        public int UserId { get; set; }

        public virtual Attraction Attraction { get; set; }
        public virtual User User { get; set; }
    }
}
