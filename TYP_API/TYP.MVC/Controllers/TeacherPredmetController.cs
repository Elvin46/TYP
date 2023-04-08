using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System.Collections.Generic;
using System.Threading.Tasks;
using TYP.Core.Entities;
using TYP.Service.DTOs.GroupDTOs;
using TYP.Service.DTOs.PredmetGroupDTOs;
using TYP.Service.DTOs.TeacherPredmetDTOs;
using TYP.Service.Services.Interfaces;

namespace TYP.MVC.Controllers
{
    public class TeacherPredmetController : Controller
    {
        private readonly ITeacherPredmetService _TeacherPredmetService;

        public TeacherPredmetController(ITeacherPredmetService TeacherPredmetService)
        {

            _TeacherPredmetService = TeacherPredmetService;
        }
        public async Task<IActionResult> Predmets(int id)
        {
            List<PredmetGroupGetDTO> predmetGroups = await _TeacherPredmetService.GetAllAsync(id);
            return View(predmetGroups);
        }
        public async Task<IActionResult> Index(int id)
        {
            TeacherPredmetPostViewDTO predmetGroups = await _TeacherPredmetService.GetAllPredmetAsync(id);
            return View(predmetGroups);
        }
        public async Task<IActionResult> Detail(int id)
        {
            TeacherPredmetGetDTO TeacherPredmet = await _TeacherPredmetService.GetByIdAsync<TeacherPredmetGetDTO>(id);
            return View(TeacherPredmet);
        }
        public async Task<IActionResult> Create(TeacherPredmetPostDTO TeacherPredmetDTO)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            await _TeacherPredmetService.CreateAsync(TeacherPredmetDTO);
            return RedirectToAction("Index", new RouteValueDictionary(
                new { controller = "TeacherPredmet", action = "Index", Id = TeacherPredmetDTO.TeacherId }));
        }
        public async Task<IActionResult> Delete(int id)
        {
            await _TeacherPredmetService.Delete(id);
            return Json(new { status = 200 });
        }

        public async Task<IActionResult> Update(int id)
        {
            TeacherPredmetPostDTO TeacherPredmetDTO = await _TeacherPredmetService.GetByIdAsync<TeacherPredmetPostDTO>(id);
            return View(TeacherPredmetDTO);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, TeacherPredmetPostDTO TeacherPredmetDTO)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            await _TeacherPredmetService.EditAsync(id, TeacherPredmetDTO);
            return RedirectToAction(nameof(Index));
        }
    }
}
