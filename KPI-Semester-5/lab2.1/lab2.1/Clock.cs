using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2._1
{
    class Clock
    {
        private string Time;
        public Clock()
        {
            Time = "";
        }

        public void SetTime(DigitalClock clock)
        {
            Time = String.Format("{0}h:{1}m:{2}s", clock.GetHours(), clock.GetMinutes(), clock.GetSeconds());
        }

        public void ShowTime()
        {
            Console.WriteLine("Time: {0}", Time);
        }
    }
}
