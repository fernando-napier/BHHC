using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BHHC.Core;

namespace BHHC.App
{
    public class DetailsModel : PageModel
    {
        private readonly BHHC.Core.ReasonContext _context;

        public DetailsModel(BHHC.Core.ReasonContext context)
        {
            _context = context;
        }

        public Reason Reason { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Reason = await _context.Reasons.FirstOrDefaultAsync(m => m.ReasonId == id);

            if (Reason == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
