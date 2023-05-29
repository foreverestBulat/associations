using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Unicode;
using System.Threading.Tasks;
using System.Xml.Serialization;



namespace associations
{
    [Serializable]
    public class MyShop
    {
        
        public List<Product> Products { get; set; } = new List<Product>();
        public List<Customer> Customers { get; set; } = new List<Customer>();
        public List<Order> Orders { get; set; } = new List<Order>();


        public MyShop() { }
        
        public void Init()
        {
            //Orders.Clear();
            Products.Add(new Product()
            {
                ProductId = 1,
                Name = "Яблоки",
                Price = 80m,
                ProductCount = 1000
            });

            Products.Add(new Product()
            {
                ProductId = 2,
                Name = "Бананы",
                Price = 80m,
                ProductCount = 1000
            });

            Products.Add(new Product()
            {
                ProductId = 3,
                Name = "Виноград",
                Price = 80m,
                ProductCount = 1000
            });

            Products.Add(new Product()
            {
                ProductId = 4,
                Name = "Мандарины",
                Price = 80m,
                ProductCount = 1000
            });


            Customers.Add(new Customer()
            {
                CustomerId = 1,
                CustomerName = "Иван",
                City = "Moscow",
                Adress = "Кремлевская"
            });
            Customers.Add(new Customer()
            {
                CustomerId = 2,
                CustomerName = "Петр",
                City = "Казань",
                Adress = "Кремлевская"
            });
            Customers.Add(new Customer()
            {
                CustomerId = 3,
                CustomerName = "Саша",
                City = "Новый Уренгой",
                Adress = "Кремлевская"
            });
            Customers.Add(new Customer()
            {
                CustomerId = 4,
                CustomerName = "Кирилл",
                City = "Хабаровск",
                Adress = "Кремлевская"
            });


            Orders.Add(new Order()
            {
                OrderId = 1,
                OrderDate = new DateTime(2004, 11, 12),
                Amount = 160m,
                Count = 2,
                Customer = Customers[0],
                Product = Products[0],
            });
            Orders.Add(new Order()
            {
                OrderId = 2,
                OrderDate = new DateTime(2004, 5, 12),
                Amount = 240m,
                Count = 3,
                Customer = Customers[1],
                Product = Products[1],
            });
            Orders.Add(new Order()
            {
                OrderId = 3,
                OrderDate = new DateTime(2004, 1, 12),
                Amount = 320m,
                Count = 4,
                Customer = Customers[2],
                Product = Products[2],
            });
            Orders.Add(new Order()
            {
                OrderId = 4,
                OrderDate = new DateTime(2004, 8, 12),
                Amount = 400m,
                Count = 5,
                Customer = Customers[3],
                Product = Products[3],
            });

            //WriteInFileUseJson();

            //WriteInFileUseXml();
        }
        public void ShowShop()
        {
            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };

            string json = JsonSerializer.Serialize(this, options);
            Console.WriteLine(json);
        } 

        public static MyShop ReadFileJson(string file = "shop.json")
        {
            MyShop? shop;

            using (var fs = new FileStream(file, FileMode.OpenOrCreate))
            {
                shop = JsonSerializer.Deserialize<MyShop>(fs);
            }

            return shop;
        }

        public void WriteInFileUseJson(string file = "shop.json")
        {
            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };

            string json = JsonSerializer.Serialize(this, options);

            Console.WriteLine(json);

            using (var sw = new StreamWriter(file))
            {
                sw.WriteLine(json);
            }
        }

        public void WriteInFileUseXml(string file = "shop.xml")
        {
            XmlSerializer serializer = new XmlSerializer(typeof(MyShop)); //typeof(List<Product>)

            using (FileStream fs = new FileStream(file, FileMode.OpenOrCreate))
            {
                serializer.Serialize(fs, this);
            }
        }

        public static MyShop ReadFileXml(string file = "shop.xml")
        {
            XmlSerializer serializer = new XmlSerializer(typeof(MyShop)); //typeof(List<Product>)

            MyShop shop;

            using (var fs = new FileStream(file, FileMode.OpenOrCreate))
            {
                shop = serializer.Deserialize(fs) as MyShop;
            }

            return shop;
        }

        public void PrintAll()
        {
            Console.WriteLine(String.Join("\n", Products));

            Console.WriteLine(String.Join("\n", Customers));

            Console.WriteLine(String.Join("\n", Orders));
        }


        public void AddProduct(int id, string name, decimal price, int count)
        {
            Products.Add(new Product()
            {
                ProductId = id,
                Name = name,
                Price = price,
                ProductCount = count
            });

            Notify?.Invoke($"Добавлен {name}");
        }

        public void AddCustomer(int id, string name, string city, string adress)
        {
            Customers.Add(new Customer()
            {
                CustomerId = id,
                CustomerName = name,
                City = city,
                Adress = adress
            });

            Notify?.Invoke($"Добавлен(а) {name}");
        }

        public void RemoveProducts(int i)
        {
            if (i > Products.Count) throw new ArgumentException("Index out of range!");
            Notify?.Invoke($"Удален продукт {Products[i].Name}");
            Products.RemoveAt(i);

            //Notify?.Invoke($"Удален {}");
        }

        public delegate void ShopHandler(object message);
        public ShopHandler? Notify;
    }
}
