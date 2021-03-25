using MFPE_InsureityPortal_Client.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MFPE_InsureityPortal_Client.Provider
{
    public class AuthProvider : IAuthProvider
    {
        public async Task<HttpResponseMessage> Login(User user)
        {
            using (var httpClient = new HttpClient())
            {
                StringContent content1 = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
                var response1 = await httpClient.PostAsync("https://localhost:44397/api/Auth/Login", content1);
                // var response1 = await httpClient.PostAsync("http://13.86.4.222/api/Auth/Login", content1);
                return response1;
            }
        }
    }
}
