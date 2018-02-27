using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    class FordBus : IBus
    {
        private string Name;
        private int CountOfPassangers;
        private int Price;
        private Colors Color;

        public FordBus()
        {
            Name = "Ford Bus";
            CountOfPassangers = 48;
            Price = 90000;
            this.Color = Colors.Red;
        }

        public FordBus(Colors Color)
        {
            Name = "Ford Bus";
            CountOfPassangers = 48;
            Price = 90000;
            this.Color = Color;
        }

        string IBus.Name { get => Name; set => Name = value; }
        int IBus.CountOfPassangers { get => CountOfPassangers; set => CountOfPassangers = value; }
        int IBus.Price { get => Price; set => Price = value; }
        Colors IBus.Color { get => Color; set => Color = value; }

        public void GetInfo()
        {
            Console.WriteLine("\n====================\nBus:\nName: {0}\nCount Of Passangers: {1}\n" +
                "Price: {2}$\nColor: {3}\n====================\n", Name, CountOfPassangers, Price, Color);
        }
    }
}
