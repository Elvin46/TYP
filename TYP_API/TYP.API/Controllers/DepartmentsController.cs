using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TYP.Service.DTOs.DepartmentDTOs;
using TYP.Service.Services.Interfaces;
using TYP.Core.Entities;

namespace TYP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentService _DepartmentService;

        public DepartmentsController(IDepartmentService DepartmentService)
        {
            _DepartmentService = DepartmentService;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {
            DepartmentGetAllDTO tables = await _DepartmentService.GetAllAsync();
            return Ok(tables);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            DepartmentGetDTO DepartmentDto = await _DepartmentService.GetByIdAsync<DepartmentGetDTO>(id);
            return Ok(DepartmentDto);
        }
        [HttpPost("")]
        public async Task<IActionResult> Post([FromForm] DepartmentPostDTO DepartmentDto)
        {
            await _DepartmentService.CreateAsync(DepartmentDto);
            Department Department = await _DepartmentService.GetByNameAsync<Department>(DepartmentDto.Name);
            return StatusCode(202, Department);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _DepartmentService.Delete(id);
            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromForm] DepartmentPostDTO DepartmentDto)
        {
            await _DepartmentService.EditAsync(id, DepartmentDto);
            return NoContent();
        }
    }
}
