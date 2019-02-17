using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using playground_dotnet_core_async.Models;

namespace playground_dotnet_core_async.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public ActionResult GetList() {  
            // Create a stopwatch for getting execution time  
            var watch = new Stopwatch();
            watch.Start();
            var country = GetCountry();
            var state = GetState();
            var city = GetCity();
            watch.Stop();
            ViewBag.WatchMilliseconds = watch.ElapsedMilliseconds;
            return View();
        }

        public async Task < ActionResult > GetListAsync() {  
            // Create a stopwatch for getting execution time  
            var watch = new Stopwatch();
            watch.Start();
            var country = GetCountryAsync();
            var state = GetStateAsync();
            var city = GetCityAsync();
            var content = await country;
            var count = await state;
            var name = await city;
            watch.Stop();
            ViewBag.WatchMilliseconds = watch.ElapsedMilliseconds;
            return View(); 
        } 
        public string GetCountry() {  
            Thread.Sleep(3000); // Use when you want to block the current thread.  
            return "Canada";
        }  
        public async Task < string > GetCountryAsync() {  
            await Task.Delay(3000); // Use when you want a logical delay without blocking the current thread.  
            return "Canada";
        } 
        public string GetState() {  
            Thread.Sleep(5000); //Use when you want to block the current thread.  
            return "Quebec";
        }  
        public async Task < string > GetStateAsync() {  
            await Task.Delay(5000); //Use - when you want a logical delay without blocking the current thread.  
            return "Quebec";
        }
        public string GetCity() {  
            Thread.Sleep(6000); // Use when you want to block the current thread.  
            return "Montreal";
        }  
        public async Task < string > GetCityAsync() {  
            await Task.Delay(6000); // Use when you want a logical delay without blocking the current thread.  
            return "Montreal";
        }
   }
}
