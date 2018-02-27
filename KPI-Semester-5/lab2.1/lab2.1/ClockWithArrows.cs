using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2._1
{
    class ClockWithArrows
    {
        public double TurnSecondArrow { get; protected set; }
        public double TurnMinuteArrow { get; protected set; }
        public double TurnHourArrow { get; protected set; }

        public ClockWithArrows()
        {
            TurnHourArrow = 0;
            TurnMinuteArrow = 0;
            TurnSecondArrow = 0;
        }

        public ClockWithArrows(double turnHourArrow, double turnMinuteArrow, double turnSecondArrow)
        {
            TurnHourArrow = ((turnSecondArrow + turnMinuteArrow * 60 + turnHourArrow * 720) / 720) % 720;
            TurnMinuteArrow = ((turnSecondArrow + turnMinuteArrow * 60 + turnHourArrow * 720) % 21600) / 60;
            TurnSecondArrow = ((turnSecondArrow + turnMinuteArrow * 60 + turnHourArrow * 720) % 360);
        }

        public void SetTime(int hours, int minutes, int seconds)
        {
            TurnHourArrow = ((double)(seconds * 6 + minutes * 360 + hours * 21600) / 720) % 720;
            TurnMinuteArrow = ((double)(seconds * 6 + minutes * 360 + hours * 21600) % 21600) / 60;
            TurnSecondArrow = ((double)(seconds * 6 + minutes * 360 + hours * 21600) % 360);
        }

        public override string ToString()
        {
            return "\n=========================\nClock With Arrows:\n\nTurn of Hour Arrow: " + TurnHourArrow +
                "°\nTurn of Minute Arrow: " + TurnMinuteArrow + "°\nTurn of Second Arrow: " +
                TurnSecondArrow + "°\n=========================\n";
        }
    }
}
