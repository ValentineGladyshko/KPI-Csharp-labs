using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    class AudiMinivan : IMinivan
    {
        private string Name;
        private int CountOfPassangers;
        private SizesOfTrunk SizeOfTrunk;
        private int Price;
        private Colors Color;

        public AudiMinivan()
        {
            Name = "Audi A3 Van";
            CountOfPassangers = 5;
            SizeOfTrunk = SizesOfTrunk.Medium;
            Price = 50000;
            this.Color = Colors.Orange;
        }

        public AudiMinivan(Colors Color)
        {
            Name = "Audi A3 Van";
            CountOfPassangers = 5;
            SizeOfTrunk = SizesOfTrunk.Medium;
            Price = 50000;
            this.Color = Color;
        }

        string IMinivan.Name { get => Name; set => Name = value; }
        int IMinivan.CountOfPassangers { get => CountOfPassangers; set => CountOfPassangers = value; }
        SizesOfTrunk IMinivan.SizeOfTrunk { get => SizeOfTrunk; set => SizeOfTrunk = value; }
        int IMinivan.Price { get => Price; set => Price = value; }
        Colors IMinivan.Color { get => Color; set => Color = value; }

        public void GetInfo()
        {
            Console.WriteLine("\n====================\nMinivan:\nName: {0}\nCount Of Passangers: {1}\n" +
                "Size Of Trunk: {2}\nPrice: {3}$\nColor: {4}" +
                "\n====================\n", Name, CountOfPassangers, SizeOfTrunk, Price, Color);
        }
    }
}
