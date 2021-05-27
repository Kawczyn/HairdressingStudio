using HairdressingStudio.Models;
using HairdressingStudio.Services.Interfaces;
using HairdressingStudio.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HairdressingStudio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly IClientsData _clientsData;
        public ClientController(IClientsData clientsData)
        {
            _clientsData = clientsData;
        }

        [HttpGet("{phoneNumber}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetClient_PhoneNumber(int phoneNumber)
        {
            var result = _clientsData.GetClient_PhoneNumber(phoneNumber);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost(Name = "AddClient")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Create([FromBody] ClientsDTO newClient)
        {
            if (_clientsData.IsClientExist(newClient))
                return BadRequest();

            var result = _clientsData.AddClient(newClient);
            return StatusCode(201);
        }
    }
}
