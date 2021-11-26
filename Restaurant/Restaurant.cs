using System;
using System.Collections.Generic;

namespace Restaurant
{
    public partial class Restaurant
    {
        public int IdRestaurant { get; set; }
        public string NameRestaurant { get; set; } = null!;
        public string AdressRestaurant { get; set; } = null!;
        public string FullNameOwner { get; set; } = null!;
        public int PhoneNumberRestaurant { get; set; }
        public string Email { get; set; } = null!;
    }
}
