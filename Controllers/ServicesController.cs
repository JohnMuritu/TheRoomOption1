using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using option_one.Data;
using option_one.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace option_one.Controllers
{
    /*[Authorize]*/
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly PromoCodesDBContext _promoCodesDBContext;

        public ServicesController(PromoCodesDBContext promoCodesDBContext)
        {
            _promoCodesDBContext = promoCodesDBContext;
        }

        [HttpGet]
        public IEnumerable<Services> Get()
        {
            using (_promoCodesDBContext)
            {
                //get service by title
                //return context.Services.Where(s => s.ServiceTitle == "Analytics.com").ToList();
                //get all services
                return _promoCodesDBContext.Services.ToList();
            }

        }

        [HttpPut("activate/{serviceId}")]
        public Services ActivatePromoCode(int serviceId)
        {
            using (_promoCodesDBContext)
            {
                var service = _promoCodesDBContext.Services.Where(s => s.ServiceId == serviceId).FirstOrDefault();
                service.ServiceStatus = "Active";

                _promoCodesDBContext.SaveChanges();
                return _promoCodesDBContext.Services.Where(s => s.ServiceId == serviceId).FirstOrDefault();
            }
        }
    }
}
