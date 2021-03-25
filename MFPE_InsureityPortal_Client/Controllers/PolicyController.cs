using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using MFPE_InsureityPortal_Client.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MFPE_InsureityPortal_Client.Controllers
{   
    public class PolicyController : Controller
    {
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("token") == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            return View();
        }

        //[HttpGet("CreatePolicy")]
        public ActionResult CreatePolicy()
        {
            if (HttpContext.Session.GetString("token") == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> CreatePolicy(ConsumerPolicyDetails cpd)
        {
            if (HttpContext.Session.GetString("token") == null)
            {
                return RedirectToAction("Login", "Auth");
            }

            ConsumerPolicy cp = new ConsumerPolicy(); 
            if (ModelState.IsValid)
            {
                var client = new HttpClient();


                string token = HttpContext.Session.GetString("token");

                var contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", token);

                client.BaseAddress = new Uri("https://localhost:44365/");

                var jsonstring = JsonConvert.SerializeObject(cpd);

                var content = new StringContent(jsonstring, System.Text.Encoding.UTF8, "application/json");


                var response = await client.PostAsync("api/Policy/CreatePolicy", content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("PolicyCreationStatus",new { id = cpd.ConsumerId });
                }

                else
                {
                    ViewBag.Message = "Failed to create policy";
                }
            }
            return View(cpd);
        }

        public ActionResult PolicyCreationStatus(int id)
        {
            if (HttpContext.Session.GetString("token") == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            ViewBag.Message = id;
            return View();
        }


        public async Task<ActionResult> GetConsumerPolicyById(int id)
        {
            if (HttpContext.Session.GetString("token") == null)
            {
                return RedirectToAction("Login", "Auth");
            }

            ConsumerPolicy cp = new ConsumerPolicy();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44365/api/");

                string token = HttpContext.Session.GetString("token");

                var contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", token);
                //HTTP GET
                var result = await client.GetAsync("Policy/ViewConsumerPolicyById?consumerId=" + id);
                // responseTask.Wait();

                // var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    //var readTask = result.Content.ReadAsAsync<BusinessMaster>();

                    var jsoncontent = await result.Content.ReadAsStringAsync();
                    ConsumerPolicy policy = JsonConvert.DeserializeObject<ConsumerPolicy>(jsoncontent);
                    //readTask.Wait();

                    cp = policy;
                }
                else //web api sent error response 
                {
                    //log response status here..


                    return RedirectToAction("PolicyCreationStatusNotFound", new { id = id});
                }
            }
            return View(cp);
        }

        public ActionResult PolicyCreationStausNotFound(int id)
        {
            ViewBag.Message = id;
            return View();
        }

        public ActionResult PolicyIssuedSuccessfully(int id)
        {
            if (HttpContext.Session.GetString("token") == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            ViewBag.Message = id;

            //ViewBag["Data"] = id;
            
            return View();
        }
        public ActionResult IssueConsumerPolicy()
        {
            if (HttpContext.Session.GetString("token") == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            return View();
        }

       

        [HttpPost]
        public async Task<ActionResult> IssueConsumerPolicy(IssuePolicy ip)
        {
            if (HttpContext.Session.GetString("token") == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            ConsumerPolicy cp = new ConsumerPolicy();

            if (ModelState.IsValid)
            {
                var client = new HttpClient();

                string token = HttpContext.Session.GetString("token");

                var contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", token);

                client.BaseAddress = new Uri("https://localhost:44365/");

                var jsonstring = JsonConvert.SerializeObject(ip);

                var content = new StringContent(jsonstring, System.Text.Encoding.UTF8, "application/json");


                var response = await client.PostAsync("api/Policy/IssueConsumerPolicy", content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("PolicyIssuedSuccessfully",new{id =ip.CustomerId });
                }

                else
                {
                    ViewBag.Message = "Failed to issue policy";
                  
                }
            }
            return View(ip);
            
        }

    }
}