using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TYP.Service.DTOs.PredmetGroupDTOs;
using TYP.Service.DTOs.TeacherPredmetDTOs;
using TYP.Service.Services.Interfaces;

namespace TYP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistributionController : ControllerBase
    {
        private readonly ITeacherPredmetService _TeacherPredmetService;

        public DistributionController(ITeacherPredmetService TeacherPredmetService)
        {
            _TeacherPredmetService = TeacherPredmetService;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            TeacherPredmetPostViewDTO model = await _TeacherPredmetService.GetAllPredmetAsync(id);
            return Ok(model);
        }
        [HttpGet("TeacherYuk/{id}")]
        public async Task<IActionResult> GetPredmets(int id)
        {
            List<PredmetGroupGetDTO> predmetGroup = await _TeacherPredmetService.GetAllAsync(id);
            return Ok(predmetGroup);
        }

        [HttpPost("")]
        public async Task<IActionResult> Post(TeacherPredmetPostDTO TeacherPredmetDTO)
        {
            await _TeacherPredmetService.CreateAsync(TeacherPredmetDTO);
            return StatusCode(202);
        }
    }
}
