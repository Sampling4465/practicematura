using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Spg.Fachtheorie.Domain.DTOs;
using Spg.Fachtheorie.Domain.Model;
using Spg.Fachtheorie.Domain.Services;
using System.Linq;

namespace Spg.Fachtheorie.Aufgabe2.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DividerBoxLocationController : ControllerBase
    {

        private readonly DeviderBoxLocationService _sv;
        private readonly RoomCt _dbc;

        public DividerBoxLocationController(DeviderBoxLocationService sv, RoomCt dbc)
        {
            _sv = sv;
            _dbc = dbc;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public IActionResult GetAll()
        {
            return Ok(_sv.GetAll());
        }

        [HttpGet("{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetSingle(int Id)
        {

            var res = _sv.GetSingle(Id);
            if (res == null) { return NotFound(); }
            return Ok(res);
        }

        [HttpPost("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CreateOne(CreateDividerBoxLocationDto dto)
        {
            var res = _sv.Create(dto);
            if (res == null) return BadRequest();
            return Ok(res);
        }


        [HttpGet("/storage/{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GettAllFromStorageRoom(int Id)
        {

            var res = _dbc.DividerBoxLocations.Where(a => a.StorageRoomNavigation.Id == Id);
            var returnList = new List<DividerBoxLocationDto>();
            foreach (var location in res)
            {
                returnList.Add(_sv.GetSingle(location.Id));
            }

            return Ok(returnList);
        }

        [HttpGet("/storage/{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GettAllFromDevider(int Id)
        {

            var res = _dbc.DividerBoxLocations.Where(a => a.DividerBoxNavigation.Id == Id);
            var returnList = new List<DividerBoxLocationDto>();
            foreach (var location in res)
            {
                returnList.Add (_sv.GetSingle(location.Id));
            }

            return Ok(returnList);
        }


    }
}
