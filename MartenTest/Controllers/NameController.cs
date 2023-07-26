using Marten;
using MartenTest.Projections;
using MartenTest.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MartenTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NameController : ControllerBase
    {
        private readonly NameService _nameService;
        public NameController(NameService nameService)
        {
            _nameService = nameService;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("GetAllNames")]
        public async Task<ActionResult<P1>> GetAllStudents(string id)
        {
            var result = _nameService.GetNameOfStudents(id);
            if (result.AllUsers.Count != 0)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest("No names");
            }
        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpPost("CreateUser")]
        public async Task<ActionResult> CreateUser()
        {
            var result = await _nameService.CreateUser();
            return Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPost("AddPersonalInformation")]
        public async Task<ActionResult> AddPersonalInformation(string name, int age, string id, string email, string phone)
        {
            var result = await _nameService.AddPersonalInformation(name, age, id, email, phone);
            return Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpPost("CreateListOfUsers")]
        public async Task<ActionResult> CreateListOfUsers()
        {
            var result = await _nameService.CreateListOfStudents();
            return Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPost("AddStudentToList")]
        public async Task<ActionResult> AddStudentToList(string listId, string userId)
        {
            var result = await _nameService.AddToListOfStudents(listId, userId);
            return Ok(result);
        }


    }
}
