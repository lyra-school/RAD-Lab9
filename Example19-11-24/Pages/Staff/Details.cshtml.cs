using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Example19_11_24.Data;

namespace Example19_11_24.Pages.Staff
{
    public class DetailsModel : PageModel
    {
        private readonly Example19_11_24.Data.CollegeContext _context;

        public DetailsModel(Example19_11_24.Data.CollegeContext context)
        {
            _context = context;
        }

        public Faculty Faculty { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var faculty = await _context.FacultyMembers.Include(f => f.Courses).FirstOrDefaultAsync(m => m.FacultyId == id);
            if (faculty == null)
            {
                return NotFound();
            }
            else
            {
                Faculty = faculty;
            }
            return Page();
        }
    }
}
