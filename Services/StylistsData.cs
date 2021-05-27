using AutoMapper;
using HairdressingStudio.DatabaseContext;
using HairdressingStudio.Services.Interfaces;
using HairdressingStudio.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HairdressingStudio.Services
{
    public class StylistsData : IStylistsData
    {
        private readonly HairdressingStudioContext _context;
        private readonly IMapper _mapper;

        public StylistsData(HairdressingStudioContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }


        public List<StylistsDTO> GetActiveStylists()
        {
            var result = _context.StylistsModels.Where(x => x.IsActive == true).ToList();
            return _mapper.Map<List<StylistsDTO>>(result);
        }
    }
}