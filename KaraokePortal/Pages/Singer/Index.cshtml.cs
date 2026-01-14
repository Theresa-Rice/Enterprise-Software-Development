//Kirsty Chan 232093Z


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KaraokePortal.Model;
using Azure;

namespace KaraokePortal.Pages.Singer
{
    public class IndexModel : PageModel
    {
        private readonly KaraokePortal.Model.DBContext _context;

        public IndexModel(KaraokePortal.Model.DBContext context)
        {
            _context = context;
        }

        public IList<KaraokePortal.Model.Singer> Singer { get;set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        [BindProperty(SupportsGet = true)]
        public int page { get; set; } = 1; 
        public int TotalPages { get; set; }

        public async Task OnGetAsync(int p)
        {

            page = Math.Max(1, p);

            int pageSize = 10;
            IQueryable<Model.Singer> baseQuery = _context.Singer;

            if (!string.IsNullOrEmpty(SearchTerm))
            {
                baseQuery = baseQuery.Where(s => s.FirstName.Contains(SearchTerm) || s.LastName.Contains(SearchTerm));
            }

            int totalCount = await baseQuery.CountAsync(); 
            TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize);

            if (page > TotalPages && TotalPages > 0)
            {
                page = TotalPages;
            }
            else if (TotalPages == 0) 
            {
                page = 1;
            }


            // Apply ordering and pagination
            Singer = await baseQuery
                .OrderBy(t => t.JoinDate)
                .ThenBy(t => t.LastName)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }
    }
}
