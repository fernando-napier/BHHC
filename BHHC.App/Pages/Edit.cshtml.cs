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
        private readonly BHHC.Core.ReasonContext _context;
        private readonly IReasonService _reasonService;

        public EditModel(BHHC.Core.ReasonContext context, IReasonService reasonService)
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

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //_context.Attach(Reason).State = EntityState.Modified;

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!ReasonExists(Reason.ReasonId))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            var updateId = await _reasonService.UpdateReasonAsync(Reason.ReasonId, Reason);

            if (updateId <= 0)
            {
                return NotFound();
            }

            return RedirectToPage("./Index");
        }

        private bool ReasonExists(int id)
        {
            return _context.Reasons.Any(e => e.ReasonId == id);
        }
    }
}
