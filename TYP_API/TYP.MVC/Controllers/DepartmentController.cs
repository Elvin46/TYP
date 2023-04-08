using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TYP.Service.DTOs.DepartmentDTOs;
using TYP.Service.Services.Interfaces;

namespace TYP.MVC.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _DepartmentService;

        public DepartmentController(IDepartmentService DepartmentService)
        {

            _DepartmentService = DepartmentService;
        }
        public async Task<IActionResult> Index()
        {
            DepartmentGetAllDTO Departments = await _DepartmentService.GetAllAsync();
            return View(Departments);
        }
        public async Task<IActionResult> Detail(int id)
        {
            DepartmentGetDTO Department = await _DepartmentService.GetByIdAsync<DepartmentGetDTO>(id);
            return View(Department);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DepartmentPostDTO DepartmentDTO)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            await _DepartmentService.CreateAsync(DepartmentDTO);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int id)
        {
            await _DepartmentService.Delete(id);
            return Json(new { status = 200 });
        }

        public async Task<IActionResult> Update(int id)
        {
            DepartmentPostDTO DepartmentDTO = await _DepartmentService.GetByIdAsync<DepartmentPostDTO>(id);
            return View(DepartmentDTO);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, DepartmentPostDTO DepartmentDTO)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            await _DepartmentService.EditAsync(id, DepartmentDTO);
            return RedirectToAction(nameof(Index));
        }
    }
}
