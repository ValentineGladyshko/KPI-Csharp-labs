using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2._1
{
    class ClockWithArrowsAdapter : DigitalClock
    {
        private ClockWithArrows Clock;

        public ClockWithArrowsAdapter(ClockWithArrows clock)
        {
            Clock = clock;
        }

        public override int GetSeconds()
        {
            return (int)(Clock.TurnSecondArrow / 6);
        }

        public override int GetMinutes()
        {
            return (int)(Clock.TurnMinuteArrow / 6);
        }

        public override int GetHours()
        {
            return (int)(Clock.TurnHourArrow / 30);
        }
    }
}
