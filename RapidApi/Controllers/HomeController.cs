using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidApi_Odev.Models;
using static RapidApi_Odev.Models.BookingModel;

namespace RapidApi_Odev.Controllers;

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

    [HttpGet]
    public IActionResult Room()
    {
        var model = new BookingModel()
        {
            data = new Data{
                hotels = new Hotel[]{}
            }
        };
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Room(SearchModel model)
    {
        var city = model.City;
        var checkin = model.Checkin.ToString("yyyy-MM-dd");
        var checkout = model.Checkout.ToString("yyyy-MM-dd");
        var adultCount = model.AdultCount.ToString();
        var roomCount = model.RoomCount.ToString();

        var client1 = new HttpClient();
        var request1 = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri($"https://booking-com15.p.rapidapi.com/api/v1/hotels/searchDestination?query={city}"),
            Headers =
            {
                { "X-RapidAPI-Key", "284c37bb44msh75f9c69b5e31064p1cbed5jsnb965f4713f5e" },
                { "X-RapidAPI-Host", "booking-com15.p.rapidapi.com" },
            },
        };
        var cityId = "";
        using (var response1 = await client1.SendAsync(request1))
        {
            response1.EnsureSuccessStatusCode();
            var body1 = await response1.Content.ReadAsStringAsync();
            var cityModel = JsonConvert.DeserializeObject<CityModel>(body1);
            cityId = cityModel.data[0].dest_id;
        }

        var client = new HttpClient();
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri($"https://booking-com15.p.rapidapi.com/api/v1/hotels/searchHotels?dest_id={cityId}&search_type=city&arrival_date={checkin}&departure_date={checkout}&adults={adultCount}&room_qty={roomCount}&page_number=1&languagecode=en-us&currency_code=EUR"),
            Headers =
            {
                { "X-RapidAPI-Key", "284c37bb44msh75f9c69b5e31064p1cbed5jsnb965f4713f5e" },
                { "X-RapidAPI-Host", "booking-com15.p.rapidapi.com" },
            },
        };
        using (var response = await client.SendAsync(request))
        {
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            var bookingModel = JsonConvert.DeserializeObject<BookingModel>(body);
            return View(bookingModel);
        }
    }

    [HttpGet]
    public async Task<IActionResult> RoomDetail(string hotel_id, string arrival_date, string departure_date)
    {
        var client = new HttpClient();
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri($"https://booking-com15.p.rapidapi.com/api/v1/hotels/getHotelDetails?hotel_id={hotel_id}&arrival_date={arrival_date}&departure_date={departure_date}&languagecode=en-us&currency_code=EUR"),
            Headers =
            {
                { "X-RapidAPI-Key", "284c37bb44msh75f9c69b5e31064p1cbed5jsnb965f4713f5e" },
                { "X-RapidAPI-Host", "booking-com15.p.rapidapi.com" },
            },
        };
        using (var response = await client.SendAsync(request))
        {
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            var otelDetailModel = JsonConvert.DeserializeObject<OtelDetailModel>(body);
            return View(otelDetailModel);
        }
    }



    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
