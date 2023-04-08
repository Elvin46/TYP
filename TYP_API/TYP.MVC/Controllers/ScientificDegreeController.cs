using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TYP.Service.DTOs.ScientificDegreeDTOs;
using TYP.Service.Services.Interfaces;

namespace TYP.MVC.Controllers
{
    public class ScientificDegreeController : Controller
    {
        private readonly IScientificDegreeService _scientificDegreeService;

        public ScientificDegreeController(IScientificDegreeService scientificDegreeService)
        {

            _scientificDegreeService = scientificDegreeService;
        }
        public async Task<IActionResult> Index()
        {
            ScientificDegreeGetAllDTO scientificDegrees = await _scientificDegreeService.GetAllAsync();
            return View(scientificDegrees);
        }
        public async Task<IActionResult> Detail(int id)
        {
            ScientificDegreeGetDTO scientificDegree = await _scientificDegreeService.GetByIdAsync<ScientificDegreeGetDTO>(id);
            return View(scientificDegree);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ScientificDegreePostDTO scientificDegreeDTO)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            await _scientificDegreeService.CreateAsync(scientificDegreeDTO);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int id)
        {
            await _scientificDegreeService.Delete(id);
            return Json(new { status = 200 });
        }

        public async Task<IActionResult> Update(int id)
        {
            ScientificDegreePostDTO scientificDegreeDTO = await _scientificDegreeService.GetByIdAsync<ScientificDegreePostDTO>(id);
            return View(scientificDegreeDTO);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, ScientificDegreePostDTO scientificDegreeDTO)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            await _scientificDegreeService.EditAsync(id, scientificDegreeDTO);
            return RedirectToAction(nameof(Index));
        }
    }
}
