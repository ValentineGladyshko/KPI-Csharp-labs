using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    class FordOffRoadCar : IOffRoadCar
    {
        private string Name;
        private DriveUnitType DriveUnit;
        private int Price;
        private Colors Color;

        public FordOffRoadCar()
        {
            Name = "Ford Raptor F-150";
            Price = 51000;
            DriveUnit = DriveUnitType.FourWheelDrive;
            this.Color = Colors.Grey;
        }

        public FordOffRoadCar(Colors Color)
        {
            Name = "Ford Raptor F-150";
            Price = 51000;
            DriveUnit = DriveUnitType.FourWheelDrive;
            this.Color = Color;
        }

        string IOffRoadCar.Name { get => Name; set => Name = value; }
        int IOffRoadCar.Price { get => Price; set => Price = value; }
        DriveUnitType IOffRoadCar.DriveUnit { get => DriveUnit; set => DriveUnit = value; }
        Colors IOffRoadCar.Color { get => Color; set => Color = value; }

        public void GetInfo()
        {
            Console.WriteLine("\n====================\nOff-Road Car:\nName: {0}\nPrice: {1}$\nDrive Unit: {2}\nColor: {3}" +
                "\n====================\n", Name, Price, DriveUnit, Color);
        }
    }
}
