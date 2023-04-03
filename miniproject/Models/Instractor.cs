using System.ComponentModel.DataAnnotations.Schema;

namespace miniproject.Models
{
    public class Instractor
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Image { get; set; }

        public int Salary { get; set; }

        public string Address { get; set; }
        [ForeignKey("Course")]
        public int Crs_Id { get; set; }
        public virtual Course Course { get; set; }
        [ForeignKey("Department")]
        public int Dept_Id { get; set; }
        public virtual Department Department { get; set; }

    }
}

