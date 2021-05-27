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
    public class StylistsWorkingHoursController : ControllerBase 
    {
        private readonly IStylistsWorkingHoursData _stylistWorkingHoursData;
        public StylistsWorkingHoursController(IStylistsWorkingHoursData stylistsWorkingHoursData)
        {
            _stylistWorkingHoursData = stylistsWorkingHoursData;
        }

        [HttpGet("{stylistId}")]
        public IActionResult GetAllStylistsWorkingHours(int stylistId)
        {
            var result = _stylistWorkingHoursData.GetAllStylistsWorkingHours(stylistId);

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}
