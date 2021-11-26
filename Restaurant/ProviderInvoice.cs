using System;
using System.Collections.Generic;

namespace Restaurant
{
    public partial class ProviderInvoice
    {
        public ProviderInvoice()
        {
            Storages = new HashSet<Storage>();
        }

        public int IdInvoice { get; set; }
        public int IdProvider { get; set; }
        public DateTime DateOfIssueInvoice { get; set; }
        public DateTime DateDelivery { get; set; }
        public int IdOrderToProvider { get; set; }

        public virtual OrderToProvider IdOrderToProviderNavigation { get; set; } = null!;
        public virtual Provider IdProviderNavigation { get; set; } = null!;
        public virtual ICollection<Storage> Storages { get; set; }
    }
}
