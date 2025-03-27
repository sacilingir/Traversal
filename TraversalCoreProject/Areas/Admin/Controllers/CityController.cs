using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TraversalCoreProject.Models;

namespace TraversalCoreProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CityController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CityList()
        {
            var jsonCity = JsonConvert.SerializeObject(cities);
            return Json(jsonCity);
        }

        public static List<CityClass> cities = new List<CityClass>
        {
            new CityClass
            {
                CityID=1,
                CityName="Üsküp",
                CityCountry="Makedonya"
            },
            new CityClass
            {
                CityID=2,
                CityName="Ankara",
                CityCountry="Türkiye"
            },
            new CityClass
            {
                CityID=3,
                CityName="Paris",
                CityCountry="Fransa"
            }

        };
    }
}
