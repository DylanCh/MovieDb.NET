using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieDb.NET.Models;
using MovieDb.NET.DataLayer;
using System.Net;

namespace MovieDb.NET.Controllers
{
    public class HomeController : Controller
    {
        private DataProvider dataProvider = new DataProvider();
        private WebClient httpClient = new WebClient {
            Headers = {{ HttpRequestHeader.ContentType ,"application/json"}},
        };
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

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult GetMovies(string movieName){
            //var movie = dataProvider.Find(new Movie().GetType(), movieName);
            return Json(dataProvider.GetMovie(title: movieName));
        }
    }
}
