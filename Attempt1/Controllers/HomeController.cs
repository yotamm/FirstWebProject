using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Attempt1.Models;
using Newtonsoft.Json;

namespace Attempt1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public async Task<ActionResult> UvCheck(UvCheckViewModel model)
        {
            HttpClient client = new HttpClient();
            //coordinates extraction (the weather API response contains coordinates)
            var response1 =
                await
                    client.GetStringAsync("http://api.openweathermap.org/data/2.5/weather?q=" + model.City +
                                          "&appid=1ba143b505a2207077d699393fb7aeb2");
            dynamic respond1 = JsonConvert.DeserializeObject(response1);
            int lat = respond1.coord.lat;//the number of decimal points determines the radius size
            int lon = respond1.coord.lon;
            string uvApi = lat + "," + lon + "/" +
                           DateTime.UtcNow.Year + "Z";
            //use the UV API
            var requestUri = "http://api.openweathermap.org/v3/uvi/" + uvApi +
                             ".json?appid=1ba143b505a2207077d699393fb7aeb2";
            var response2 =
                await
                    client.GetStringAsync(requestUri);
            dynamic respond2 = JsonConvert.DeserializeObject(response2);
            double data = respond2.data;
            model.Data = data;
            return View("Index", model);
        }
    }
}