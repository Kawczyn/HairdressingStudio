
using AutoMapper;
using HairdressingStudio.DatabaseContext;
using HairdressingStudio.Services.Interfaces;
using HairdressingStudio.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HairdressingStudio.Services
{
    public class HairdressingServicesData : IHairdressingServicesData
    {
        private readonly HairdressingStudioContext _context;
        private readonly IMapper _mapper;

        public HairdressingServicesData(HairdressingStudioContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<HairdressingServicesDTO> GetAllHairdressingServices()
        {
            var result = _context.HairdressingServices.Where(x => x.IsActive == true).ToList();
            return _mapper.Map<List<HairdressingServicesDTO>>(result);
        }
    }
}
