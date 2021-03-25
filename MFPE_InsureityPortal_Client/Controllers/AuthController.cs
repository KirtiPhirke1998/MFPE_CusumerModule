using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using MFPE_InsureityPortal_Client.Models;
using MFPE_InsureityPortal_Client.Provider;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MFPE_InsureityPortal_Client.Controllers
{
    public class AuthController : Controller
    {
        //static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(AuthController));
        private readonly IAuthProvider authprovider;

        public string JwtToken;
        public AuthController(IAuthProvider _authProvider)
        {

            authprovider = _authProvider;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(User user)
        {
            //_log4net.Info("User Login");

            HttpResponseMessage response1 = await authprovider.Login(user);

            if (!response1.IsSuccessStatusCode)
            {
                //_log4net.Info("Invalid User Credentials");
                ViewBag.Message = "Invalid username/password";
                return View();
            }
            else
            {
                //_log4net.Info("Sucessfull User Credentials");
                string apiResponse1 = await response1.Content.ReadAsStringAsync();

                JWT jwt = JsonConvert.DeserializeObject<JWT>(apiResponse1);

                HttpContext.Session.SetString("token", jwt.Token);
                JwtToken = jwt.Token;
                HttpContext.Session.SetString("user", JsonConvert.SerializeObject(user));
                HttpContext.Session.SetInt32("custId", jwt.User_Id);
                HttpContext.Session.SetString("Username", user.Username);
                ViewBag.Message = "User logged in successfully!";

                return RedirectToAction("AllOperations", "Auth");

            }




        }

        
        public ActionResult Logout()
        {
            //_log4net.Info("User Log Out");
            HttpContext.Session.Clear();
            // HttpContext.Session.SetString("user", null);

            return View("Login");
        }

        public ActionResult AllOperations()
        {
            return View();
        }
    }
}