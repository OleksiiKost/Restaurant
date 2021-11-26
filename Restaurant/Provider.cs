using System;
using System.Collections.Generic;

namespace Restaurant
{
    public partial class Provider
    {
        public Provider()
        {
            OrderToProviders = new HashSet<OrderToProvider>();
            ProviderInvoices = new HashSet<ProviderInvoice>();
        }

        public int IdProvider { get; set; }
        public int PhoneNumberProvider { get; set; }
        public string AdressProvider { get; set; } = null!;
        public string Email { get; set; } = null!;

        public virtual ICollection<OrderToProvider> OrderToProviders { get; set; }
        public virtual ICollection<ProviderInvoice> ProviderInvoices { get; set; }
    }
}
