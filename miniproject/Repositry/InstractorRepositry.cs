using Microsoft.EntityFrameworkCore;
using miniproject.Interfaces;
using miniproject.Models;
using miniproject.viewModel;

namespace miniproject.Repositry
{
    public class InstractorRepositry
    {
        private readonly IGenericRepositry<Instractor> instractorRepo;
        public InstractorRepositry(IGenericRepositry<Instractor> _instractorRepo) { 
        
            instractorRepo= _instractorRepo;
        }

        public List<InstractorVM> GetAll() 
        {
            var instracorList = instractorRepo.GetAll().Include(dept => dept.Department).ToList();
            var instructorVMList = instracorList.Select(instructor =>
            new InstractorVM
            {
                Id = instructor.Id,
                Name = instructor.Name,
                Image = instructor.Image,
                Salary = instructor.Salary,
                Address = instructor.Address,
                Department_id = instructor.Department.Id,
                Department = instructor.Department,
                Departments = new List<Department>()
            }).ToList();
            return instructorVMList;
        }

        public InstractorVM GetById(int id) 
        {
            var instractor = instractorRepo.GetAll().Include(dept => dept.Department).Include(crs=>crs.Course).FirstOrDefault(ins => ins.Id == id);
            InstractorVM instractorVM = new InstractorVM();
            instractorVM.Id = instractor.Id;
            instractorVM.Name= instractor.Name; 
            instractorVM.Image= instractor.Image;
            instractorVM.Salary = instractor.Salary;
            instractorVM.Address = instractor.Address;
            instractorVM.Department_id = instractor.Department.Id;  
            instractorVM.Department = instractor.Department;
            instractorVM.Departments = new List<Department>();
            instractorVM.Course_id = instractor.Crs_Id;
            instractorVM.Course = instractor.Course;
            instractorVM.Courses = new List<Course>();
            return instractorVM;
        }

        public InstractorVM Update(InstractorVM instractorVM)
        {
            Instractor instractor = instractorRepo.GetByID(instractorVM.Id);
            instractor.Name = instractorVM.Name;
            instractor.Image = instractorVM.Image;
            instractor.Salary = instractorVM.Salary;
            instractor.Address = instractorVM.Address;
            instractor.Dept_Id = instractorVM.Department_id;
            instractor.Department = instractorVM.Department;
            instractor.Crs_Id = instractorVM.Course_id;
            instractor.Course = instractorVM.Course;
            instractorRepo.Update(instractor);
            return instractorVM;
        }

        public void Delete(int id)
        {
            instractorRepo.Delete(id);
        }

        public InstractorVM Insert(InstractorVM instractorVM) 
        {
            Instractor instractor =new Instractor();
            instractor.Name = instractorVM.Name;
            instractor.Image = instractorVM.Image;
            instractor.Salary = instractorVM.Salary;
            instractor.Address = instractorVM.Address;
            instractor.Dept_Id = instractorVM.Department_id;
            instractor.Department = instractorVM.Department;
            instractor.Crs_Id = instractorVM.Course_id;
            instractor.Course = instractorVM.Course;
            instractorRepo.Insert(instractor);

            return instractorVM;
        }

    }
}
