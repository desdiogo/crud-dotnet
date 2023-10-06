using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Crud.Data;
using Crud.Models;

namespace Crud.Pages_Premiums
{
    public class DetaislModel : PageModel
    {
        private readonly Crud.Data.ApplicationDbContext _context;

        public DetaislModel(Crud.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public Premium Premium { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Premiums == null)
            {
                return NotFound();
            }

            var premium = await _context.Premiums.FirstOrDefaultAsync(m => m.Id == id);
            if (premium == null)
            {
                return NotFound();
            }
            else 
            {
                Premium = premium;
            }
            return Page();
        }
    }
}
