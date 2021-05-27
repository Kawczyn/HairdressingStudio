using HairdressingStudio.Models;
using HairdressingStudio.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HairdressingStudio.Services.Interfaces
{
    public interface IStylistsWorkingHoursData
    {
        List<StylistsWorkingHoursDTO> GetAllStylistsWorkingHours(int stylistId);
    }
}
