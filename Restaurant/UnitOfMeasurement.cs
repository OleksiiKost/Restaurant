using System;
using System.Collections.Generic;

namespace Restaurant
{
    public partial class UnitOfMeasurement
    {
        public UnitOfMeasurement()
        {
            Ingredients = new HashSet<Ingredient>();
            ListOfOrderToProviders = new HashSet<ListOfOrderToProvider>();
            ListOfProviderInvoices = new HashSet<ListOfProviderInvoice>();
            Menus = new HashSet<Menu>();
            Recipes = new HashSet<Recipe>();
            Storages = new HashSet<Storage>();
        }

        public int IdUnitOfMent { get; set; }
        public string NameUnit { get; set; } = null!;

        public virtual ICollection<Ingredient> Ingredients { get; set; }
        public virtual ICollection<ListOfOrderToProvider> ListOfOrderToProviders { get; set; }
        public virtual ICollection<ListOfProviderInvoice> ListOfProviderInvoices { get; set; }
        public virtual ICollection<Menu> Menus { get; set; }
        public virtual ICollection<Recipe> Recipes { get; set; }
        public virtual ICollection<Storage> Storages { get; set; }
    }
}
