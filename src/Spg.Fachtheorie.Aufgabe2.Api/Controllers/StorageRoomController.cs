using Microsoft.AspNetCore.Mvc;
using Spg.Fachtheorie.Domain.DTOs;
using Spg.Fachtheorie.Domain.DTOss;
using Spg.Fachtheorie.Domain.Model;
using Spg.Fachtheorie.Domain.Services;

namespace Spg.Fachtheorie.Aufgabe2.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StorageRoomController : ControllerBase
    {
        private readonly StorageRoomService _sv;

        public StorageRoomController(StorageRoomService sv)
        {
            _sv = sv;
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
        public IActionResult CreateOne(StorageRoomCreateDto dto)
        {
            var res = _sv.Create(dto);
            if (res == null) return BadRequest();
            return Ok( res);
        }

        [HttpDelete("Id")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]


        public IActionResult DeleateOne(int Id)
        {
            try
            {
                _sv.Delete(Id);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return BadRequest();
            }

        }

    }
}
