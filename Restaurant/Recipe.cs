using System;
using System.Collections.Generic;

namespace Restaurant
{
    public partial class Recipe
    {
        public int IdIngredient { get; set; }
        public int IdDish { get; set; }
        public int Quantity { get; set; }
        public int IdUnitOfMent { get; set; }
        public string? MethodOfCooking { get; set; }

        public virtual UnitOfMeasurement IdUnitOfMentNavigation { get; set; } = null!;
    }
}
