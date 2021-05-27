using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HairdressingStudio.ViewModels
{
    public class HairdressingServicesDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsCombining { get; set; }
        public decimal ServiceTime { get; set; }
        public decimal Price { get; set; }
        public bool IsActive { get; set; }
    }
}
