using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using IdentityModel.Client;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using webMVC.Models;
using webMVC.Services;

namespace webMVC.Controllers 
{
    
    [Route("[controller]/[action]")]
    public class ContactController : Controller
    {
        private readonly ILogger<ContactController> _logger;
        private readonly ITokenService _tokenService;

        public ContactController(ILogger<ContactController> logger, ITokenService tokenService)
        {
            _logger = logger;
            _tokenService = tokenService;
        }

        public async Task<IActionResult> Index()
        {
            var data = new List<ContactData>();
            using (var client = new HttpClient())
            {

                var tokenResponse = await _tokenService.GetToken("weatherapi.read");
                
                client.SetBearerToken(tokenResponse.AccessToken);
                var result = client
                .GetAsync("https://localhost:6001/contact/getall")
                .Result;

                if(result.IsSuccessStatusCode)
                {
                    var model = result.Content.ReadAsStringAsync().Result;
                    data = JsonConvert.DeserializeObject<List<ContactData>>(model);
                    return View(data);
                }
                else
                {
                    throw new Exception("Unable to load content");
                }
            }
        }

        
        public IActionResult Create(){
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(int id, string firstname, string lastname, string email, string mobile){

            using (var client = new HttpClient())
            {

                var tokenResponse = await _tokenService.GetToken("weatherapi.read");
                
                client.SetBearerToken(tokenResponse.AccessToken);
                var pocoObject = new ContactData{
                    Id = id,
                    FirstName = firstname,
                    LastName = lastname,
                    Email = email,
                    Mobile = mobile
                };
                string json = JsonConvert.SerializeObject(pocoObject);
                StringContent data = new StringContent(json, Encoding.UTF8, "application/json");


                var result = client
                .PutAsync("https://localhost:6001/contact/create", data )
                .Result;

                if(result.StatusCode == System.Net.HttpStatusCode.Accepted)
                {
                    return Redirect("/Contact/index");
                }
                else
                {
                    return View(pocoObject);
                }
            }
            
        }

        [Route("{id}")]
        public async Task<IActionResult> Edit(int id){
            using (var client = new HttpClient())
            {

                var tokenResponse = await _tokenService.GetToken("weatherapi.read");
                client.SetBearerToken(tokenResponse.AccessToken);

                var result = client
                .GetAsync("https://localhost:6001/contact/info/" + id)
                .Result;

                if(result.IsSuccessStatusCode)
                {
                    var model = result.Content.ReadAsStringAsync().Result;
                    var data = JsonConvert.DeserializeObject<ContactData>(model);
                    ViewBag.Info = data;
                    return View();
                }
                else
                {
                    throw new Exception("Unable to load content");
                }
            }
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id, string firstname, string lastname, string email, string mobile){

            using (var client = new HttpClient())
            {

                var tokenResponse = await _tokenService.GetToken("weatherapi.read");
                
                client.SetBearerToken(tokenResponse.AccessToken);
                var pocoObject = new ContactData{
                    Id = id,
                    FirstName = firstname,
                    LastName = lastname,
                    Email = email,
                    Mobile = mobile
                };
                string json = JsonConvert.SerializeObject(pocoObject);
                StringContent data = new StringContent(json, Encoding.UTF8, "application/json");


                var result = client
                .PostAsync("https://localhost:6001/contact/update", data )
                .Result;

                System.Console.WriteLine(result.StatusCode);
                if(result.StatusCode == System.Net.HttpStatusCode.Accepted)
                {
                    return Redirect("/Contact/index");
                }
                else
                {
                    return View(pocoObject);
                }
            }
            
        }

        [Route("{id}")]
        public async  Task<IActionResult> Delete(int id){
            
            using (var client = new HttpClient())
            {

                var tokenResponse = await _tokenService.GetToken("weatherapi.read");
                client.SetBearerToken(tokenResponse.AccessToken);

                var result = client
                .DeleteAsync("https://localhost:6001/contact/delete/" + id )
                .Result;
                System.Console.WriteLine(result.StatusCode);
                return Redirect("/Contact/index");
            }
        }
    }

}