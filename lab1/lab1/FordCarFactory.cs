using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    class FordCarFactory : ICarFactory
    {
        public IMinivan CreateMinivan()
        {
            return new FordMinivan();
        }

        public IOffRoadCar CreateOffRoadCar()
        {
            return new FordOffRoadCar();
        }

        public ISportCar CreateSportCar()
        {
            return new FordSportCar();
        }

        public IBus CreateBus()
        {
            return new FordBus();
        }

        public IMinivan CreateMinivan(Colors Color)
        {
            return new FordMinivan(Color);
        }

        public IOffRoadCar CreateOffRoadCar(Colors Color)
        {
            return new FordOffRoadCar(Color);
        }

        public ISportCar CreateSportCar(Colors Color)
        {
            return new FordSportCar(Color);
        }

        public IBus CreateBus(Colors Color)
        {
            return new FordBus(Color);
        }
    }
}
