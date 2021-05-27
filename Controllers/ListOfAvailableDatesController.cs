using HairdressingStudio.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HairdressingStudio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ListOfAvailableDatesController : ControllerBase
    {
        private readonly IListOfAvailableDates _listOfAvailableDates;

        public ListOfAvailableDatesController(IListOfAvailableDates listOfAvailableDates)
        {
            _listOfAvailableDates = listOfAvailableDates;
        }

        [HttpGet("{stylistId},{selectedDay},{hairdressingServicesId}")]
        public IActionResult GetListOfAvailableDates(int stylistId, DateTime selectedDay, int hairdressingServicesId)
        {
            var result = _listOfAvailableDates.GenerateListOfAvailableDates(stylistId, selectedDay, hairdressingServicesId);
            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}
