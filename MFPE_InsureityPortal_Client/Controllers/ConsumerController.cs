using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using MFPE_InsureityPortal_Client.Helper;
using MFPE_InsureityPortal_Client.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MFPE_InsureityPortal_Client.Controllers
{
    public class ConsumerController : Controller
    {

        //[HttpGet("{id}")]
        ConsumerHelper _api = new ConsumerHelper();

        public ActionResult CreateConsumerBussiness()
        
        {
            if (HttpContext.Session.GetString("token") == null)
            {
                return RedirectToAction("Login", "Auth");
            }

            return View();
        }
     

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateConsumerBussiness(Consumer consumer)
        {
            if (HttpContext.Session.GetString("token") == null)
            {
                return RedirectToAction("Login", "Auth");
            }

            if (ModelState.IsValid)
            {
                using (HttpClient client = new HttpClient())
                {
                    string token = HttpContext.Session.GetString("token");

                    var contentType = new MediaTypeWithQualityHeaderValue("application/json");
                    client.DefaultRequestHeaders.Accept.Add(contentType);
                    client.DefaultRequestHeaders.Authorization =
                        new AuthenticationHeaderValue("Bearer", token);


                    client.BaseAddress = new Uri("https://mfpecusumermodule1.azurewebsites.net");

                    var jsonstring = JsonConvert.SerializeObject(consumer);

                    var content = new StringContent(jsonstring, System.Text.Encoding.UTF8, "application/json");


                    var response = await client.PostAsync("api/Consumer/CreateConsumerBussiness", content);



                    if (response.StatusCode == System.Net.HttpStatusCode.Created)
                    {
                        return RedirectToAction("ViewConsumerBussiness");
                    }
                    else
                    {
                        ViewBag.Message = "Failed to create ConsumerBussiness";
                    }
                }

                
            }
            return View(consumer);
        }


        public ActionResult CreateBussinessProperty()
        {
            if (HttpContext.Session.GetString("token") == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> CreateBussinessProperty(Property property)
        {
            if (HttpContext.Session.GetString("token") == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            if (ModelState.IsValid)
            {
                var client = new HttpClient();

                string token = HttpContext.Session.GetString("token");

                var contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", token);

                client.BaseAddress = new Uri("https://localhost:44369/");

                var jsonstring = JsonConvert.SerializeObject(property);

                var content = new StringContent(jsonstring, System.Text.Encoding.UTF8, "application/json");


                var response = await client.PostAsync("api/Consumer/CreateBussinessProperty", content);



                if (response.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    return RedirectToAction("ViewBussinessProperty");
                }

                else
                {
                    ViewBag.Message = "Failed to create ConsumerBussiness";
                }
            }
            return View(property);

        }

        public async Task<ActionResult> ViewBussinessProperty() 
        {
            if (HttpContext.Session.GetString("token") == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            List<Property> PList = new List<Property>();
            using (var client = new HttpClient())
            {

                string token = HttpContext.Session.GetString("token");

                var contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", token);

                client.BaseAddress = new Uri("https://localhost:44369/api/");
                //HTTP GET
                var result = await client.GetAsync("Consumer/FindAllProperties");
                // responseTask.Wait();

                // var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    //var readTask = result.Content.ReadAsAsync<BusinessMaster>();

                    var jsoncontent = await result.Content.ReadAsStringAsync();
                    List<Property> consumers = JsonConvert.DeserializeObject<List<Property>>(jsoncontent);
                    //readTask.Wait();

                    PList = consumers;
                }
                else
                {
                    PList = null;

                    //ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
                return View(PList);
            }

        }

        public async Task<ActionResult> ViewConsumerBussiness()
        {
            if (HttpContext.Session.GetString("token") == null)
            {
                return RedirectToAction("Login", "Auth");
            }

            List<Consumer> CbList = new List<Consumer>();
            using (var client = new HttpClient())
            {
                string token = HttpContext.Session.GetString("token");

                var contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", token);

                client.BaseAddress = new Uri("https://localhost:44369/api/");
                //HTTP GET
                var result = await client.GetAsync("Consumer/FindAllConsumers");
                // responseTask.Wait();

                // var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    //var readTask = result.Content.ReadAsAsync<BusinessMaster>();

                    var jsoncontent = await result.Content.ReadAsStringAsync();
                    List<Consumer> consumers = JsonConvert.DeserializeObject<List<Consumer>>(jsoncontent);
                    //readTask.Wait();

                    CbList = consumers;
                }
                else
                {       
                    CbList = null;
                  
                    //ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
                return View(CbList);
            }
        }

        //---------------------------------------

        [HttpGet("UpdateConsumerBussiness/{id}")]
        public async Task<ActionResult> UpdateConsumerBussiness(int id)
        {
            if (HttpContext.Session.GetString("token") == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            var consumer = new Consumer();
            using (var client = new HttpClient())
            {
                string token = HttpContext.Session.GetString("token");

                var contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", token);


                client.BaseAddress = new Uri("https://localhost:44369/api/");
                //HTTP GET
                var result = await client.GetAsync("Consumer/{id}?consumerid="+id);
                // responseTask.Wait();

                // var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    //var readTask = result.Content.ReadAsAsync<BusinessMaster>();

                    var jsoncontent = await result.Content.ReadAsStringAsync();
                    Consumer consumer1 = JsonConvert.DeserializeObject<Consumer>(jsoncontent);
                    //readTask.Wait();

                    View(consumer1);
                }
                else
                {
                    return NotFound();

                    //ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
               
            }
            return View(consumer);
        }

        [HttpPost("UpdateConsumerBussiness/{id}")]
        public async Task<ActionResult> UpdateConsumerBussiness(int id,Consumer consumer)
        {
            if (HttpContext.Session.GetString("token") == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            if (ModelState.IsValid)
            {
                var client = new HttpClient();

                string token = HttpContext.Session.GetString("token");

                var contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", token);

                client.BaseAddress = new Uri("https://localhost:44369/");

                var jsonstring = JsonConvert.SerializeObject(consumer);

                var content = new StringContent(jsonstring, System.Text.Encoding.UTF8, "application/json");


                var response = await client.PutAsync("api/Consumer/UpdateConsumerBussiness", content);



                if (response.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    return RedirectToAction("ViewConsumerBussiness");
                }

                else
                {
                    ViewBag.Message = "Failed to create ConsumerBussiness";
                }
            }
            return View(consumer);
        }



        //==============================================================

        [HttpGet("UpdateBussinessProperty/{id}")]
        public async Task<ActionResult> UpdateBussinessProperty(int id)
        {
            if (HttpContext.Session.GetString("token") == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            var property = new Property();
            using (var client = new HttpClient())
            {
                string token = HttpContext.Session.GetString("token");

                var contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", token);

                client.BaseAddress = new Uri("https://localhost:44369/api/");
                //HTTP GET
                var result = await client.GetAsync("Consumer/FindPropertyById/{id}?propertyid=" + id);
                // responseTask.Wait();

                // var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    //var readTask = result.Content.ReadAsAsync<BusinessMaster>();

                    var jsoncontent = await result.Content.ReadAsStringAsync();
                    Property prop1 = JsonConvert.DeserializeObject<Property>(jsoncontent);
                    //readTask.Wait();

                    View(prop1);
                }
                else
                {
                    return NotFound();

                    //ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }

            }
            return View(property);
        }


        [HttpPost("UpdateBussinessProperty/{id}")]
        public async Task<ActionResult> UpdateBussinessProperty(int id, Property property)
        {
            if (HttpContext.Session.GetString("token") == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            if (ModelState.IsValid)
            {
                var client = new HttpClient();

                string token = HttpContext.Session.GetString("token");

                var contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", token);


                client.BaseAddress = new Uri("https://localhost:44369/");

                var jsonstring = JsonConvert.SerializeObject(property);

                var content = new StringContent(jsonstring, System.Text.Encoding.UTF8, "application/json");


                var response = await client.PutAsync("api/Consumer/UpdateBussinessProperty", content);



                if (response.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    return RedirectToAction("ViewBussinessProperty");
                }

                else
                {
                    ViewBag.Message = "Failed to update BussinessProperty";
                }
            }
            return View(property);
        }




        //================================================================
        public async Task<ActionResult> GetBussinessMaster(int id)
        {
            BusinessMaster bm = new BusinessMaster();

            using (var client = new HttpClient())
            {
                string token = HttpContext.Session.GetString("token");

                var contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", token);

                client.BaseAddress = new Uri("https://localhost:44369/api/");
                //HTTP GET
                var result =await client.GetAsync("Consumer/FindBussinessMasterById/{id}?bussinessMasterid="+id);
               // responseTask.Wait();

               // var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    //var readTask = result.Content.ReadAsAsync<BusinessMaster>();

                    var jsoncontent = await result.Content.ReadAsStringAsync();
                    BusinessMaster master = JsonConvert.DeserializeObject<BusinessMaster>(jsoncontent);
                    //readTask.Wait();

                    bm = master;
                }
                else //web api sent error response 
                {
                    //log response status here..

                    bm = null;

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(bm);
        }

        public ActionResult CreateBusinessMaster()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> CreateBusinessMaster(BusinessMaster bm)
        {
            if (HttpContext.Session.GetString("token") == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            if (ModelState.IsValid)
            {
                var client = new HttpClient();

                string token = HttpContext.Session.GetString("token");

                var contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", token);

                client.BaseAddress = new Uri("https://localhost:44369/");

                var jsonstring = JsonConvert.SerializeObject(bm);

                var content = new StringContent(jsonstring, System.Text.Encoding.UTF8, "application/json");


                var response = await client.PostAsync("api/Consumer/CreateBussinessMaster", content);

                if (response.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    return RedirectToAction("BussinessMasterCreationSuccessfully");
                }
                
                else
                {
                    ViewBag.Message = "Failed to create product";
                }
            }
            return View(bm);
        }

        public ActionResult BussinessMasterCreationSuccessfully()
        {
            if (HttpContext.Session.GetString("token") == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            return View();
        }
        public async Task<IActionResult> Index(int id)
        {
            if (HttpContext.Session.GetString("token") == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            Consumer con = new Consumer();
            using (var client = new HttpClient())
            {
                string token = HttpContext.Session.GetString("token");

                var contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", token);

                client.BaseAddress = new Uri("https://localhost:44369/api/");
                //HTTP GET
                var result =await client.GetAsync("Consumer/{id}?consumerid="+id);
             
                if (result.IsSuccessStatusCode)
                {
                 
                    var jsoncontent = await result.Content.ReadAsStringAsync();
                    con = JsonConvert.DeserializeObject<Consumer>(jsoncontent);
                   
                }
                else //web api sent error response 
                {
                    //log response status here..

                   

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(con);

            



            //==============================================================================================
           // HttpClient httpClient = _httpClientFactory.CreateClient();
            //httpClient.BaseAddress = new Uri("http://localhost:61086");
            //HttpResponseMessage response = httpClient.GetAsync("https://localhost:44369/api/Consumer/FindBussinessMasterById/1?bussinessMasterid=1").Result;
            //if (response.IsSuccessStatusCode)
            //{
            //    //BusinessMaster master = await response.Content.ReadAsAsync<BusinessMaster>();
            //    //return new ObjectResult(master);
            //    var jsoncontent = await response.Content.ReadAsStringAsync();
            //    BusinessMaster master = JsonConvert.DeserializeObject<BusinessMaster>(jsoncontent);
            //    return View(master);
            //}
            //else
            //{
            //    return Content("An error has occurred");
            //}

            //---------------------------------------------------------------------------------------------------------------
            //Consumer consumer = new Consumer();

            //HttpClient client = _api.Initial();

            //client.DefaultRequestHeaders.Add("Accept", "application/json");

            //HttpResponseMessage response = await client.GetAsync("/api/Consumer/"+id);

            //if (response.IsSuccessStatusCode)
            //{
            //    var jsoncontent = await response.Content.ReadAsStringAsync();
            //    consumer = JsonConvert.DeserializeObject<Consumer>(jsoncontent);
            //}

            //return View(consumer);
            //-------------------------------------------------------------------------------------

            //var client = new HttpClient();
            //client.BaseAddress = new Uri("https://localhost:44369");

            //client.DefaultRequestHeaders.Accept.Clear();
            //client.DefaultRequestHeaders.Clear();
            //client.DefaultRequestHeaders.CacheControl = new CacheControlHeaderValue() { NoCache = true };
            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));



            //var response = await client.GetAsync("/api/Consumer/" + id);

            //if (response.IsSuccessStatusCode)
            //{
            //    var jsoncontent = await response.Content.ReadAsStringAsync();
            //    consumer = JsonConvert.DeserializeObject<Consumer>(jsoncontent);
            //}
            //else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            //{
            //    return NotFound();
            //}




            //if (response.StatusCode == System.Net.HttpStatusCode.OK)
            //{
            //    var JsonContent = await response.Content.ReadAsStringAsync();
            //    consumer = JsonConvert.DeserializeObject<Consumer>(JsonContent);
            //    return View(consumer);
            //}
            //else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            //{
            //    ViewBag.Message = "No any record Found! Bad Request";
            //    return RedirectToAction("NoConsumer");
            //}
            //else if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
            //{
            //    ViewBag.Message = "Having server issue while adding record";
            //    return RedirectToAction("NoConsumer");
            //}
            //else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            //{
            //    ViewBag.Message = "No record found in DB for ID :" + id;
            //    return RedirectToAction("NoConsumer");
            //}
            // return View(consumer);
        }



        //public async Task<IActionResult> Index1(int id)
        //{
        //    Consumer consumer = new Consumer();

        //    //HttpClient client = _api.Initial();

        //    //client.DefaultRequestHeaders.Add("Accept", "application/json");

        //    //HttpResponseMessage response = await client.GetAsync("/api/Consumer/FindBussinessMasterById/" + id);


        //    HttpClient httpClient = _httpClientFactory.CreateClient();
        //    httpClient.BaseAddress = new Uri("https://localhost:44323");
        //    HttpResponseMessage response = httpClient.GetAsync("https://localhost:44369/api/Consumer/FindBussinessMasterById/1?bussinessMasterid=1").Result;

        //    if (response.IsSuccessStatusCode)
        //    {
        //        var jsoncontent = await response.Content.ReadAsStringAsync();
        //        consumer = JsonConvert.DeserializeObject<Consumer>(jsoncontent);
        //    }

        //    return View(consumer);


        //    //var client = new HttpClient();
        //    //client.BaseAddress = new Uri("https://localhost:44369");

        //    //client.DefaultRequestHeaders.Accept.Clear();
        //    //client.DefaultRequestHeaders.Clear();
        //    //client.DefaultRequestHeaders.CacheControl = new CacheControlHeaderValue() { NoCache = true };
        //    //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));



        //    //var response = await client.GetAsync("/api/Consumer/" + id);

        //    //if (response.IsSuccessStatusCode)
        //    //{
        //    //    var jsoncontent = await response.Content.ReadAsStringAsync();
        //    //    consumer = JsonConvert.DeserializeObject<Consumer>(jsoncontent);
        //    //}
        //    //else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
        //    //{
        //    //    return NotFound();
        //    //}




        //    //if (response.StatusCode == System.Net.HttpStatusCode.OK)
        //    //{
        //    //    var JsonContent = await response.Content.ReadAsStringAsync();
        //    //    consumer = JsonConvert.DeserializeObject<Consumer>(JsonContent);
        //    //    return View(consumer);
        //    //}
        //    //else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
        //    //{
        //    //    ViewBag.Message = "No any record Found! Bad Request";
        //    //    return RedirectToAction("NoConsumer");
        //    //}
        //    //else if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
        //    //{
        //    //    ViewBag.Message = "Having server issue while adding record";
        //    //    return RedirectToAction("NoConsumer");
        //    //}
        //    //else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
        //    //{
        //    //    ViewBag.Message = "No record found in DB for ID :" + id;
        //    //    return RedirectToAction("NoConsumer");
        //    //}
        //    // return View(consumer);
        //}


        //public async Task<IActionResult> GetByIdAsync(int id)
        //{
        //    HttpClient httpClient = _httpClientFactory.CreateClient();
        //    httpClient.BaseAddress = new Uri("http://localhost:61086");
        //    HttpResponseMessage response = httpClient.GetAsync("https://localhost:44369/api/Consumer/FindBussinessMasterById/1?bussinessMasterid=1").Result;
        //    if (response.IsSuccessStatusCode)
        //    {
        //        //BusinessMaster master = await response.Content.ReadAsAsync<BusinessMaster>();
        //        //return new ObjectResult(master);
        //        var jsoncontent = await response.Content.ReadAsStringAsync();
        //        BusinessMaster master = JsonConvert.DeserializeObject<BusinessMaster>(jsoncontent);
        //        return View(master);
        //    }
        //    else
        //    {
        //        return Content("An error has occurred");
        //    }
        //}

    }
}