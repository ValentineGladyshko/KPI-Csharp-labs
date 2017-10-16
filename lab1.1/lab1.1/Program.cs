/* LabWork 1
 * Variant 2
 * Valentne Gladyshko IP-51
 * 
 * Задача: Реализовать задачу “Заводы по производству автомобилей”.
 * Должна быть реализована возможность создавать автомобили
 * различных типов на разных заводах
 * 
 * Паттерн: Абстрактная фабрика
 * Абстрактная фабрика — это порождающий паттерн проектирования,
 * который позволяет создавать семейства связанных объектов,
 * не привязываясь к конкретным классам создаваемых объектов.*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client();
            client.ChoiseCarType(client.ChoiseColor());
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
