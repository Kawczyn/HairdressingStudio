using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HairdressingStudio.ViewModels
{
    public class StylistsWorkingHoursDTO
    {
        public int Id { get; set; }
        public int StylistId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
