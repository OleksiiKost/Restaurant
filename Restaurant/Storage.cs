using System;
using System.Collections.Generic;

namespace Restaurant
{
    public partial class Storage
    {
        public int IdIngredient { get; set; }
        public int IdRestaurant { get; set; }
        public DateTime DateOfManufacture { get; set; }
        public int IdUnitOfMent { get; set; }
        public int Quantity { get; set; }
        public int IdInvoice { get; set; }

        public virtual ProviderInvoice IdInvoiceNavigation { get; set; } = null!;
        public virtual UnitOfMeasurement IdUnitOfMentNavigation { get; set; } = null!;
    }
}
