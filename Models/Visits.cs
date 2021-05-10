using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HairdressingStudio.Models
{
    public class Visits
    {
        public int Id { get; set; }
        public DateTime ServiceDate { get; set; }

        public int ClientId { get; set; }
        public int StylistId { get; set; }
        public int ServiceId { get; set; }
        public bool IsCanceled { get; set; }
        public string ServiceComment { get; set; }

        public Stylists Stylists { get; set; }
        public HairdressingServices HairdressingServices { get; set; }
        public Clients Clients { get; set; }
    }
}
