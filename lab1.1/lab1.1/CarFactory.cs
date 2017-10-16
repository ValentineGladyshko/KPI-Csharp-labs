using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1._1
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
