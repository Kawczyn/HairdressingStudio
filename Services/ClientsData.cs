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
    public class ClientsData : IClientsData
    {
        private readonly HairdressingStudioContext _context;
        private readonly IMapper _mapper;

        public ClientsData(HairdressingStudioContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ClientsDTO AddClient(ClientsDTO newClient)
        {
            var modelClient = _mapper.Map<Clients>(newClient);
            _context.Clients.Add(modelClient);
            _context.SaveChanges();

            return _mapper.Map<ClientsDTO>(modelClient);
        }

        public ClientsDTO GetClient_PhoneNumber(int phoneNumber)
        {
            var result = _context.Clients.Where(x => x.PhoneNumber == phoneNumber).FirstOrDefault();
            return _mapper.Map<ClientsDTO>(result);
        }

        public bool IsClientExist(ClientsDTO newClient)
        {
            if (_context.Clients.Any(x => x.FirstName == newClient.FirstName
                    && x.LastName == newClient.LastName
                    && x.PhoneNumber == newClient.PhoneNumber))
            {
                return true;
            }
            return false;
        }
    }
}
