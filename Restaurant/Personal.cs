using System;
using System.Collections.Generic;

namespace Restaurant
{
    public partial class Personal
    {
        public Personal()
        {
            Orders = new HashSet<Order>();
        }

        public int IdPersonal { get; set; }
        public string Surname { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Patronymic { get; set; }
        public string PhoneNumber { get; set; } = null!;
        public string? Position { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? Shift { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
