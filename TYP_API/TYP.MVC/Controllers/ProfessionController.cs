using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TYP.Service.DTOs.PredmetDTOs;
using TYP.Service.DTOs.PredmetProfessionDTOs;
using TYP.Service.DTOs.ProfessionDTOs;
using TYP.Service.Services.Interfaces;

namespace TYP.MVC.Controllers
{
    public class ProfessionController : Controller
    {
        private readonly IPredmetProfessionService _PredmetProfessionService;
        private readonly IProfessionService _ProfessionService;
        private readonly IPredmetService _PredmetService;
        private readonly IDepartmentService _DepartmentService;

        public ProfessionController(IPredmetProfessionService PredmetProfessionService, IDepartmentService departmentService, IProfessionService professionService, IPredmetService predmetService)
        {

            _PredmetProfessionService = PredmetProfessionService;
            _DepartmentService = departmentService;
            _ProfessionService = professionService;
            _PredmetService = predmetService;
        }
        public async Task<IActionResult> Index()
        {
            ProfessionGetAllDTO professions = await _ProfessionService.GetAllAsync();
            ViewBag.Professions = professions;
            return View(professions);
        }
        public async Task<IActionResult> Detail(int id)
        {
            ProfessionGetDTO profession = await _ProfessionService.GetByIdAsync(id);
            return View(profession);
        }
        public async Task<IActionResult> Create()
        {
            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProfessionPostDTO professionDTO)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            await _ProfessionService.CreateAsync(professionDTO);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int id)
        {
            await _ProfessionService.Delete(id);
            return Json(new { status = 200 });
        }
        public async Task<IActionResult> Update(int id)
        {
            PredmetProfessionPostDTO PredmetProfessionDTO = await _PredmetProfessionService.GetByIdAsync<PredmetProfessionPostDTO>(id);
            return View(PredmetProfessionDTO);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, PredmetProfessionPostDTO PredmetProfessionDTO)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            await _PredmetProfessionService.EditAsync(id, PredmetProfessionDTO);
            return RedirectToAction(nameof(Index));
        }
    }
}
