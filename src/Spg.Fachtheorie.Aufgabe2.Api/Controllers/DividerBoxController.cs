using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Spg.Fachtheorie.Domain.DTOs;
using Spg.Fachtheorie.Domain.Model;
using Spg.Fachtheorie.Domain.Services;
using System.Linq.Expressions;

namespace Spg.Fachtheorie.Aufgabe2.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DividerBoxController : ControllerBase
    {
        
        private readonly DividerBoxService _sv;
        private readonly RoomCt _dbc;
        

        public DividerBoxController(DividerBoxService sv, RoomCt dbc)
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
        public IActionResult CreateOne(DividerBoxPostDto dto)
        {
            var res = _sv.Create(dto);
            if (res == null) return BadRequest();
            return Ok(res);
        }

        [HttpDelete("Id")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]


        public IActionResult DeleateOne(int Id)
        {
            try {
                _sv.Delete(Id);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return BadRequest();
            }
            
        }

        [HttpGet("/getNoLocations")]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public IActionResult GetDividerBoxLocations()
        {

            var res = _dbc.DividerBoxes.Where(a => a.DividerBoxLocations.Count == 0);
            var returns = new List<DividerBoxDto>();
            foreach (var item in res)
            {
                returns.Add(_sv.GetSingle(item.Id));
            }
            return Ok(returns);
        }

        [HttpGet("/getFloors/{floors}")]

        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]


        public IActionResult GetFloors(String floor )
        {
            if (String.IsNullOrEmpty(floor)) return BadRequest();

            var res = _dbc.DividerBoxes.Include(a => a.DividerBoxLocations).ThenInclude(a => a.StorageRoomNavigation).Where(a => a.DividerBoxLocations.Any( l => l.StorageRoomNavigation.Floor.Equals(floor)));
            var returns = new List<DividerBoxDto>();
            foreach (var item in res)
            {
                returns.Add(_sv.GetSingle(item.Id));
            }
            return Ok(returns);

        }

        [HttpGet("/getbuilding/{building}")]

        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetBuilding(String building)
        {
            if (String.IsNullOrEmpty(building)) return BadRequest();

            var res = _dbc.DividerBoxes.Include(a => a.DividerBoxLocations).ThenInclude(a => a.StorageRoomNavigation).Where(a => a.DividerBoxLocations.Any(l => l.StorageRoomNavigation.Building == building));
            var returns = new List<DividerBoxDto>();
            foreach (var item in res)
            {
                returns.Add(_sv.GetSingle(item.Id));
            }
            return Ok(returns);

        }
    }
}
