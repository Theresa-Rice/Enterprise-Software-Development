//Kirsty Chan 232093Z

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KaraokePortal.Model;

namespace KaraokePortal.Pages.Song
{
    public class DeleteModel : PageModel
    {
        private readonly KaraokePortal.Model.DBContext _context;

        public DeleteModel(KaraokePortal.Model.DBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public KaraokePortal.Model.Song Song { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var song = await _context.Song.FirstOrDefaultAsync(m => m.SongID == id);

            if (song is not null)
            {
                Song = song;

                return Page();
            }

            return NotFound();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var song = await _context.Song.FindAsync(id);
            if (song != null)
            {
                Song = song;
                _context.Song.Remove(Song);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
