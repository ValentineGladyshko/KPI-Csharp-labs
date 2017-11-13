using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2._1
{
    class DigitalClock
    {
        private int Hours;
        private int Minutes;
        private int Seconds;

        public DigitalClock()
        {
            Seconds = 0;
            Minutes = 0;
            Hours = 0;
        }

        public DigitalClock(int hours, int minutes)
        {
            Hours = (hours + minutes / 60) % 24;
            Minutes = minutes % 60;
            Seconds = 0;
        }

        public DigitalClock(int hours, int minutes, int seconds)
        {
            Hours = (hours + (minutes + seconds / 60) / 60) % 24;
            Minutes = (minutes + seconds / 60) % 60;
            Seconds = seconds % 60;
        }

        public virtual int GetSeconds()
        {
            return Seconds;
        }

        public virtual int GetMinutes()
        {
            return Minutes;
        }

        public virtual int GetHours()
        {
            return Hours;
        }

        public override string ToString()
        {
            return "\n=========================\nDigital Clock:\n\nHours: " + Hours + "\nMinutes: " +
                Minutes + "\nSeconds: " + Seconds + "\n=========================\n";
        }
    }
}
