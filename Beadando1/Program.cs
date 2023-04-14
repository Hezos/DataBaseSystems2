
using System.Text.Json;
using Beadando1.DataHandling;
using System.IO;
using Beadando1.Model;

namespace Beadando1
{
    internal class Program
    {
        public static List<string> TableNames = new List<string>()
        {
            "Owner", "Customer", "Deliver", "Delivery", "Order", "PickUpProduct", "Product", "ProductPicture", "productrating", "Upload"
        };

        public static DataFromFile dataClass = new DataFromFile();

        public static void Main(string[] args)
        {
            Console.WriteLine("Program started!");
            string data = "";
            dataClass = new DataFromFile();
            GiveData();
            data = JsonSerializer.Serialize(dataClass);
            //File.WriteAllText("Data.txt",data);
            SQLhandler handler = new SQLhandler();
            dataClass = JsonSerializer.Deserialize<DataFromFile>(File.ReadAllText("Data.txt"));
            bool loggedIn = false;
            while (!loggedIn)
            {
                loggedIn = Login();
            }
           
            //StartUp(handler);
           ComputeValues(handler);


            Console.WriteLine("Program ended.");
        }

        public static void StartUp(SQLhandler handler)
        {
            CreateTables(handler);
            AlterTables(handler);
            handler.InsertTables(dataClass);
        }

        public static bool Login()
        {
            Console.Clear();
            Console.WriteLine("Please give me a username!\n");
            string userName = Console.ReadLine();
            if (userName == "Admin")
            {
                Console.WriteLine("Enter Password please!\n");
                string password = Console.ReadLine();
                if (password == "Empty")
                {
                    Console.WriteLine("The following SQL queries are calculated:");
                    return true;
                }
                else
                {
                    Console.WriteLine("Restart the application!");
                    return false;
                }
            }
            else
            {
                Console.WriteLine("Restart the apllication");
                return false;
            }
        }

        public static void CreateTables(SQLhandler handler)
        {
            foreach (string name in TableNames)
            {
                handler.CreateTable(name);
            }
        }

        public static void AlterTables(SQLhandler handler)
        {
            foreach (string name in TableNames)
            {
                handler.AlterTable(name);
            }
        }

        public static void InsertAll()
        {

        }

        public static void GiveOwnerData()
        {
            dataClass.owners = new List<Owner>();
            dataClass.owners.Add(new Owner(1,DateTime.Parse("03/12/1990"),"Péter","Sárosi",3901,2,"Szeged","Haladás",1));
            dataClass.owners.Add(new Owner(2, DateTime.Parse("11/02/1980"), "Balázs", "Berki", 3301, 18, "Debrecen", "Birkés", 1));
            dataClass.owners.Add(new Owner(3, DateTime.Parse("08/11/2000"), "Szabolcs", "Vadász", 2901, 24, "Győr", "Kenderföld", 3));
            dataClass.owners.Add(new Owner(4, DateTime.Parse("08/12/1998"), "Dávid", "Szepesi", 2023, 43, "Eger", "Béke", 4));
            dataClass.owners.Add(new Owner(5, DateTime.Parse("04/06/1996"), "András", "Fekete", 2954, 54, "Debrecen", "Kántor", 5));
        }

        public static void GiveDeliveryData()
        {
            dataClass.deliveries = new List<Delivery>();
            dataClass.deliveries.Add(new Delivery(1, DateTime.Parse("05/09/2020")));
            dataClass.deliveries.Add(new Delivery(2, DateTime.Parse("06/09/2018")));
            dataClass.deliveries.Add(new Delivery(3, DateTime.Parse("12/07/2005")));
            dataClass.deliveries.Add(new Delivery(4, DateTime.Parse("08/09/2010")));
            dataClass.deliveries.Add(new Delivery(5, DateTime.Parse("10/05/2015")));
        }

