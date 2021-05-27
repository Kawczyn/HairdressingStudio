using HairdressingStudio.Services.Interfaces;
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
    public class HairdressingServicesController : ControllerBase
    {
        private readonly IHairdressingServicesData _hairdressingServicesData;

        public HairdressingServicesController(IHairdressingServicesData hairdressingServicesData)
        {
            _hairdressingServicesData = hairdressingServicesData;
        }

        [HttpGet(Name = "GetAllHairdressingServices")]
        [ProducesResponseType(StatusCodes.Status200OK)]//, Type = typeof(Stylists))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetAllHairdressingServices()
        {

            var result = _hairdressingServicesData.GetAllHairdressingServices();

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}
