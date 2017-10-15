using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    interface ICarFactory
    {
        IMinivan CreateMinivan();
        IOffRoadCar CreateOffRoadCar();
        ISportCar CreateSportCar();
        IBus CreateBus();
        IMinivan CreateMinivan(Colors Color);
        IOffRoadCar CreateOffRoadCar(Colors Color);
        ISportCar CreateSportCar(Colors Color);
        IBus CreateBus(Colors Color);
    }
}
