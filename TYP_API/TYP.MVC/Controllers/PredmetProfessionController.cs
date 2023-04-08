using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System.Threading.Tasks;
using TYP.Service.DTOs.DepartmentDTOs;
using TYP.Service.DTOs.PredmetDTOs;
using TYP.Service.DTOs.PredmetProfessionDTOs;
using TYP.Service.DTOs.ProfessionDTOs;
using TYP.Service.Services.Interfaces;

namespace TYP.MVC.Controllers
{
    public class PredmetProfessionController : Controller
    {
        private readonly IPredmetProfessionService _PredmetProfessionService;
        private readonly IProfessionService _ProfessionService;
        private readonly IPredmetService _PredmetService;
        private readonly IDepartmentService _DepartmentService;

        public PredmetProfessionController(IPredmetProfessionService PredmetProfessionService, IDepartmentService departmentService, IProfessionService professionService, IPredmetService predmetService)
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
            PredmetProfessionGetAllDTO PredmetProfessions = await _PredmetProfessionService.GetAllAsync(id);
            PredmetGetAllDTO predmets = await _PredmetService.GetAllAsync();
            ViewBag.Predmets = predmets;
            return View(PredmetProfessions);
        }
        public async Task<IActionResult> Create(int id)
        {
            PredmetGetAllDTO predmets = await _PredmetService.GetAllAsync();
            ViewBag.Predmets = predmets;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PredmetProfessionPostDTO PredmetProfessionDTO)
        {
            PredmetGetAllDTO predmets = await _PredmetService.GetAllAsync();
            ViewBag.Predmets = predmets;
            if (!ModelState.IsValid)
            {
                return View();
            }
            await _PredmetProfessionService.CreateAsync(PredmetProfessionDTO);
            int id = PredmetProfessionDTO.ProfessionId;
            return RedirectToAction("Create", new RouteValueDictionary(
                new { controller = "PredmetProfession", action = "Create", Id = id }));
        }
        public async Task<IActionResult> Delete(int id)
        {
            await _PredmetProfessionService.Delete(id);
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
