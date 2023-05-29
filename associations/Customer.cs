using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace associations
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string City { get; set; }
        public string Adress { get; set; }

        public Customer() { }

        public override string ToString()
        {
            return $"Id: {CustomerId}, \n" +
                $" Name: {CustomerName}, \n" +
                $" City: {City}, \n" +
                $" Adress: {Adress} \n";
        }

        public static void Added(object? sender)
        {
            Console.WriteLine($"Добавлен новый покупатель! {sender}");
        }
    }
}
