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
    public class IndexModel : PageModel
    {
        public IList<Reason> _reasons { get; set; }

        private readonly BHHC.Core.ReasonContext _context;
        private readonly IReasonService _reasonService;

        public IndexModel(BHHC.Core.ReasonContext context, IReasonService reasonService)
        {
            _context = context;
            _reasonService = reasonService;
        }

        public async Task OnGetAsync()
        {
            _reasons = await _reasonService.GetAllReasonsAsync();
        }
    }
}
