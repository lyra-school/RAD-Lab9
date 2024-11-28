using Example19_11_24.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Example19_11_24.Pages.Staff
{
    public class FacultyByDepartmentModel : PageModel
    {
        private readonly CollegeContext _context;

        public FacultyByDepartmentModel(CollegeContext context)
        {
            _context = context;
        }

        [BindProperty]
        public int DepartmentId { get; set; }
        [BindProperty]
        public IList<Faculty> Faculty { get; set; } // The selected faculty members
        public List<SelectListItem> Departments { get; set; } 

        public async Task OnGetAsync()
        {
            if(Faculty == null)
            {
                Faculty = new List<Faculty>();
            }
                // Fetch depts to populate the dropdowns
                Departments = _context.Departments
                    .Select(c => new SelectListItem
                    {
                        Value = c.DepartmentId.ToString(),
                        Text = c.Name
                    }).ToList();
            
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                // If the form data is not valid, reload the page with the dropdowns
                return Page();
            }

            var faculty = from d in _context.Departments
                          where d.DepartmentId == DepartmentId
                          select d.Faculty;

            Faculty = faculty.ToList()[0];

            // I don't know why this is necessary but repeating the query from OnGet
            // ensures that the dropdown doesn't get destroyed when reloading the page,
            // which is what happens otherwise, as if Razor only passes in data from Post
            // into the next version of the page
            Departments = _context.Departments
                    .Select(c => new SelectListItem
                    {
                        Value = c.DepartmentId.ToString(),
                        Text = c.Name
                    }).ToList();

            return Page();
        }
    }
}
