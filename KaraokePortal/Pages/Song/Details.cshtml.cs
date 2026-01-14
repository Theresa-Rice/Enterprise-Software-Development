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
    public class DetailsModel : PageModel
    {
        private readonly KaraokePortal.Model.DBContext _context;

        public DetailsModel(KaraokePortal.Model.DBContext context)
        {
            _context = context;
        }

        public KaraokePortal.Model.Song Song { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            {
                if (id == null)
                    return NotFound();

                Song = await _context.Song
                    .Include(s => s.SongScores)
                        .ThenInclude(ss => ss.Singer)
                    .FirstOrDefaultAsync(m => m.SongID == id);

                return Song == null ? NotFound() : Page();
            }
        }
    }
}