        public static void GiveCustomerData()
        {
            dataClass.customers = new List<Customer>();
            dataClass.customers.Add(new Customer(1, "Viktor", "Sárosi", 3821, 1, "Haladás", "Szeged"));
            dataClass.customers.Add(new Customer(2, "Viktor", "Palencsár", 1221, 35, "Birkés", "Nyíregyháza"));
            dataClass.customers.Add(new Customer(3, "Béla", "Vecser", 1231, 23, "Szentlőrincz", "Abaújszántó"));
            dataClass.customers.Add(new Customer(4, "Sándor", "Keresztes", 2141, 45, "Arad", "Tiszalúc"));
            dataClass.customers.Add(new Customer(5, "Valéria", "Farkas", 2311, 76, "Remény", "Taktaszada"));
        }

        public static void GiveProductsData()
        {
            dataClass.products = new List<Product>();
            dataClass.products.Add(new Product(1, "Régi_Fuvola"));
            dataClass.products.Add(new Product(2, "Egyedi_festmény"));
            dataClass.products.Add(new Product(3, "Autó_relikvia"));
            dataClass.products.Add(new Product(4, "Örökölt_bútor"));
            dataClass.products.Add(new Product(5, "Módosított_gép"));
        }

        public static void GiveProduct_PictureData()
        {
            dataClass.picture = new List<ProductPicture>();
            dataClass.picture.Add(new ProductPicture(2,1));
            dataClass.picture.Add(new ProductPicture(3, 2));
            dataClass.picture.Add(new ProductPicture(1, 4));
            dataClass.picture.Add(new ProductPicture(5, 4));
            dataClass.picture.Add(new ProductPicture(2, 1));
        }

        public static void GiveUploadData()
        {
            dataClass.uploads = new List<Upload>();
            dataClass.uploads.Add(new Upload(DateTime.Parse("10/04/2001"), 1,1));
            dataClass.uploads.Add(new Upload(DateTime.Parse("11/10/2003"), 2, 2));
            dataClass.uploads.Add(new Upload(DateTime.Parse("06/05/2004"), 3, 3));
            dataClass.uploads.Add(new Upload(DateTime.Parse("08/12/2002"), 4, 4));
            dataClass.uploads.Add(new Upload(DateTime.Parse("08/04/2001"), 5, 5));
        }


        public static void GiveProduct_RateData()
        {
            dataClass.rates = new List<ProductRating>();
            dataClass.rates.Add(new ProductRating("Megfelelő", 1));
            dataClass.rates.Add(new ProductRating("Szuper", 1));
            dataClass.rates.Add(new ProductRating("Javítandó", 2));
            dataClass.rates.Add(new ProductRating("Gyűjtőknek", 3));
            dataClass.rates.Add(new ProductRating("Gyűjtőknek", 4));
            dataClass.rates.Add(new ProductRating("Gyűjtőknek", 5));
        }

        public static void GiveProduct_PickUpData()
        {
            dataClass.pickUps = new List<PickUpProduct>();
            dataClass.pickUps.Add(new PickUpProduct( 1,1, "Sárospatak"));
            dataClass.pickUps.Add(new PickUpProduct(2, 2, "Vérmező"));
            dataClass.pickUps.Add(new PickUpProduct(3, 3, "Abaújszántó"));
            dataClass.pickUps.Add(new PickUpProduct(4, 4, "Bőcs"));
            dataClass.pickUps.Add(new PickUpProduct(5, 5, "Nyíregyháza"));
        }

        public static void GiveProduct_DeliverData()
        {
            dataClass.delivers = new List<Deliver>();
            dataClass.delivers.Add(new Deliver(1, 1, "Miskolc"));
            dataClass.delivers.Add(new Deliver(2, 2, "Veszprém"));
            dataClass.delivers.Add(new Deliver(3, 3, "Hernádnémeti"));
            dataClass.delivers.Add(new Deliver(4, 4, "Abaújszántó"));
            dataClass.delivers.Add(new Deliver(5, 5, "Felsőzsolca"));
            dataClass.delivers.Add(new Deliver(2, 3, "Pest"));
        }

