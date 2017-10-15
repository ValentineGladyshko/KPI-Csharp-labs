using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
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
