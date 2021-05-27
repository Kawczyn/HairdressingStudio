using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HairdressingStudio.ViewModels
{
    public class ListOfAvailableDatesDTO
    {
        public DateTime ServiceStartDate { get; set; }
        public DateTime ServiceEndDate { get; set; }
        public int DayOfWeek { get; set; }
        public int HairdressingServicesId { get; set; }
        public int StylistId { get; set; }
    }
}
