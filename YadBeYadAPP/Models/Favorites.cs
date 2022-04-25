using System;
using System.Collections.Generic;
using System.Text;


namespace YadBeYadApp.Models
{
    public partial class Favorite
    {
        public int FavoriteId { get; set; }
        public int AttractionId { get; set; }
        public int UserId { get; set; }
        public bool IsActive { get; set; }

        public virtual Attraction Attraction { get; set; }
        public virtual User User { get; set; }
    }
}
