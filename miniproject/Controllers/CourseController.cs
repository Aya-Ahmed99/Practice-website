using Microsoft.AspNetCore.Mvc;
using miniproject.Interfaces;
using miniproject.Models;
using miniproject.Repositry;
using miniproject.viewModel;

namespace miniproject.Controllers
{
    public class CourseController : Controller
    {
        private readonly CourseRepository courseRepository;
        private readonly IGenericRepositry<Department> departmentRepo;
        public CourseController(CourseRepository _courseRepository , IGenericRepositry<Department> _departmentRepo)
        {
            courseRepository = _courseRepository;
            departmentRepo = _departmentRepo;
        }
        public IActionResult GetAll()
        {
            var courses = courseRepository.GetAll();
            return View(courses);
        }

        public IActionResult Details(int id)
        {
            var crs = courseRepository.GetById(id);
            return View(crs);
        }

        public IActionResult Edit(int id)
        {
            ViewData["Departments"] = departmentRepo.GetAll().ToList();
            var crsData = courseRepository.GetById(id);
            return View(crsData);
        }

        [HttpPost]
        public IActionResult Edit(CourseVM courseVM)
        {
            courseRepository.Update(courseVM);
            return RedirectToAction("GetAll");
        }

        public IActionResult Delete(int id)
        {
            courseRepository.Delete(id);
            return RedirectToAction("GetAll");
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new CourseVM
            {
                Departments = departmentRepo.GetAll().ToList(),
            };
            return View(model);

        }

        [HttpPost]
        public IActionResult create(CourseVM courseVM)
        {
            courseRepository.Insert(courseVM);
            return RedirectToAction("GetAll");

        }

    }
}
