﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    class AudiSportCar : ISportCar
    {
        private string Name;
        private int Price;
        private int MaxSpeed;
        private double AccelerationTo100km;
        private Colors Color;

        public AudiSportCar()
        {
            Name = "Audi R8 GT";
            Price = 250000;
            MaxSpeed = 320;
            AccelerationTo100km = 3.6;
            this.Color = Colors.White;
        }

        public AudiSportCar(Colors Color)
        {
            Name = "Audi R8 GT";
            Price = 250000;
            MaxSpeed = 320;
            AccelerationTo100km = 3.6;
            this.Color = Color;
        }

        string ISportCar.Name { get => Name; set => Name = value; }
        int ISportCar.Price { get => Price; set => Price = value; }
        int ISportCar.MaxSpeed { get => MaxSpeed; set => MaxSpeed = value; }
        double ISportCar.AccelerationTo100km { get => AccelerationTo100km; set => AccelerationTo100km = value; }
        Colors ISportCar.Color { get => Color; set => Color = value; }

        public void GetInfo()
        {
            Console.WriteLine("\n====================\nSportCar:\nName: {0}\nPrice: {1}$\nMaximum Speed: {2}km/h" +
                "\nAcceleration To 100 km/h: {3}s\nColor: {4}" +
                "\n====================\n", Name, Price, MaxSpeed, AccelerationTo100km, Color);
        }
    }
}
