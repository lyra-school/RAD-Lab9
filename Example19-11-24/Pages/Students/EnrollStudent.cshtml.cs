using Example19_11_24.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Example19_11_24.Pages.Students
{
    public class EnrollStudentModel : PageModel
    {
        private readonly CollegeContext _context;

        public EnrollStudentModel(CollegeContext context)
        {
            _context = context;
        }

        [BindProperty]
        public int CourseId { get; set; }  // The course to which the faculty is being assigned
        [BindProperty]
        public int StudentId { get; set; }  // The selected faculty member
        public List<SelectListItem> Courses { get; set; }
        public List<SelectListItem> StudentsList { get; set; }

        public async Task OnGetAsync()
        {
            // Fetch courses and faculty members to populate the dropdowns
            Courses = await _context.Courses
                .Select(c => new SelectListItem
                {
                    Value = c.CourseId.ToString(),
                    Text = c.Name
                }).ToListAsync();

            StudentsList = await _context.Students
                .Select(f => new SelectListItem
                {
                    Value = f.StudentId.ToString(),
                    Text = $"{f.FirstName} {f.LastName}"
                }).ToListAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                // If the form data is not valid, reload the page with the dropdowns
                return Page();
            }

            Console.WriteLine("Hello " + CourseId);

            var course = _context.Courses
                .FirstOrDefault(c => c.CourseId == CourseId);

            if (course == null)
            {
                return NotFound();
            }

            var student = _context.Students
                 .FirstOrDefault(c => c.StudentId == StudentId);

            if (student == null)
            {
                return NotFound();
            }

            // Assign the selected faculty member to the course
            course.Students.Add(student);
            student.Courses.Add(course);

            await _context.SaveChangesAsync();

            // Redirect to another page (e.g., a page listing all courses)
            return RedirectToPage("/Courses/Index");
        }
    }

}
