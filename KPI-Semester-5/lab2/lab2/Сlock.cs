using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    interface IClock
    {
        int Hours
        {
            get;
            set;
        }


        int Minutes
        {
            get;
            set;
        }

        int Seconds
        {
            get;
            set;
        }

        void ShowTime();
    }

    class Clock : IClock
    {
        public int Hours { get; set; }
        public int Minutes { get; set; }
        public int Seconds { get; set; }

        public Clock()
        {
            Seconds = 0;
            Minutes = 0;
            Hours = 0;
        }

        public Clock(int hours, int minutes)
        {
            Hours = (hours + minutes / 60) % 24;
            Minutes = minutes % 60;
            Seconds = 0;
        }

        public Clock(int hours, int minutes, int seconds)
        {
            Hours = (hours + (minutes + seconds / 60) / 60) % 24;
            Minutes = (minutes + seconds / 60) % 60;
            Seconds = seconds % 60;
        }

        public void ShowTime()
        {
            Console.WriteLine("Clock: {0}h:{1}m:{2}s", Hours, Minutes, Seconds);
        }

        override public string ToString()
        {
            return "\n=========================\nClock:\n\nHours: " + Hours + "\nMinutes: " +
                Minutes + "\nSeconds: " + Seconds + "\n=========================\n";
        }
    }
}
