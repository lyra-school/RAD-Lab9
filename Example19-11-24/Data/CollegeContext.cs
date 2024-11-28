namespace Example19_11_24.Data
{
    using Microsoft.EntityFrameworkCore;

    public class CollegeContext : DbContext
    {
        public DbSet<College> Colleges { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Faculty> FacultyMembers { get; set; }

        public CollegeContext(DbContextOptions<CollegeContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Here, you can define additional configurations for your models (optional)
        }
    }
}
