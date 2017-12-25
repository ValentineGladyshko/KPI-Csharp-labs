using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Data.Linq.SqlClient;

namespace lab6
{
    class Program
    {
        public static DateTime RandomDate(Random random)
        {
            DateTime start = DateTime.Today.AddDays(-7);
            return start.AddDays(random.Next(0, 7));
        }

        public static void InitData()
        {
            CSharpEntities db = new CSharpEntities();
            Manufacturers manufacturer1 = new Manufacturers()
            {
                Name = "Milk Alliance"
            };

            Manufacturers manufacturer2 = new Manufacturers()
            {
                Name = "Lipton"
            };

            Manufacturers manufacturer3 = new Manufacturers()
            {
                Name = "Roshen"
            };

            Products product1 = new Products()
            {
                Name = "Milk",
                Price = 20,
                Manufacturers = manufacturer1
            };
            Products product2 = new Products()
            {
                Name = "Cream",
                Price = 40,
                Manufacturers = manufacturer1
            };

            Products product3 = new Products()
            {
                Name = "Kefir",
                Price = 25,
                Manufacturers = manufacturer1
            };

            Products product4 = new Products()
            {
                Name = "Yogurt",
                Price = 30,
                Manufacturers = manufacturer1
            };

            Products product5 = new Products()
            {
                Name = "Black Tea",
                Price = 45,
                Manufacturers = manufacturer2
            };

            Products product6 = new Products()
            {
                Name = "Green Tea",
                Price = 30,
                Manufacturers = manufacturer2
            };

            Products product7 = new Products()
            {
                Name = "Coffee",
                Price = 65,
                Manufacturers = manufacturer2
            };

            Products product8 = new Products()
            {
                Name = "Candy",
                Price = 2,
                Manufacturers = manufacturer3
            };

            Products product9 = new Products()
            {
                Name = "Cake",
                Price = 150,
                Manufacturers = manufacturer3
            };

            Products product10 = new Products()
            {
                Name = "Lolipop",
                Price = 15,
                Manufacturers = manufacturer3
            };

            Stocks stock1 = new Stocks()
            {
                Name = "Kiev Stock"
            };

            Stocks stock2 = new Stocks()
            {
                Name = "Odessa Stock"
            };

            Stocks stock3 = new Stocks()
            {
                Name = "Kharkiv Stock"
            };

            Random random = new Random();

            Supply supply1 = new Supply()
            {
                Date = RandomDate(random),
                Products = product1,
                Stocks = stock1,
                Count = 20
            };

            Supply supply2 = new Supply()
            {
                Date = RandomDate(random),
                Products = product2,
                Stocks = stock1,
                Count = 30
            };

            Supply supply3 = new Supply()
            {
                Date = RandomDate(random),
                Products = product3,
                Stocks = stock1,
                Count = 40
            };

            Supply supply4 = new Supply()
            {
                Date = RandomDate(random),
                Products = product4,
                Stocks = stock1,
                Count = 25
            };

            Supply supply5 = new Supply()
            {
                Date = RandomDate(random),
                Products = product5,
                Stocks = stock2,
                Count = 10
            };

            Supply supply6 = new Supply()
            {
                Date = RandomDate(random),
                Products = product6,
                Stocks = stock2,
                Count = 20
            };

            Supply supply7 = new Supply()
            {
                Date = RandomDate(random),
                Products = product7,
                Stocks = stock2,
                Count = 45
            };

            Supply supply8 = new Supply()
            {
                Date = RandomDate(random),
                Products = product8,
                Stocks = stock3,
                Count = 300
            };

            Supply supply9 = new Supply()
            {
                Date = RandomDate(random),
                Products = product9,
                Stocks = stock3,
                Count = 8
            };

            Supply supply10 = new Supply()
            {
                Date = RandomDate(random),
                Products = product10,
                Stocks = stock3,
                Count = 100
            };

            Supply supply11 = new Supply()
            {
                Date = RandomDate(random),
                Products = product2,
                Stocks = stock3,
                Count = 20
            };

            Supply supply12 = new Supply()
            {
                Date = RandomDate(random),
                Products = product8,
                Stocks = stock1,
                Count = 2000
            };

            db.Manufacturers.Add(manufacturer1);
            db.Manufacturers.Add(manufacturer2);
            db.Manufacturers.Add(manufacturer3);

            db.Products.Add(product1);
            db.Products.Add(product2);
            db.Products.Add(product3);
            db.Products.Add(product4);
            db.Products.Add(product5);
            db.Products.Add(product6);
            db.Products.Add(product7);
            db.Products.Add(product8);
            db.Products.Add(product9);
            db.Products.Add(product10);

            db.Stocks.Add(stock1);
            db.Stocks.Add(stock2);
            db.Stocks.Add(stock3);

            db.Supply.Add(supply1);
            db.Supply.Add(supply2);
            db.Supply.Add(supply3);
            db.Supply.Add(supply4);
            db.Supply.Add(supply5);
            db.Supply.Add(supply6);
            db.Supply.Add(supply7);
            db.Supply.Add(supply8);
            db.Supply.Add(supply9);
            db.Supply.Add(supply10);
            db.Supply.Add(supply11);
            db.Supply.Add(supply12);
          
            db.SaveChanges();
        }

