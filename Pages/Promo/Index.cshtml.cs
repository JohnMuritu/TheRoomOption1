using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using option_one.Models;
using option_one.PromocodeServices;

namespace option_one.Pages.Promo
{
    
    public class IndexModel : PageModel
    {
        private HttpClient _client;

        private IPromocodeService _promocodeService;
        public List<Services> services { get; set; }
        public IndexModel(HttpClient client, IPromocodeService promocodeService)
        {
            _client = client;
            _promocodeService = promocodeService;
        }
        public async Task<IActionResult> OnGetAsync()
        {
            services = (await _promocodeService.GetServices()).ToList();

            return Page();

        }
    }
}
