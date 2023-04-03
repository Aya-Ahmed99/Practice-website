using miniproject.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace miniproject.viewModel
{
    public class CourseVM
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int? Degree { get; set; }

        public int MinDegree { get; set; }

        public int Department_id { get; set; }

        public virtual Department Department { get; set; }

        public virtual List<Department> Departments { get; set; }

        public virtual List<Instractor> Instractors { get; set; }   

        public virtual Instractor Instractor { get; set; }
    }
}
