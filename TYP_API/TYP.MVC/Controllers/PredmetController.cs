using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TYP.Service.DTOs.DepartmentDTOs;
using TYP.Service.DTOs.PredmetDTOs;
using TYP.Service.Services.Interfaces;

namespace TYP.MVC.Controllers
{
    public class PredmetController : Controller
    {
        private readonly IPredmetService _PredmetService;
        private readonly IDepartmentService _DepartmentService;

        public PredmetController(IPredmetService PredmetService, IDepartmentService departmentService)
        {

            _PredmetService = PredmetService;
            _DepartmentService = departmentService;
        }
        public async Task<IActionResult> Index()
        {
            PredmetGetAllDTO Predmets = await _PredmetService.GetAllAsync();
            return View(Predmets);
        }
        public async Task<IActionResult> Detail(int id)
        {
            PredmetGetDTO Predmet = await _PredmetService.GetByIdAsync<PredmetGetDTO>(id);
            return View(Predmet);
        }
        public async Task<IActionResult> Create()
        {
            DepartmentGetAllDTO departments = await _DepartmentService.GetAllAsync();
            ViewBag.Departments = departments;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PredmetPostDTO PredmetDTO)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            await _PredmetService.CreateAsync(PredmetDTO);
            return RedirectToAction(nameof(Create));
        }
        public async Task<IActionResult> Delete(int id)
        {
            await _PredmetService.Delete(id);
            return Json(new { status = 200 });
        }
        public async Task<IActionResult> Update(int id)
        {
            PredmetPostDTO PredmetDTO = await _PredmetService.GetByIdAsync<PredmetPostDTO>(id);
            return View(PredmetDTO);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, PredmetPostDTO PredmetDTO)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            await _PredmetService.EditAsync(id, PredmetDTO);
            return RedirectToAction(nameof(Index));
        }
    }
}
