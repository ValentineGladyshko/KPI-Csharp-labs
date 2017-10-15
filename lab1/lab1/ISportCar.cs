using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    interface ISportCar
    {
        string Name
        {
            get;
            set;
        }

        int Price
        {
            get;
            set;
        }

        int MaxSpeed
        {
            get;
            set;
        }

        double AccelerationTo100km
        {
            get;
            set;
        }

        Colors Color
        {
            get;
            set;
        }

        void GetInfo();
    }
}
