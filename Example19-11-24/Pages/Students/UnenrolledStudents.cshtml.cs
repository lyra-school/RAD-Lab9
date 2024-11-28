using Example19_11_24.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Example19_11_24.Pages.Students
{
    public class UnenrolledStudentsModel : PageModel
    {
        private readonly CollegeContext _context;
        public UnenrolledStudentsModel(CollegeContext context)
        {
            _context = context;
        }

        public IList<Student> Student { get; set; } = default!;

        public async Task OnGetAsync()
        {
            var query = from s in _context.Students
                        where s.Courses.Count() == 0
                        select s;

            Student = query.ToList();
        }
    }
}
