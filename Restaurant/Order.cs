using System;
using System.Collections.Generic;

namespace Restaurant
{
    public partial class Order
    {
        public int IdOrder { get; set; }
        public decimal TotalPrice { get; set; }
        public int? NumberOfTable { get; set; }
        public int IdPersonal { get; set; }
        public DateTime Date { get; set; }

        public virtual Personal IdPersonalNavigation { get; set; } = null!;
    }
}
