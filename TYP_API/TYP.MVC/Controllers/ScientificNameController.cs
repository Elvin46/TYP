using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TYP.Service.DTOs.ScientificNameDTOs;
using TYP.Service.Services.Interfaces;

namespace TYP.MVC.Controllers
{
    public class ScientificNameController : Controller
    {
        private readonly IScientificNameService _ScientificNameService;

        public ScientificNameController(IScientificNameService ScientificNameService)
        {

            _ScientificNameService = ScientificNameService;
        }
        public async Task<IActionResult> Index()
        {
            ScientificNameGetAllDTO ScientificNames = await _ScientificNameService.GetAllAsync();
            return View(ScientificNames);
        }
        public async Task<IActionResult> Detail(int id)
        {
            ScientificNameGetDTO ScientificName = await _ScientificNameService.GetByIdAsync<ScientificNameGetDTO>(id);
            return View(ScientificName);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ScientificNamePostDTO ScientificNameDTO)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            await _ScientificNameService.CreateAsync(ScientificNameDTO);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int id)
        {
            await _ScientificNameService.Delete(id);
            return Json(new { status = 200 });
        }

        public async Task<IActionResult> Update(int id)
        {
            ScientificNamePostDTO ScientificNameDTO = await _ScientificNameService.GetByIdAsync<ScientificNamePostDTO>(id);
            return View(ScientificNameDTO);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, ScientificNamePostDTO ScientificNameDTO)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            await _ScientificNameService.EditAsync(id, ScientificNameDTO);
            return RedirectToAction(nameof(Index));
        }
    }
}
