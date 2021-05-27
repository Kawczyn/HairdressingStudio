using HairdressingStudio.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HairdressingStudio.Services.Interfaces
{
    public interface IHairdressingServicesData 
    {
        List<HairdressingServicesDTO> GetAllHairdressingServices();
    }
}
