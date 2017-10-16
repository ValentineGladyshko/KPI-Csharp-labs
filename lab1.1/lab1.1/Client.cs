using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1._1
{
    enum Colors
    {
        White,
        Grey,
        Black,
        Red,
        Orange,
        Yellow,
        Green,
        Cyan,
        Blue,
        Purple
    }
    class Client
    {
        private ICarFactory CarFactory;

        public Client()
        {
            ChoiseCarFactory();
        }

        public void ChoiseCarFactory()
        {
            while (true)
            {
                Console.WriteLine("Enter your choise of Car Factory:\n1. Audi\n2. Ford\n3. Nissan");
                char choise = Convert.ToChar(Console.ReadLine());
                switch (choise)
                {
                    case '1':
                        CarFactory = new AudiCarFactory();
                        return;
                    case '2':
                        CarFactory = new FordCarFactory();
                        return;
                    case '3':
                        CarFactory = new NissanCarFactory();
                        return;
                    default:
                        Console.WriteLine("Incorrect input. Try again");
                        break;
                }
            }
        }

        public Colors ChoiseColor()
        {
            while (true)
            {
                Console.WriteLine("Enter your choise of Car Color:\n1. White\n2. Grey\n3. Black" +
                    "\n4. Red\n5. Orange\n6. Yellow\n7. Green\n8. Cyan\n9. Blue\n0. Purple");
                char choise = Convert.ToChar(Console.ReadLine());
                switch (choise)
                {
                    case '1':
                        return Colors.White;
                    case '2':
                        return Colors.Grey;
                    case '3':
                        return Colors.Black;
                    case '4':
                        return Colors.Red;
                    case '5':
                        return Colors.Orange;
                    case '6':
                        return Colors.Yellow;
                    case '7':
                        return Colors.Green;
                    case '8':
                        return Colors.Cyan;
                    case '9':
                        return Colors.Blue;
                    case '0':
                        return Colors.Purple;
                    default:
                        Console.WriteLine("Incorrect input. Try again");
                        break;
                }
            }
        }
        public void ChoiseCarType(Colors Color)
        {
            while (true)
            {
                Console.WriteLine("Enter your choise of Car Type:\n1. Minivan\n2. Off-Road Car\n3. SportCar\n4. Bus");
                char choise = Convert.ToChar(Console.ReadLine());
                switch (choise)
                {
                    case '1':
                        CarFactory.CreateMinivan(Color).GetInfo();
                        return;
                    case '2':
                        CarFactory.CreateOffRoadCar(Color).GetInfo();
                        return;
                    case '3':
                        CarFactory.CreateSportCar(Color).GetInfo();
                        return;
                    case '4':
                        CarFactory.CreateBus(Color).GetInfo();
                        return;
                    default:
                        Console.WriteLine("Incorrect input. Try again");
                        break;
                }
            }
        }
    }
}
