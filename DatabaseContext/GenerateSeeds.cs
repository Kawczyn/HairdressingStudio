using HairdressingStudio.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace HairdressingStudio.DatabaseContext
{
    public class GenerateSeeds
    {
        public List<StylistsWorkingHours> Generate()
        {
            DateTime newDate = new DateTime(2021, 05, 01, 00, 00, 00);

            int firstId = 1;
            int secondId = 2;
            int id = 1;

            var workingHours = new List<StylistsWorkingHours>();

            for (int i = 0; i < 150; i++)
            {
                string dzienTygodnia = newDate.ToString("dddd", new CultureInfo("pl-PL"));
                switch (dzienTygodnia)
                {
                    case "niedziela":
                        int temp = secondId;
                        secondId = firstId;
                        firstId = temp;
                        i++;
                        break;
                    case "poniedziałek":
                        i++;
                        break;
                    case "sobota":
                        workingHours.Add(new StylistsWorkingHours
                        {
                            Id = id,
                            StylistId = firstId,
                            StartDate = newDate.AddHours(8),
                            EndDate = newDate.AddHours(14)
                        });
                        workingHours.Add(new StylistsWorkingHours
                        {
                            Id = id + 1,
                            StylistId = secondId,
                            StartDate = newDate.AddHours(8),
                            EndDate = newDate.AddHours(14)
                        });
                        id++;
                        id++;
                        break;
                    default:
                        workingHours.Add(new StylistsWorkingHours
                        {
                            Id = id,
                            StylistId = firstId,
                            StartDate = newDate.AddHours(9),
                            EndDate = newDate.AddHours(17)
                        });
                        workingHours.Add(new StylistsWorkingHours
                        {
                            Id = id + 1,
                            StylistId = secondId,
                            StartDate = newDate.AddHours(13),
                            EndDate = newDate.AddHours(21)
                        });
                        id++;
                        id++;
                        break;
                }
                newDate = newDate.AddDays(1);
            }

            return workingHours;
        }
    }

}