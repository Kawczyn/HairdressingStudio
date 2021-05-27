using AutoMapper;
using HairdressingStudio.DatabaseContext;
using HairdressingStudio.Models;
using HairdressingStudio.Services.Interfaces;
using HairdressingStudio.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HairdressingStudio.Services
{
    public class StylistsWorkingHoursData : IStylistsWorkingHoursData
    {
        private readonly HairdressingStudioContext _context;
        private readonly IMapper _mapper;
        public StylistsWorkingHoursData(HairdressingStudioContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<StylistsWorkingHoursDTO> GetAllStylistsWorkingHours(int stylistId)
        {
            var result = _context.StylistsWorkingHours.Where(x => x.StylistId == stylistId);
            return _mapper.Map<List<StylistsWorkingHoursDTO>>(result);

        }
    }
}
