//Kirsty Chan 232093Z

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KaraokePortal.Model;

namespace KaraokePortal.Pages.Singer
{
    public class EditModel : PageModel
    {
        private readonly KaraokePortal.Model.DBContext _context;

        public EditModel(KaraokePortal.Model.DBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Model.Singer Singer { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var singer =  await _context.Singer.FirstOrDefaultAsync(m => m.SingerID == id);
            if (singer == null)
            {
                return NotFound();
            }
            Singer = singer;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Singer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SingerExists(Singer.SingerID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool SingerExists(Guid id)
        {
            return _context.Singer.Any(e => e.SingerID == id);
        }
    }
}
