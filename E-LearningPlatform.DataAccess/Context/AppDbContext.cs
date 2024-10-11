using E_LearningPlatform.Models;
using Microsoft.EntityFrameworkCore;

namespace E_LearningPlatform.DataAccess.Context
{
    public class AppDbContext :DbContext 
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Video> Videos { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Request> requests { get; set; }

        public DbSet<Enrollment> Enrollments  { get; set; }
    }
}
