using System;
using System.Collections.Generic;



namespace YadBeYadApp.Models
{
    public partial class Attraction
    {
        public Attraction()
        {
            Rates = new List<Rate>();
            Reviews = new List<Review>();
        }

        public int AttractionId { get; set; }
        public string AttName { get; set; }
        public string AttDescription { get; set; }
        public string AttLocation { get; set; }
        public string GeographyLoc { get; set; }
        public bool IsPrice { get; set; }

        public virtual List<Rate> Rates { get; set; }
        public virtual List<Review> Reviews { get; set; }
    }
}
