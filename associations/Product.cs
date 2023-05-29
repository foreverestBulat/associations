using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace associations
{
    public class Product
    {
        
        public int ProductId { get; set; }
        public string Name { get; set; }


        private decimal price;
        public decimal Price { get { return price; } 
            set
            {
                price = value;
                Notify?.Invoke($"Цена изменена на {price}!");
            }
        }


        private int productCount;
        public int ProductCount { get { return productCount; }
            set
            {
                productCount = value;
                Notify?.Invoke($"Количество изменено на {productCount}!");
            }
        }

        public Product() { }

        public override string ToString()
        {
            return $"Товар: {Name}, \n" +
                $" Цена: {Price}, \n" +
                $" Количество: {ProductCount} \n";
        }

        public static void Changed(object sender)
        {
            Console.WriteLine($"Параметры продукта были изменены! {sender}");
            //Notify += Method;
            //return $"Параметры продукта были изменены! {sender}";
        }


        public static void Added(object? sender)
        {
            Console.WriteLine($"Добавлен новый продукт! {sender}");
        }

        public static void Removed(object? sender)
        {
            Console.WriteLine($"Продукт был удален! {sender}");
        }

        public delegate void ProductHandler(object? sender);
        public static ProductHandler? Notify;
    }
}
