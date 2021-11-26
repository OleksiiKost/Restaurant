using System;
using System.Collections.Generic;

namespace Restaurant
{
    public partial class OrderToProvider
    {
        public OrderToProvider()
        {
            ProviderInvoices = new HashSet<ProviderInvoice>();
        }

        public int IdOrderToProvider { get; set; }
        public int IdProvider { get; set; }
        public int PhoneNumberProvider { get; set; }
        public int PhoneNumberRestaurant { get; set; }

        public virtual Provider IdProviderNavigation { get; set; } = null!;
        public virtual ICollection<ProviderInvoice> ProviderInvoices { get; set; }
    }
}
