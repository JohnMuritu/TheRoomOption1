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
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly PromoCodesDBContext _promoCodesDBContext;

        public UsersController(
            PromoCodesDBContext promoCodesDBContext)
        {
            _promoCodesDBContext = promoCodesDBContext;
        }

        [HttpPost("Login")]
        public User Login(UserLoginResource userLoginResource)
        {
            var user = _promoCodesDBContext.Users.Where(u => u.username == userLoginResource.username)
                .Where(u => u.password == userLoginResource.password)
                .FirstOrDefault();

            // return null if the user is not found
            if (user == null)
                return null;

            return user;
        }
    }
}