        static void Queries()
        {  
            CSharpEntities db = new CSharpEntities();

            // 1 Вивести перелік всіх продуктів

            Console.WriteLine("1 Перелiк всiх продуктiв:\n");

            var Query1 = from product in db.Products
                         select product;

            foreach (var product in Query1)
            {
                Console.WriteLine(product.Name + ": " + product.Price + "$");
            }

            // 2 Вивести список виробників, назва яких закiнчується на 'n'

            Console.WriteLine("\n2 Виробники, назва яких закiнчується на 'n':\n");

            var Query2 = from manufacturer in db.Manufacturers
                         where manufacturer.Name.EndsWith("n")
                         select manufacturer;

            foreach (var manufacturer in Query2)
            {
                Console.WriteLine(manufacturer.Name);
            }

            // 3 Вивести список виробників та продуктів, які вони виробляють

            Console.WriteLine("\n3 Список виробникiв та продуктiв, якi вони виробляють:\n");

            var Query3 = from manufacturer in db.Manufacturers
                         join product in db.Products
                         on manufacturer equals product.Manufacturers into table
                         select new { m = manufacturer.Name, table };

            foreach (var el in Query3)
            {
                Console.WriteLine("\n" + el.m + ":");
                foreach (var el1 in el.table)
                {
                    Console.WriteLine("\t\t" + el1.Name);
                }
            }

            // 4 Вивести поставки згруповані по складам

            Console.WriteLine("\n4 Поставки згрупованi по складам:\n");

            var Query4 = from supply in db.Supply
                         group supply by supply.Stocks into table
                         select new { Key = table.Key, table };

            foreach (var el in Query4)
            {
                Console.WriteLine(el.Key.Name + ":");
                foreach (var el1 in el.table)
                {
                    Console.WriteLine("\tproduct: " + el1.Products.Name + ", count: "+ el1.Count +", date: "+ el1.Date.ToShortDateString());
                }
            }

            // 5 Вивести список виробників, в яких хоча б в одного продукту назва закінчується на 'e'

            Console.WriteLine("\n5 Виробники, в яких хоча б в одного продукту назва закiнчується на 'e':\n");

            var Query5 = (from manufacturer in db.Manufacturers
                          join product in db.Products
                          on manufacturer equals product.Manufacturers
                          where product.Name.EndsWith("e")
                          select manufacturer).Distinct();

            foreach (var manufacturer in Query5)
            {
                Console.WriteLine(manufacturer.Name);
            }

            // 6 Вивести всі продукти відсортовані по імені

            Console.WriteLine("\n6 Всi продукти вiдсортованi по iменi:\n");

            var Query6 = from product in db.Products
                         join manufacturer in db.Manufacturers
                         on product.Manufacturers equals manufacturer
                         orderby product.Name
                         select new { product, manufacturer.Name };

            foreach (var el in Query6)
            {
                Console.WriteLine(el.product.Name + ", manufacturer: " + el.Name + ", " + el.product.Price + "$");
            }

            // 7 Вивести загальну ціну по продуктам на складі

            Console.WriteLine("\n7 Загальна цiна по продуктам на складах:\n");

            var Query7 = from supply in
                             (
                             from supply in db.Supply
                             group supply by new { supply.Stocks, supply.Products } into table
                             select new { table.Key, count = table.Sum(supply => supply.Count) }
                             )
                             group supply by supply.Key.Stocks into table2
                         select new { table2.Key, table2 };

            foreach (var el in Query7)
            {
                Console.WriteLine("\n" + el.Key.Name + ":");
                foreach (var el1 in el.table2)
                {
                    Console.WriteLine("\t\t" + el1.Key.Products.Name +": "+ el1.Key.Products.Price*el1.count+"$");
                }
            }
        }

        static void Main(string[] args)
        {
            //InitData();
            Queries();
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}
