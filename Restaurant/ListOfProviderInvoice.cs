using System;
using System.Collections.Generic;

namespace Restaurant
{
    public partial class ListOfProviderInvoice
    {
        public int IdInvoice { get; set; }
        public int IdIngredient { get; set; }
        public int IdUnitOfMent { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public virtual UnitOfMeasurement IdUnitOfMentNavigation { get; set; } = null!;
    }
}
