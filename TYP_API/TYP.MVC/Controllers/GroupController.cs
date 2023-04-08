using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TYP.Service.DTOs.GroupDTOs;
using TYP.Service.DTOs.ProfessionDTOs;
using TYP.Service.DTOs.SectorDTOs;
using TYP.Service.Services.Interfaces;

namespace TYP.MVC.Controllers
{
    public class GroupController : Controller
    {
        private readonly IGroupService _GroupService;
        private readonly IProfessionService _ProfessionService;
        private readonly ISectorService _SectorService;

        public GroupController(IGroupService GroupService, IProfessionService professionService, ISectorService sectorService)
        {

            _GroupService = GroupService;
            _ProfessionService = professionService;
            _SectorService = sectorService;
        }
        public async Task<IActionResult> Index()
        {
            GroupGetAllDTO Groups = await _GroupService.GetAllAsync();
            return View(Groups);
        }
        public async Task<IActionResult> Detail(int id)
        {
            GroupGetDTO Group = await _GroupService.GetByIdAsync<GroupGetDTO>(id);
            return View(Group);
        }
        public async Task<IActionResult> Create()
        {
            ProfessionGetAllDTO professions = await _ProfessionService.GetAllAsync();
            SectorGetAllDTO sectors = await _SectorService.GetAllAsync();
            ViewBag.Professions = professions;
            ViewBag.Sectors = sectors;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(GroupPostDTO GroupDTO)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            await _GroupService.CreateAsync(GroupDTO);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int id)
        {
            await _GroupService.Delete(id);
            return Json(new { status = 200 });
        }

        public async Task<IActionResult> Update(int id)
        {
            GroupPostDTO GroupDTO = await _GroupService.GetByIdAsync<GroupPostDTO>(id);
            return View(GroupDTO);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, GroupPostDTO GroupDTO)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            await _GroupService.EditAsync(id, GroupDTO);
            return RedirectToAction(nameof(Index));
        }
    }
}
