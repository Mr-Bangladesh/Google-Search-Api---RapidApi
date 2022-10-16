using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using API_Consume___Google_Search.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RestSharp;

namespace API_Consume___Google_Search.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(KeyWordModel model)
        {
            string keyword = model.KeyWord;

            string server = "https://google-search3.p.rapidapi.com/api/v1/search/q=" + keyword;

            var client = new RestClient(server);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-rapidapi-host", "google-search3.p.rapidapi.com");
            request.AddHeader("x-rapidapi-key", "101962def0msh0f5400fc24cbac3p1b15c1jsn4978f762efbc");
            IRestResponse response = client.Execute(request);
            //Console.WriteLine(response.Content);

            SearchResultModel searchResult = JsonConvert.DeserializeObject<SearchResultModel>(response.Content);

            ViewBag.searchResult = searchResult;

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
    }
}
