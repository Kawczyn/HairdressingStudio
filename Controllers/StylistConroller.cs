using AutoMapper;
using HairdressingStudio.Repositories.Interfaces;
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
    public class StylistConroller : ControllerBase
    {
        private readonly IStylistsData _stylistData;

        public StylistConroller(IStylistsData stylistData)
        {
            _stylistData = stylistData;
        }

        [HttpGet(Name = "GetAllStylists")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetAllStylists()
        {

            var result = _stylistData.GetActiveStylists();

            if (result == null)
                return NotFound();

            return Ok(result);
        }

    }
}
