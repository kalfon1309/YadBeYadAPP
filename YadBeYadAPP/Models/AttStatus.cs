using System;
using System.Collections.Generic;



namespace YadBeYadApp.Models
{
    public partial class AttStatus
    {
        public int AttractionId { get; set; }
        public bool IsOpen { get; set; }
        public string OpeningHours { get; set; }
        public string ClosingHours { get; set; }
        public bool IsWeekend { get; set; }

        public virtual Attraction Attraction { get; set; }
    }
}
