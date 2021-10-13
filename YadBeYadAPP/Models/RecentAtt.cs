using System;
using System.Collections.Generic;



namespace YadBeYadApp.Models
{
    public partial class RecentAtt
    {
        public int AttractionId { get; set; }
        public int UserId { get; set; }
        public DateTime AttDate { get; set; }

        public virtual Attraction Attraction { get; set; }
        public virtual User User { get; set; }
    }
}
