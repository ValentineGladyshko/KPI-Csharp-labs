using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    abstract class ClockDecorator : IClock
    {
        protected IClock wrappee;

        public int Hours { get => wrappee.Hours; set => wrappee.Hours = value; }
        public int Minutes { get => wrappee.Minutes; set => wrappee.Minutes = value; }
        public int Seconds { get => wrappee.Seconds; set => wrappee.Seconds = value; }

        public ClockDecorator(IClock clock)
        {
            wrappee = clock;
        }

        abstract public void ShowTime();
    }

    class DigitalClockDecorator : ClockDecorator
    {
        public DigitalClockDecorator(IClock clock) : base(clock)
        {
        }

        public override void ShowTime()
        {
            Console.WriteLine("Digital Clock: {0}h:{1}m:{2}s", Hours, Minutes, Seconds);
        }

        override public string ToString()
        {
            return "\n=========================\nDigital Clock:\n\nHours: " + Hours + "\nMinutes: " +
                Minutes + "\nSeconds: " + Seconds + "\n=========================\n";
        }
    }

    class ClockWithArrowsDecorator : ClockDecorator
    {
        public ClockWithArrowsDecorator(IClock clock) : base(clock)
        {
            TurnHourArrow = (((Hours + (double) Minutes / 60 + (double)Seconds / 3600) % 12) * 30);
            TurnMinuteArrow = ((Minutes + (double)Seconds / 60) * 6);
            TurnSecondArrow = (Seconds * 6);
        }

        public double TurnSecondArrow { get; protected set; }
        public double TurnMinuteArrow { get; protected set; }
        public double TurnHourArrow { get; protected set; }

        public override void ShowTime()
        {
            Console.WriteLine("Clock With Arrows: {0}h:{1}m:{2}s", Hours, Minutes, Seconds);
        }

        public void ShowArrowTurns()
        {
            Console.WriteLine("\nArrow Turns: \n   Hour Arrow: {0}°\n   Minute Arrow: " +
                "{1}°\n   Second Arrow: {2}°", TurnHourArrow, TurnMinuteArrow, TurnSecondArrow);
        }

        override public string ToString()
        {
            return "\n=========================\nClock With Arrows:\n\nHours: " + Hours + "\nMinutes: " +
                Minutes + "\nSeconds: " + Seconds + "\nTurn of Hour Arrow: " + TurnHourArrow +
                "°\nTurn of Minute Arrow: " + TurnMinuteArrow + "°\nTurn of Second Arrow: " +
                TurnSecondArrow + "°\n=========================\n";
        }
    }
}
