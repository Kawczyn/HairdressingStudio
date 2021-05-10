using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HairdressingStudio.Models
{
    
    public class Stylists
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<HairdressingServices> HairdressingServices { get; set; } = new List<HairdressingServices>();
        public virtual ICollection<Visits> Visits { get; set; }
    }
}
