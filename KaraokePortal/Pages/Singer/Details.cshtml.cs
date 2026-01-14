//Kirsty Chan 232093Z

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KaraokePortal.Model;

namespace KaraokePortal.Pages.Singer
{
    public class DetailsModel : PageModel
    {
        private readonly KaraokePortal.Model.DBContext _context;

        public DetailsModel(KaraokePortal.Model.DBContext context)
        {
            _context = context;
        }
        public Model.Singer Singer { get; set; }
        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            {
                if (id == null)
                    return NotFound();

                Singer = await _context.Singer
                    .Include(s => s.SongScores)
                        .ThenInclude(ss => ss.Song)
                    .FirstOrDefaultAsync(m => m.SingerID == id);

                return Singer == null ? NotFound() : Page();
            }
        }
    }
}
