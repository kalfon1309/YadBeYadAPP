using System;
using System.Collections.Generic;


namespace YadBeYadApp.Models
{
    public partial class User
    {
        public User()
        {
            Rates = new List<Rate>();
            Reviews = new List<Review>();
        }

        public int UserId { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string UserName { get; set; }
        public string Pass { get; set; }

        public virtual List<Rate> Rates { get; set; }
        public virtual List<Review> Reviews { get; set; }
    }
}
