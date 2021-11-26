using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Restaurant
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (RestaurantContext db = new RestaurantContext())
            {

                /*
                 // ------------------------ 2 TASK --------------------------------------------
                // ADD
                
                    Console.WriteLine("\nData:");
                    var un = db.UnitOfMeasurements.ToList();
                    foreach (UnitOfMeasurement u in un)
                    {
                        Console.WriteLine($"{u.IdUnitOfMent}  {u.NameUnit}");
                    }

                    UnitOfMeasurement u1 = new UnitOfMeasurement { IdUnitOfMent = 3, NameUnit = "Galon" };

                    db.UnitOfMeasurements.Add(u1);
                    db.SaveChanges();
               

                // GET
                
                    Console.WriteLine("\nNew data added:");
                    var ung = db.UnitOfMeasurements.ToList();
                    foreach (UnitOfMeasurement u in ung)
                    {
                        Console.WriteLine($"{u.IdUnitOfMent}  {u.NameUnit}");
                    }
                

                // EDIT

                
                    UnitOfMeasurement unit = db.UnitOfMeasurements.Find(1);
                    if (unit != null)
                    {
                        unit.NameUnit = "KiloGramme";
                        db.SaveChanges();
                    }

                    Console.WriteLine("\nData after edit:");
                    var unv = db.UnitOfMeasurements.ToList();
                    foreach (UnitOfMeasurement u in unv)
                    {
                        Console.WriteLine($"{u.IdUnitOfMent}  {u.NameUnit}");
                    }
                

                // DELETE

                    UnitOfMeasurement user = db.UnitOfMeasurements.Find(3);
                    if (user != null)
                    {
                        db.UnitOfMeasurements.Remove(user);
                        db.SaveChanges();
                    }
                    Console.WriteLine("\nData after deleting:");
                    var unbb = db.UnitOfMeasurements.ToList();
                    foreach (UnitOfMeasurement u in unbb)
                    {
                        Console.WriteLine($"{u.IdUnitOfMent}  {u.NameUnit}");
                    }
                




                // ------------------------ 3 TASK --------------------------------------------


               
                var ord = db.Orders.Take(4);
                foreach (Order o in ord)
                    Console.WriteLine("{0}\t {1}\t {2}\t {3}",  o.IdOrder, o.TotalPrice, o.NumberOfTable, o.IdPersonal);
                Console.WriteLine("\n############################################################################################");


                var menu_count = db.Menus.Count();
                Console.WriteLine(menu_count);
                Console.WriteLine("\n############################################################################################");


                var men = db.Menus.OrderByDescending(x => x.NameDish).Take(5);
                foreach (Menu m in men)
                    Console.WriteLine("{0}  {1}", m.IdDish, m.NameDish);
                Console.WriteLine("\n############################################################################################");


                var men2 = db.Menus.OrderBy(x => x.Price).Take(5);
                foreach (Menu m in men2)
                    Console.WriteLine("{0} {1} {2}", m.IdDish, m.NameDish, m.Price);
                Console.WriteLine("\n############################################################################################");


                var pers = db.Personals
                   .Where(x => x.PhoneNumber.Contains("067"));
                foreach (Personal p in pers)
                    Console.WriteLine("{0}  {1} {2}", p.PhoneNumber, p.Surname, p.Patronymic);
                Console.WriteLine("\n############################################################################################");


                var ut = db.Menus.Select(x => new { NameDish = x.NameDish }).Union(db.ListOfDishesToOrders.Select(y => new { NameDish = y.NameDish }));
                foreach (var c in ut)
                    Console.WriteLine(c.NameDish);
                Console.WriteLine("\n############################################################################################");


                var ext = db.Menus.Select(x => new { NameDish = x.NameDish }).Except(db.ListOfDishesToOrders.Select(y => new { NameDish = y.NameDish }));
                foreach (var c in ext)
                    Console.WriteLine(c.NameDish);
                Console.WriteLine("\n############################################################################################");


                // inner join
                var jt = from or in db.Orders join per in db.Personals
                         on or.IdPersonal equals per.IdPersonal
                         select new { Idorder = or.IdOrder, TotalPrice = or.TotalPrice, Surname = per.Surname, Name = per.Name };
                foreach (var x in jt)
                    Console.WriteLine("{0}  {1}  {2} {3}", x.Idorder, x.TotalPrice, x.Surname, x.Name);
                Console.WriteLine("\n############################################################################################");


                var groups = db.ListOfDishesToOrders.GroupBy(p => p.NameDish).Select(g => new { Name = g.Key, Count = g.Count()});
                foreach (var c in groups)
                    Console.WriteLine("К-сть страв: {0} Страва: {1} ", c.Count, c.Name);
                Console.WriteLine("\n############################################################################################");


                var sum1 = db.Menus.Sum(x => x.Price);
                Console.WriteLine($"Sum: {sum1}");

                var max1 = db.Menus.Max(x => x.Price);
                Console.WriteLine($"Max: {max1}");

                var min1 = db.Menus.Min(x => x.Price);
                Console.WriteLine($"Min: {min1}");

                var avgpr = db.Menus.Average(x => x.Price);
                Console.WriteLine($"Avg: {avgpr}");
                Console.WriteLine("\n############################################################################################");
                


                // Procedure
                var param1 = new Microsoft.Data.SqlClient.SqlParameter
                {
                    ParameterName = "@MinPrice", 
                    SqlDbType = System.Data.SqlDbType.Money,
                    Direction = System.Data.ParameterDirection.Output,
                    Size = 50
                };
                var param2 = new Microsoft.Data.SqlClient.SqlParameter
                {
                    ParameterName = "@MaxPrice",
                    SqlDbType = System.Data.SqlDbType.Money,
                    Direction = System.Data.ParameterDirection.Output,
                    Size = 50
                };
                db.Database.ExecuteSqlRaw("GetPriceMenu_2 @MinPrice OUT, @MaxPrice OUT", param1, param2);
                Console.WriteLine("{0} {1}", param1.Value, param2.Value);
                Console.WriteLine("\n############################################################################################");
                


                // Function
                var param3 = new Microsoft.Data.SqlClient.SqlParameter("@min_price", 40);
                    var param4 = new Microsoft.Data.SqlClient.SqlParameter("@max_price", 200);
                    var users = db.ListOfDishesToOrders.FromSqlRaw("SELECT * FROM [Orders] (@min_price, @max_price)", param3, param4).ToList();
                    foreach (var u in users)
                        Console.WriteLine($"{u.NameDish} - {u.Price}");
                Console.WriteLine("\n############################################################################################");
                */



                // знайти за кожний день який офіціант заробив найбільший тоталпрайс

                /*
                var j_t = from or in db.Orders
                         join per in db.Personals
                         on or.IdPersonal equals per.IdPersonal

                         select new { Date = or.Date, Idorder = or.IdOrder, TotalPrice = or.TotalPrice, Surname = per.Surname, Name = per.Name };
                
                foreach (var x in j_t)
                    Console.WriteLine("{0}  {1}  {2} {3}", x.Date, x.TotalPrice, x.Surname, x.Name);
                Console.WriteLine("\n############################################################################################");*/


                var gro = from u in db.Orders
                          group u by u.Date into g
                             select new
                             {
                                 g.Key,
                                 Count = g.Count()
                             };
                foreach (var group in gro)
                {
                    Console.WriteLine($"{group.Key} - {group.Count} ");
                }
                Console.WriteLine("\n############################################################################################");


                DateTime d_check = new DateTime();

                var tableD = db.Orders.Select(x => x.Date).OrderBy(x => x.Date);
                foreach (var d in tableD)
                    if (d == d_check) 
                    {
                        continue;
                    }
                    else 
                    {
                        Console.Write($"{d} ");
                        PriceForDaste(d);
                        d_check = d;
                    }
                    

                Console.Read();


            }

        }

        static void PriceForDaste(DateTime data_func)
        {
            using (RestaurantContext db = new RestaurantContext())
            {

                var joinTable = db.Orders.Join(db.Personals,
                    x => x.IdPersonal,
                    y => y.IdPersonal, (x, y) => new
                    {

                        Surname = y.Surname,
                        Date = x.Date,
                        Price = x.TotalPrice
                    })
                    .Where(x => x.Date == data_func);

                var nameTable = from x in joinTable
                                group x by x.Surname into g
                                select new { Name = g.Key, Price = g.Sum(x => x.Price) };

                var lastTable = nameTable.OrderByDescending(x => x.Price).Take(1);

                foreach (var table in lastTable)
                    Console.WriteLine($"{table.Name}   {table.Price}");
            }
        }
    }
}