using System;
using System.Collections.Generic;

namespace Restaurant
{
    public partial class ListOfDishesToOrder
    {
        public int IdDish { get; set; }
        public int IdOrder { get; set; }
        public string NameDish { get; set; } = null!;
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
