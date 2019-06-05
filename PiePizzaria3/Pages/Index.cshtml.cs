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
    public class IndexModel : PageModel
    {
        private readonly PiePizzaria3.Models.PiePizzariaContext _context;

        public IndexModel(PiePizzaria3.Models.PiePizzariaContext context)
        {
            _context = context;
        }

        public IList<Pie> Pie { get;set; }

        public async Task OnGetAsync()
        {
            Pie = await _context.Pie.ToListAsync();
        }
    }
}
