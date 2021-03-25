using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using option_one.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using System.Text.Json;
using System.Text.Json.Serialization;
using option_one.PromocodeServices;

namespace option_one.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private HttpClient _client;

        private IPromocodeService _promocodeService;
        //public List<Services> services { get; set; }
        public string err { get; set; }

        public IndexModel(ILogger<IndexModel> logger, HttpClient client, IPromocodeService promocodeService)
        {
            _logger = logger;
            _client = client;
            _promocodeService = promocodeService;
        }

        /*public async Task<IActionResult> OnGetAsync()
        {
            services = (await _promocodeService.GetServices()).ToList();

            return Page();

        }*/

        public async Task<IActionResult> OnPostAsync()
        {
            UserLoginResource ulr = new UserLoginResource();
            ulr.username = Request.Form["username"];
            ulr.password = Request.Form["password"];

            User usr = await _promocodeService.Login(ulr);

            if (usr != null)
            {
                return Redirect("/Promo");
            }

            err = "Invalid credentials";

            return Page();

        }



    }
}
