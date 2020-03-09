using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BHHC.Core;
using BHHC.ServiceLayer;

namespace BHHC.App
{
    public class DeleteModel : PageModel
    {
        private readonly BHHC.Core.ReasonContext _context;
        private readonly IReasonService _reasonService;

        public DeleteModel(BHHC.Core.ReasonContext context, IReasonService reasonService)
        {
            _context = context;
            _reasonService = reasonService;
        }

        [BindProperty]
        public Reason Reason { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Reason = await _reasonService.GetReasonByIdAsync(id.Value);

            if (Reason == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Reason = await _reasonService.GetReasonByIdAsync(id.Value);

            if (Reason != null)
            {
                await _reasonService.DeleteReasonAsync(Reason);
            }

            return RedirectToPage("./Index");
        }
    }
}
