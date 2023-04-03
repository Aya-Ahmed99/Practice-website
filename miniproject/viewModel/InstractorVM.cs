using miniproject.Models;

namespace miniproject.viewModel
{
    public class InstractorVM
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Image { get; set; }

        public int Salary { get; set; }

        public string Address { get; set; }

        public int Department_id { get; set; }
        public Department Department { get; set; }
        public List<Department> Departments { get; set; }

        public int Course_id { get; set; }
        public Course Course { get; set; }
        public List<Course> Courses { get; set; }

    }
}
