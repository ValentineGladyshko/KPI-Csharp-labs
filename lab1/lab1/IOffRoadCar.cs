using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    enum DriveUnitType
    {
        FourWheelDrive,
        FrontWheelDrive,
        RearDrive
    }

    interface IOffRoadCar
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

        DriveUnitType DriveUnit
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
