using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TYP.Service.DTOs.DepartmentDTOs;
using TYP.Service.DTOs.JobTypeDTOs;
using TYP.Service.DTOs.ScientificDegreeDTOs;
using TYP.Service.DTOs.ScientificNameDTOs;
using TYP.Service.DTOs.TeacherDTOs;
using TYP.Service.Services.Interfaces;

namespace TYP.MVC.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ITeacherService _teacherService;
        private readonly IDepartmentService _departmentService;
        private readonly IJobTypeService _jobTypeService;
        private readonly IScientificDegreeService _scientificDegreeService;
        private readonly IScientificNameService _scientificNameService;
        private readonly ISectorService _sectorService;

        public TeacherController(ITeacherService teacherService, IDepartmentService departmentService, IScientificDegreeService scientificDegreeService, IJobTypeService jobTypeService, IScientificNameService scientificNameService, ISectorService sectorService)
        {

            _teacherService = teacherService;
            _departmentService = departmentService;
            _scientificDegreeService = scientificDegreeService;
            _jobTypeService = jobTypeService;
            _scientificNameService = scientificNameService;
            _sectorService = sectorService;
        }
        public async Task<IActionResult> Index()
        {
            TeacherGetAllDTO teachers = await _teacherService.GetAllAsync();
            return View(teachers);
        }
        public async Task<IActionResult> Create()
        {
            DepartmentGetAllDTO departments = await _departmentService.GetAllAsync();
            ScientificDegreeGetAllDTO scientificDegrees = await _scientificDegreeService.GetAllAsync();
            JobTypeGetAllDTO jobTypes = await _jobTypeService.GetAllAsync();
            ViewBag.Departments = departments;
            ViewBag.ScientificDegrees = scientificDegrees;
            ViewBag.JobTypes = jobTypes;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TeacherPostDTO teacherDTO)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            await _teacherService.CreateAsync(teacherDTO);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int id)
        {
            await _teacherService.Delete(id);
            return Json(new { status = 200 });
        }

        public async Task<IActionResult> Update(int id)
        {
            TeacherPostDTO teacherDTO = await _teacherService.GetByIdAsync<TeacherPostDTO>(id);
            ViewBag.Departments = await _departmentService.GetAllAsync();
            ViewBag.JobTypes = await _jobTypeService.GetAllAsync();
            ViewBag.ScientificDegrees = await _scientificDegreeService.GetAllAsync();
            ViewBag.ScientificNames = await _scientificNameService.GetAllAsync();
            ViewBag.Sectors = await _sectorService.GetAllAsync();
            return View(teacherDTO);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, TeacherPostDTO teacherDTO)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            //List<SectorEditDTOs> objects = new List<MyObject>();
            //foreach (string key in Request.Form.Keys)
            //{
            //    if (key.StartsWith("Name"))
            //    {
            //        int index = int.Parse(key.Substring(4));
            //        if (objects.Count < index + 1)
            //        {
            //            objects.Add(new MyObject());
            //        }
            //        objects[index].Name = Request.Form[key];
            //    }
            //    else if (key.StartsWith("Age"))
            //    {
            //        int index = int.Parse(key.Substring(3));
            //        if (objects.Count < index + 1)
            //        {
            //            objects.Add(new MyObject());
            //        }
            //        objects[index].Age = int.Parse(Request.Form[key]);
            //    }
            //}
            await _teacherService.EditAsync(id, teacherDTO);
            return RedirectToAction(nameof(Index));
        }
    }
}
