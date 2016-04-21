using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;
using KummaWebProject.Models;
using Newtonsoft.Json;

namespace KummaWebProject.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public async Task<ActionResult> UvCheck(UvCheckViewModel model)
        {
            HttpClient client = new HttpClient();
            //coordinates extraction (the weather API response contains coordinates)

            const string apiKey = "1ba143b505a2207077d699393fb7aeb2";
            var weatherRequestUrl = $"http://api.openweathermap.org/data/2.5/weather?q={model.City}&appid={apiKey}";
            var weatherResponseJson = await client.GetStringAsync(weatherRequestUrl);
            dynamic weatherResponse = JsonConvert.DeserializeObject(weatherResponseJson);
            int lat = weatherResponse.coord.lat;//the number of decimal points determines the radius size
            int lon = weatherResponse.coord.lon;

            var uvRequestUrl = $"http://api.openweathermap.org/v3/uvi/{lat},{lon}/{DateTime.UtcNow.Year}Z.json?appid={apiKey}";
            var uvResponseJson = await client.GetStringAsync(uvRequestUrl);
            dynamic uvResponse = JsonConvert.DeserializeObject(uvResponseJson);
            model.Data = uvResponse.data;

            return View("Index", model);
        }
    }
}