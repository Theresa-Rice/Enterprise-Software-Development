//Kirsty Chan 232093Z

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KaraokePortal.Model;

namespace KaraokePortal.Pages.Singer
{
    public class DeleteModel : PageModel
    {
        private readonly KaraokePortal.Model.DBContext _context;

        public DeleteModel(KaraokePortal.Model.DBContext context)
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

            var singer = await _context.Singer.FirstOrDefaultAsync(m => m.SingerID == id);

            if (singer is not null)
            {
                Singer = singer;

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

            var singer = await _context.Singer.FindAsync(id);
            if (singer != null)
            {
                Singer = singer;
                _context.Singer.Remove(Singer);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
