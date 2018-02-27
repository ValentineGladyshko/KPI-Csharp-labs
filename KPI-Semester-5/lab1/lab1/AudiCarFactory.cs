using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    class AudiCarFactory : ICarFactory
    {
        public IMinivan CreateMinivan()
        {
            return new AudiMinivan();
        }

        public IOffRoadCar CreateOffRoadCar()
        {
            return new AudiOffRoadCar();
        }

        public ISportCar CreateSportCar()
        {
            return new AudiSportCar();
        }

        public IBus CreateBus()
        {
            return new AudiBus();
        }

        public IMinivan CreateMinivan(Colors Color)
        {
            return new AudiMinivan(Color);
        }

        public IOffRoadCar CreateOffRoadCar(Colors Color)
        {
            return new AudiOffRoadCar(Color);
        }

        public ISportCar CreateSportCar(Colors Color)
        {
            return new AudiSportCar(Color);
        }

        public IBus CreateBus(Colors Color)
        {
            return new AudiBus(Color);
        }
    }
}
