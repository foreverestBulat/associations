using associations;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

// Доработать проект из первого семестра “Ассоциации”.
// Добавить интерфейс по сохранению состояния приложения
// (сериализация всей информации в файле).
// Реализовать два класса реализующих данный интерфейс (json и xml).
// При изменении состояния объекта, вызывать событие.
// Подписчики записывают данные в файл.
// При запуске приложения, считывать данные из файла. (3 балла)



namespace associations
{
    public class Program
    {
        public static void Main()
        {

            MyShop shop = new MyShop();
            shop.Init();



            //string fileName = "products.json";
            //MyShop shop = new MyShop();

            //shop.Init();


            ////AllowTrailingCommas:
            ////  устанавливает, надо ли добавлять после последнего элемента в json запятую.
            ////  Если равно true, запятая добавляется

            ////DefaultIgnoreCondition:
            ////  устанавливает, будут ли сериализоваться/десериализоваться
            ////  в json свойства со значениями по умолчанию

            ////IgnoreReadOnlyProperties:
            ////  аналогично устанавливает, будут ли сериализоваться свойства,
            ////  предназначенные только для чтения

            ////WriteIndented:

            //var options = new JsonSerializerOptions
            //{
            //    Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
            //    WriteIndented = true,
            //    //AllowTrailingCommas = true,
            //};

            //string json = JsonSerializer.Serialize(shop, options);

            ////Console.WriteLine(json);


            //var c = shop;

            //Console.WriteLine(c.GetType());

            //using (var sw = new StreamWriter(file))
            //{
            //    sw.WriteLine(json);
            //}




            // ************************************


            //var shop = MyShop.ReadFileJson();

            //shop.Notify += Product.Added;
            //shop.AddProduct(6, "Анигири", 100m, 500);

            //var prod0 = shop.Products[0];
            //var prod1 = shop.Products[1];

            //Product.Notify += Product.Changed;

            //prod0.Price = 100m;
            //prod1.Price = 120m;

            //shop.Notify -= Product.Added;
            //shop.Notify += Customer.Added;

            //shop.AddCustomer(4, "Булат", "Казань", "ДУ");
            //shop.AddCustomer(5, "Ильнур", "Казань", "ДУ");

            //Order.Notify += Order.Changed;

            //var order = shop.Orders[0];

            //order.Count = 20;


            //shop.Notify += Product.Removed;

            //shop.RemoveProducts(4);

            //shop.WriteInFileUseJson();
        }

        static void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}

//MyShop shop = new MyShop();

//shop.Init();

//while (true)
//{
//    Console.WriteLine("Выберите пункт меню: ");
//}

//shop.PrintProducts();