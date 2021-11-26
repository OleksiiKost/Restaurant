using System;
using System.Collections.Generic;

namespace Restaurant
{
    public partial class Ingredient
    {
        public int IdIngredient { get; set; }
        public string NameIngredient { get; set; } = null!;
        public int IdUnitOfMent { get; set; }
        public DateTime ExpirationDate { get; set; }

        public virtual UnitOfMeasurement IdUnitOfMentNavigation { get; set; } = null!;
    }
}
