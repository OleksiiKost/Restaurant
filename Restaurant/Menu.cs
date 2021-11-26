using System;
using System.Collections.Generic;

namespace Restaurant
{
    public partial class Menu
    {
        public int IdDish { get; set; }
        public string NameDish { get; set; } = null!;
        public decimal Price { get; set; }
        public int IdUnitOfMent { get; set; }
        public double Weight { get; set; }
        public double Calories { get; set; }
        public string Recipe { get; set; } = null!;
     

        public virtual UnitOfMeasurement IdUnitOfMentNavigation { get; set; } = null!;
    }
}
