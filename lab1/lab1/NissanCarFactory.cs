using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    class NissanCarFactory : ICarFactory
    {
        public IMinivan CreateMinivan()
        {
            return new NissanMinivan();
        }

        public IOffRoadCar CreateOffRoadCar()
        {
            return new NissanOffRoadCar();
        }

        public ISportCar CreateSportCar()
        {
            return new NissanSportCar();
        }

        public IBus CreateBus()
        {
            return new NissanBus();
        }

        public IMinivan CreateMinivan(Colors Color)
        {
            return new NissanMinivan(Color);
        }

        public IOffRoadCar CreateOffRoadCar(Colors Color)
        {
            return new NissanOffRoadCar(Color);
        }

        public ISportCar CreateSportCar(Colors Color)
        {
            return new NissanSportCar(Color);
        }

        public IBus CreateBus(Colors Color)
        {
            return new NissanBus(Color);
        }
    }
}
