using DataAccessLayer.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using WebAppMVC.Models;

namespace WebAppMVC.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {

        private readonly string apiUrl = "https://api.weatherapi.com/v1/current.json?key=cf7d7cec411f40469ba110638210603&q=Belgrade&aqi=no";
        public HomeController()
        {
        }

        public async Task<IActionResult> Index()
        {
            VremenskaPrognozaViewModel vremenskaPrognozaData = await GetVremenskaPrognozaData();
            return View(vremenskaPrognozaData);
        }

        private async Task<VremenskaPrognozaViewModel> GetVremenskaPrognozaData()
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<VremenskaPrognozaViewModel>(data);
                }
                else
                {
                    return null;
                }
            }
        }
    }
}