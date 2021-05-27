using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HairdressingStudio.Services
{
    public class WeekdayGenerator
    {
        public DateTime StartWeek { get; set; }
        public DateTime EndWeek { get; set; }

        public WeekdayGenerator(DateTime day)
        {
            int dayOfWeek = (int)day.DayOfWeek;
            Console.WriteLine(dayOfWeek);
            int dateAdd = 0;
            int dateSubtract = 0;

            switch (dayOfWeek)
            {
                case 1:
                    dateAdd = 6;
                    break;
                case 2:
                    dateAdd = 5;
                    dateSubtract = 1;
                    break;
                case 3:
                    dateAdd = 4;
                    dateSubtract = 2;
                    break;
                case 4:
                    dateAdd = 3;
                    dateSubtract = 3;
                    break;
                case 5:
                    dateAdd = 2;
                    dateSubtract = 4;
                    break;
                case 6:
                    dateAdd = 1;
                    dateSubtract = 5;
                    break;
                case 7:
                    dateSubtract = 6;
                    break;
            }

            StartWeek = day.AddDays(-dateSubtract);
            EndWeek = day.AddDays(dateAdd);
        }
    }
}
