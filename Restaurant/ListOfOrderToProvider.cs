using System;
using System.Collections.Generic;

namespace Restaurant
{
    public partial class ListOfOrderToProvider
    {
        public int IdOrderToProvider { get; set; }
        public int IdIngredient { get; set; }
        public int IdUnitOfMent { get; set; }
        public int Quantity { get; set; }

        public virtual UnitOfMeasurement IdUnitOfMentNavigation { get; set; } = null!;
    }
}
