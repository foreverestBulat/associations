using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace associations
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }

        private int count;
        public int Count { 
            get { return count; }
            set 
            {
                count = value;
                Notify?.Invoke($"Количество изменено на {count}");
            }
        }

        private decimal amount;
        public decimal Amount { 
            get { return amount; }
            set 
            {
                amount = value;
                Notify?.Invoke($"Цена заказа изменена на {amount}");
            }
        }

        public Customer Customer { get; set; }
        public Product Product { get; set; }

        public Order() { }

        public override string ToString()
        {
            return $"OrderId: {OrderId}, \n" +
                $"OrderDate: {OrderDate}, \n" +
                $"Количество: {Count}, \n" +
                $"Цена: {Amount}, \n" +
                $"Покупатель: {Customer.CustomerName}, \n" +
                $"Продукт: {Product.Name} \n";
        }

        public static void Added(object? sender)
        {
            Console.WriteLine($"Добавлен новый заказ! {sender}");
        }

        public static void Changed(object? sender)
        {
            Console.WriteLine($"Изменены параметры заказа! {sender}");
        }


        public delegate void OrderHandler(object? sender);
        public static OrderHandler Notify;
    }
}
