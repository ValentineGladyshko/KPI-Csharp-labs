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
        private int hours;
        private int minutes;
        private int seconds;

        int IClock.Hours { get => hours; set => hours = value; }
        int IClock.Minutes { get => minutes; set => minutes = value; }
        int IClock.Seconds { get => seconds; set => seconds = value; }

        public Clock()
        {
            seconds = 0;
            minutes = 0;
            hours = 0;
        }

        public Clock(int hours, int minutes)
        {
            this.hours = (hours + minutes / 60) % 24;
            this.minutes = minutes % 60;
            seconds = 0;
        }

        public Clock(int hours, int minutes, int seconds)
        {
            this.hours = (hours + (minutes + seconds / 60) / 60) % 24;
            this.minutes = (minutes + seconds / 60) % 60;
            this.seconds = seconds % 60;
        }

        public void ShowTime()
        {
            Console.WriteLine("Clock: {0}h:{1}m:{2}s", hours, minutes, seconds);
        }

        override public string ToString()
        {
            return "\n=========================\nClock:\n\nHours: " + hours + "\nMinutes: " +
                minutes + "\nSeconds: " + seconds + "\n=========================\n";
        }
    }
}
