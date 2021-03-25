using option_one.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace option_one.PromocodeServices
{
    public interface IPromocodeService
    {
        Task<IEnumerable<Services>> GetServices();
        Task<User> Login(UserLoginResource user);
    }
}
