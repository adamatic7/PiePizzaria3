using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PiePizzaria3.Models;

namespace PiePizzaria3.Pages.Pies
{
    public class CreateModel : PageModel
    {
        private readonly PiePizzaria3.Models.PiePizzariaContext _context;
        [BindProperty]
        public Microsoft.AspNetCore.Http.IFormFile file { get; set; }
        [BindProperty]
        public byte[] Image { get; set; }
        public CreateModel(PiePizzaria3.Models.PiePizzariaContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Pie Pie { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            using (var stream = new System.IO.MemoryStream())
            {
                file.CopyTo(stream);
                this.Image = stream.ToArray();
            }

            Pie.Image = this.Image;
            Pie.ImageContentType = "file";
            _context.Pie.Add(Pie);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}