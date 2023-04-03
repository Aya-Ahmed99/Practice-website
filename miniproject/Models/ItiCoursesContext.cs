using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace miniproject.Models
{
    public class ItiCoursesContext : IdentityDbContext<ApplicationUser>
    {
        public ItiCoursesContext() : base() 
        {

        }  

        public ItiCoursesContext(DbContextOptions options) : base(options) { 
        

        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer();
            base.OnConfiguring(optionsBuilder); 
        }

        public DbSet<Instractor> instractors { get; set; }

        public DbSet<Course> courses { get; set; }

        public DbSet<CourseResult> courseResults { get; set; }

        public DbSet<Trainee> trainees { get; set; }

        public DbSet<Department> departments { get; set; }



    }
}
