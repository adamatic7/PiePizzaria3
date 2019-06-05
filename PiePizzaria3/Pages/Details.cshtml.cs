using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PiePizzaria3.Models;

namespace PiePizzaria3.Pages.Pies
{
    public class DetailsModel : PageModel
    {
        private readonly PiePizzaria3.Models.PiePizzariaContext _context;

        public DetailsModel(PiePizzaria3.Models.PiePizzariaContext context)
        {
            _context = context;
        }

        public Pie Pie { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Pie = await _context.Pie.FirstOrDefaultAsync(m => m.Id == id);

            if (Pie == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
