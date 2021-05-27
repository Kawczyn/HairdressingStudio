using HairdressingStudio.Models;
using HairdressingStudio.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HairdressingStudio.Services.Interfaces
{
    public interface IClientsData
    {
        ClientsDTO GetClient_PhoneNumber(int phoneNumber);
        ClientsDTO AddClient(ClientsDTO model);

        bool IsClientExist(ClientsDTO model);
    }
}
