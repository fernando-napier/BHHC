using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BHHC.Core;
using BHHC.ServiceLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace BHHC.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IReasonService _reasonService;
        public IEnumerable<Reason> _reasons;

        public IndexModel(ILogger<IndexModel> logger, IReasonService reasonService)
        {
            _logger = logger;
            _reasonService = reasonService;
        }

        public void OnGet()
        {
            // grab all the reasons from sqlite
            _reasons = _reasonService.GetAllReasons();
        }
    }
}
