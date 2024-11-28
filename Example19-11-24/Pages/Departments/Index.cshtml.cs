using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Example19_11_24.Data;

namespace Example19_11_24.Pages.Departments
{
    public class IndexModel : PageModel
    {
        private readonly Example19_11_24.Data.CollegeContext _context;

        public IndexModel(Example19_11_24.Data.CollegeContext context)
        {
            _context = context;
        }

        public IList<Department> Department { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Department = await _context.Departments.ToListAsync();
        }
    }
}
