using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TYP.Core.Entities;
using TYP.Service.DTOs.PredmetGroupDTOs;
using TYP.Service.Services.Interfaces;

namespace TYP.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Roles = "Rector, Department")]
    [ApiController]
    public class LoadsController : ControllerBase
    {
        private readonly IPredmetGroupService _PredmetGroupService;
        private readonly ITeacherPredmetService _TeacherPredmetService;
        private readonly IAccountService _AccountService;

        public LoadsController(IPredmetGroupService PredmetGroupService, IAccountService accountService)
        {
            _PredmetGroupService = PredmetGroupService;
            _AccountService = accountService;
        }
        [HttpPost("SetCourse")]
        public async Task<IActionResult> Post()
        {
            if (!User.IsInRole("Rector"))
            {
                throw new Exception("Suspicious Request Attempt");
            }
            await _PredmetGroupService.SetCourseAsync();
            return StatusCode(202);
        }
        [HttpGet("OutDepartment/{id}")]
        public async Task<IActionResult> GetOut(int id)
        {
            await _AccountService.CheckDepartment(User.Identity.Name, id);
            List<PredmetGroupOutDepartmentDTO> predmetGroup = await _PredmetGroupService.OutDepartment(id);
            return Ok(predmetGroup);
        }
        [HttpGet("IntoDepartment/{id}")]
        public async Task<IActionResult> GetInto(int id)
        {
            await _AccountService.CheckDepartment(User.Identity.Name, id);
            List<PredmetGroupOutDepartmentDTO> predmetGroup = await _PredmetGroupService.IntoDepartment(id);
            return Ok(predmetGroup);
        }
        
    }
}
