using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BHHC.Core;
using BHHC.ServiceLayer;

namespace BHHC.App
{
    public class CreateModel : PageModel
    {
        private readonly BHHC.Core.ReasonContext _context;
        private readonly IReasonService _reasonService;

        public CreateModel(BHHC.Core.ReasonContext context, IReasonService reasonService)
        {
            _context = context;
            _reasonService = reasonService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Reason Reason { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _reasonService.InsertReasonAsync(Reason);

            return RedirectToPage("./Index");
        }
    }
}
