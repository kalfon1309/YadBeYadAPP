using System;
using System.Collections.Generic;



namespace YadBeYadApp.Models
{
    public partial class Review
    {
        public int ReviewId { get; set; }
        public string Comment { get; set; }
        public int AttractionId { get; set; }
        public bool IsActive { get; set; }
        public DateTime ReviewDate { get; set; }
        public int UserId { get; set; }

        public virtual Attraction Attraction { get; set; }
        public virtual User User { get; set; }
    }
}
