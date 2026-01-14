//Kirsty Chan 232093Z

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KaraokePortal.Model;

namespace KaraokePortal.Pages
{
    public class AboutModel : PageModel
    {
        private readonly KaraokePortal.Model.DBContext _context;

        public AboutModel(KaraokePortal.Model.DBContext context)
        {
            _context = context;
        }



        public class JoinDateGroup
        {
            public DateOnly JoinDate { get; set; }
            public int Count { get; set; }
        }

        public List<JoinDateGroup> JoinDateGroups { get; set; }

        public async Task OnGetAsync()
        {
            JoinDateGroups = await _context.Singer
                .GroupBy(s => s.JoinDate)
                .Select(g => new JoinDateGroup
                {
                    JoinDate = g.Key,
                    Count = g.Count()
                })
                .OrderBy(g => g.JoinDate)
                .ToListAsync();
        }
    }
}
