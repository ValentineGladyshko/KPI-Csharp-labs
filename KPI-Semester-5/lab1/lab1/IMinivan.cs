using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    enum SizesOfTrunk
    {
        Small,
        Medium,
        Large
    }
    interface IMinivan
    {
        string Name
        {
            get;
            set;
        }

        int CountOfPassangers
        {
            get;
            set;
        }

        SizesOfTrunk SizeOfTrunk
        {
            get;
            set;
        }

        int Price
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
