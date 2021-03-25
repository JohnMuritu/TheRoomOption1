using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using option_one.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading.Tasks;

namespace option_one.PromocodeServices
{
    public class PromocodeService : IPromocodeService
    {
        private readonly HttpClient httpClient;
        private string token = "";

        public PromocodeService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<IEnumerable<Services>> GetServices()
        {
            return await httpClient.GetJsonAsync<Services[]>("api/services");
        }

        public async Task<User> Login(UserLoginResource user)
        {
            try
            {
                var base64EncodedBytes = System.Text.Encoding.UTF8.GetBytes(user.username + ":" + user.password);
                token = System.Convert.ToBase64String(base64EncodedBytes);

                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", token);
                return await httpClient.PostJsonAsync<User>("api/users/login", user);
            }
            catch(Exception ex)
            {
                return null;
            }
            
        }

    }
}
