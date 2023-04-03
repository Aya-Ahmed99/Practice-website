using System.ComponentModel.DataAnnotations.Schema;

namespace miniproject.Models
{
    public class Course
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int MinDegree { get; set; }

        [ForeignKey("Department")]
        public int Dept_Id { get; set; }

        public virtual Department Department { get; set; }

        public List<Instractor> instractors { get; set; }

        public List<CourseResult> CourseResult { get; set; }
    }
}
