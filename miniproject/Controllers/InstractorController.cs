using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using miniproject.Interfaces;
using miniproject.Models;
using miniproject.Repositry;
using miniproject.viewModel;
using System.Security.Claims;

namespace miniproject.Controllers
{
    public class InstractorController : Controller
    {
        private readonly InstractorRepositry InstructorRepo;
        private readonly IGenericRepositry<Department> DepartmentRepo;  
        private readonly IGenericRepositry<Course> CourseRepo;

        public InstractorController(InstractorRepositry _InstructorRepo , IGenericRepositry<Department> _DepartmentRepo, IGenericRepositry<Course> _CourseRepo)
        {
            DepartmentRepo= _DepartmentRepo;    
            InstructorRepo= _InstructorRepo;
            CourseRepo= _CourseRepo;
        }

        [Authorize(Roles ="Admin , Student" )]
        public IActionResult GetAll()
        {
            var allIns = InstructorRepo.GetAll();
            List<Claim> claims=  User.Claims.ToList();
            Claim idClaim = claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            string id = idClaim.Value;
            return View(allIns);
        }

        public IActionResult Details(int id) {
            var ins = InstructorRepo.GetById(id);   
            return View(ins);
        }

        [Authorize(Roles ="Admin")]
        public IActionResult Edit(int id)
        {
            ViewData["Departments"] = DepartmentRepo.GetAll().ToList();
            ViewData["Courses"] = CourseRepo.GetAll().ToList();
            var insData = InstructorRepo.GetById(id);
            return View(insData);
        }

        [HttpPost]

        public IActionResult Edit(InstractorVM instractorVM) 
        {
            InstructorRepo.Update(instractorVM);
            return RedirectToAction("GetAll");
        }
        [Authorize(Roles = "Admin")]

        public IActionResult Delete(int id)
        {
            InstructorRepo.Delete(id);
            return RedirectToAction("GetAll");
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]

        public IActionResult Create()
        {
            var model = new InstractorVM
            {
                Departments = DepartmentRepo.GetAll().ToList(),
                Courses  = CourseRepo.GetAll().ToList()
                
            };
            return View(model);

        }

        [HttpPost]
        public IActionResult create(InstractorVM instractorVM)
        {
            InstructorRepo.Insert(instractorVM);
            return RedirectToAction("GetAll");

        }

    }

}
