using Example19_11_24.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Example19_11_24.Pages.Students
{
    public class StudentsWithEnrollmentsModel : PageModel
    {
        private readonly CollegeContext _context;

        public StudentsWithEnrollmentsModel(CollegeContext context)
        {
            _context = context;
        }

        public IList<Student> Student { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Student = await _context.Students.Include(c => c.Courses).ToListAsync();
        }
    }
}
