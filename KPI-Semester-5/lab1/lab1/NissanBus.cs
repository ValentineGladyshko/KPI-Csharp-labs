using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    class NissanBus : IBus
    {
        private string Name;
        private int CountOfPassangers;
        private int Price;
        private Colors Color;

        public NissanBus()
        {
            Name = "Nissan Bus";
            CountOfPassangers = 90;
            Price = 150000;
            this.Color = Colors.Cyan;
        }

        public NissanBus(Colors Color)
        {
            Name = "Nissan Bus";
            CountOfPassangers = 90;
            Price = 150000;
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
