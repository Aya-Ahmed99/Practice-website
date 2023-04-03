using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using miniproject.Interfaces;
using miniproject.Models;
using miniproject.viewModel;

namespace miniproject.Repositry
{
    public class CourseRepository 
    {
        private readonly IGenericRepositry<Course> courseRepo;
        private readonly IGenericRepositry<Instractor> instractorRepo;

        public CourseRepository(IGenericRepositry<Course> _courseRepo, IGenericRepositry<Instractor> _instractorRepo)
        {
            courseRepo= _courseRepo;    
            instractorRepo = _instractorRepo;
        }

        public List<CourseVM> GetAll()
        {
            var courseList = courseRepo.GetAll().Include(dept => dept.Department).Include(ins=>ins.instractors).ToList();
            var courseVMList = courseList.Select(course =>
            new CourseVM
            {
                Id = course.Id,
                Name = course.Name,
                MinDegree = course.MinDegree,
                Department_id = course.Department.Id,
                Department = course.Department,
                Departments = new List<Department>(),
                Instractors = course.instractors
            }).ToList();
            return courseVMList;
        }

        public CourseVM GetById(int id)
        {
            var course = courseRepo.GetAll().Include(dept=>dept.Department).Include(ins=>ins.instractors).FirstOrDefault(c=>c.Id == id);
            CourseVM courseVM = new CourseVM();
            courseVM.Id = course.Id;
            courseVM.Name = course.Name;
            courseVM.MinDegree = course.MinDegree;  
            courseVM.Department = course.Department;
            courseVM.Department_id = course.Department.Id;
            courseVM.Instractors = course.instractors;
            return courseVM;
        }

        public CourseVM Update(CourseVM courseVM)
        {
            Course course = courseRepo.GetByID(courseVM.Id);
            course.Name = courseVM.Name;
            course.MinDegree = courseVM.MinDegree;
            course.Dept_Id = courseVM.Department_id;
            course.Department = courseVM.Department;
            course.instractors = courseVM.Instractors;
            courseRepo.Update(course);
            return courseVM;
        }

        public void Delete(int id)
        {
            courseRepo.Delete(id);
        }

        public CourseVM Insert(CourseVM courseVM)
        {
            Course course = new Course();
            course.Name = courseVM.Name;
            course.MinDegree = courseVM.MinDegree;
            course.Dept_Id = courseVM.Department_id;
            course.Department = courseVM.Department;
            course.instractors = courseVM.Instractors;
            courseRepo.Insert(course);
            return courseVM;
        }

    }
}
