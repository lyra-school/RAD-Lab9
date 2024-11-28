using Example19_11_24.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Example19_11_24.Pages.Students
{
    public class UnenrollModel : PageModel
    {
            
        private readonly Example19_11_24.Data.CollegeContext _context;

        public UnenrollModel(Example19_11_24.Data.CollegeContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Student Student { get; set; } = default!;
        [BindProperty]
        public Course Course { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id, int? id2)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students.Include(c => c.Courses).FirstOrDefaultAsync(m => m.StudentId == id);

            if (student == null)
            {
                return NotFound();
            }

            Student = student;

            var course = student.Courses.FirstOrDefault(m => m.CourseId == id2);
            if (course == null)
            {
                return NotFound();
            }

            Course = course;
            return Page();
        }

        public void RemoveCourse()
        {

            Student.Courses.Remove(Course);
            _context.SaveChanges();
        }

        public async Task<IActionResult> OnPostAsync(int? id, int? id2)
        {
            if (id == null && id2 == null)
            {
                return NotFound();
            }

            var course = await _context.Courses.FindAsync(id2);
            var student = await _context.Students.Include(c => c.Courses).FirstOrDefaultAsync(m => m.StudentId == id);
            if (student != null && course != null)
            {
                Student = student;
                Course = course;
                bool test = Student.Courses.Remove(Course);

                Console.WriteLine(test);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./StudentsWithEnrollments");
        }
    }
}
