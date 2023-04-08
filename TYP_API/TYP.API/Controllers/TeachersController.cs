using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TYP.Service.DTOs.TeacherDTOs;
using TYP.Service.Services.Interfaces;
using TYP.Core.Entities;

namespace TYP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private readonly ITeacherService _TeacherService;

        public TeachersController(ITeacherService teacherService)
        {
            _TeacherService = teacherService;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {
            TeacherGetAllDTO tables = await _TeacherService.GetAllAsync();
            return Ok(tables);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            TeacherGetDTO TeacherDto = await _TeacherService.GetByIdAsync<TeacherGetDTO>(id);
            return Ok(TeacherDto);
        }
        [HttpPost("")]
        public async Task<IActionResult> Post(TeacherPostDTO TeacherDto)
        {
            await _TeacherService.CreateAsync(TeacherDto);
            Teacher Teacher = await _TeacherService.GetByNameAsync<Teacher>(TeacherDto.Name);
            return StatusCode(202, Teacher);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _TeacherService.Delete(id);
            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromForm] TeacherPostDTO TeacherDto)
        {
            await _TeacherService.EditAsync(id, TeacherDto);
            return NoContent();
        }
    }
}
