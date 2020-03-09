using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BHHC.Core;
using BHHC.ServiceLayer;

namespace BHHC.App
{
    public class EditModel : PageModel
    {
        private readonly IReasonService _reasonService;

        public EditModel(IReasonService reasonService)
        {
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

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var updateId = await _reasonService.UpdateReasonAsync(Reason.ReasonId, Reason);

            if (updateId <= 0)
            {
                return NotFound();
            }

            return RedirectToPage("./Index");
        }

    }
}