        public static void Give_OrderData()
        {
            dataClass.orders = new List<Order>();
            dataClass.orders.Add(new Order(DateTime.Parse("01/02/2020"), 1, 1));
            dataClass.orders.Add(new Order(DateTime.Parse("11/07/2019"), 2, 2));
            dataClass.orders.Add(new Order(DateTime.Parse("09/05/2021"), 3, 3));
            dataClass.orders.Add(new Order(DateTime.Parse("10/09/2018"), 4, 4));
            dataClass.orders.Add(new Order(DateTime.Parse("12/12/2020"), 5, 5));
        }

        public static void GiveData()
        {
            GiveProductsData();
            GiveOwnerData();
            GiveCustomerData();
            GiveDeliveryData();
            GiveProduct_RateData();
            GiveUploadData();
            Give_OrderData();
            GiveProduct_PictureData();
            GiveProduct_PickUpData();
            GiveProduct_DeliverData();
            
        }

        public static void ComputeValues(SQLhandler handler)
        {
            Console.WriteLine();
            Console.WriteLine("Cursor handling is done by foreach loops");
            Console.WriteLine("The name of customers with Street names that begin with Sz hungarian letter:");
            foreach (string item in handler.GetSelectQuery("*", "Customer", "street LIKE 'Sz%'"))
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            Console.WriteLine("The Owners which Street's is higher than 2000:");
            foreach (string item in handler.GetSelectQuery("*", "Owner", "street > 2000"))
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            Console.WriteLine("The rate of the products:");
             foreach (string item in handler.GetSelectQuery("rating", "productrating", string.Empty))
             {
                 Console.WriteLine(item);
             }
            Console.WriteLine();

            Console.WriteLine("The deliveries which goes to Veszprém:");
              foreach (string item in handler.GetSelectQuery("*","Delivery", "JOIN Deliver ON Delivery.did = Deliver.did WHERE Deliver.deliveryplace LIKE 'Veszprém'"))
              {
                  Console.WriteLine(item);
              }

            Console.WriteLine();

            Console.WriteLine("The birth date of the owners:");
            foreach (string item in handler.GetSelectQuery("date_of_birth", "Owner",String.Empty))
            {
                Console.WriteLine(item);
            }
            
            Console.WriteLine();

            
            Console.WriteLine("The owners of the products which was picked up from Nyíregyháza:");
            foreach(var item in handler.GetSelectQuery("firstname, lastname","Owner", "JOIN roductpickup ON roductpickup.oid = Owner.id WHERE pickupplace='Nyíregyháza'"))
            {
                Console.WriteLine(item);
            }
            

            Console.WriteLine();

            Console.WriteLine("The description of products which have more then 1 pictures:");
            foreach (var item in handler.GetSelectQuery("description", "Product", "pid in (SELECT count(*) FROM product_picture GROUP BY pid HAVING count(*) > 1)"))
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Name of the tables");
            foreach (var item in TableNames)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Please enter a table name!\n");
            string tableName = Console.ReadLine();
            Console.WriteLine("Metadata of a table:");
            foreach (var item in handler.GetTableMetaData(tableName))
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            Console.WriteLine("Transactions:");
            Console.WriteLine("Please give an SQLite command!\n");
            string command1 = Console.ReadLine();
            Console.WriteLine("Please give me a second command!\n");
            string command2 = Console.ReadLine();
            Console.WriteLine("Do you want a transaction with a savepoint?(yes/no)\n");
            string choice = Console.ReadLine();
            if (choice == "yes")
            {
                handler.SetTransactionWithSavePoint(command1, command2);
            }
            else if (choice == "no")
            {
                handler.SetTransaction(command1, command2);
            }
            else
            {
                Console.WriteLine("Please restart the application!");
            }
        }
    }
}