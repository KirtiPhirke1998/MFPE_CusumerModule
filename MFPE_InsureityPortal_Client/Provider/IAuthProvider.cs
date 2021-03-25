using MFPE_InsureityPortal_Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MFPE_InsureityPortal_Client.Provider
{
    public interface IAuthProvider
    {
        public Task<HttpResponseMessage> Login(User user);
    }
}
