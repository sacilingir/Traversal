using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json.Nodes;
using TraversalCoreProject.Areas.Admin.Models;
using System.Net.Http.Headers;

namespace TraversalCoreProject.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]
    public class BookingHotelSearch : Controller
    {
        public async Task<IActionResult> Index()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://booking-com.p.rapidapi.com/v1/hotels/search?children_ages=5%2C0&include_adjacency=true&children_number=2&dest_id=-1456928&adults_number=2&dest_type=city&order_by=popularity&page_number=0&checkout_date=2025-09-26&filter_by_currency=EUR&locale=en-gb&categories_filter_ids=class%3A%3A2%2Cclass%3A%3A4%2Cfree_cancellation%3A%3A1&checkin_date=2025-09-25&room_number=1&units=metric"),
                Headers =
    {
        { "x-rapidapi-key", "66d9ddbefbmshb337afe43716a45p12ade0jsn7236e8fd3bcc" },
        { "x-rapidapi-host", "booking-com.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var bodyReplace = body.Replace(".","");
               
                var values =JsonConvert.DeserializeObject<BookingHotelSearchViewModel>(bodyReplace);
                return View(values.result);
            }
       
        }

        [HttpGet]
        public IActionResult GetCityDestID()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> GetCityDestID(string p)
        {
          
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://booking-com.p.rapidapi.com/v1/hotels/locations?locale=en-gb&name={p}"),
                Headers =
    {
        { "x-rapidapi-key", "66d9ddbefbmshb337afe43716a45p12ade0jsn7236e8fd3bcc" },
        { "x-rapidapi-host", "booking-com.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();

                return View();
            }

        }
    }
}
