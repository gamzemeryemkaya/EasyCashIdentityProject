using Microsoft.AspNetCore.Mvc;

namespace EasyCashIdentityProject.PresentationLayer.Controllers
{
    public class ExchangeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            #region
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://currency-exchange.p.rapidapi.com/exchange?from=USD&to=TRY&q=1.0"),
                Headers =
    {
        { "X-RapidAPI-Key", "3cfa22c580mshfa509815cb52085p18775ajsn28f68981edb6" },
        { "X-RapidAPI-Host", "currency-exchange.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                //var body = await response.Content.ReadAsStringAsync();
                //ViewBag.UsdToTry = body;
                var body = await response.Content.ReadAsStringAsync() + "00000";
                ViewBag.UsdToTry = body.Substring(0, 7);
            }
            #endregion
            #region
            var client2 = new HttpClient();
            var request2 = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://currency-exchange.p.rapidapi.com/exchange?from=EUR&to=TRY&q=1.0"),
                Headers =
    {
        { "X-RapidAPI-Key", "3cfa22c580mshfa509815cb52085p18775ajsn28f68981edb6" },
        { "X-RapidAPI-Host", "currency-exchange.p.rapidapi.com" },
    },
            };
            using (var response2 = await client.SendAsync(request2))
            {
                response2.EnsureSuccessStatusCode();
                //var body2 = await response2.Content.ReadAsStringAsync();
                //ViewBag.EurToTry = body2;
                var body2 = await response2.Content.ReadAsStringAsync() + "00000";
                ViewBag.EurToTry = body2.Substring(0, 7);
            }
            #endregion
            #region
            var client3 = new HttpClient();
            var request3 = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://currency-exchange.p.rapidapi.com/exchange?from=GBP&to=TRY&q=1.0"),
                Headers =
    {
        { "X-RapidAPI-Key", "3cfa22c580mshfa509815cb52085p18775ajsn28f68981edb6" },
        { "X-RapidAPI-Host", "currency-exchange.p.rapidapi.com" },
    },
            };
            using (var response3 = await client3.SendAsync(request3))
            {
                response3.EnsureSuccessStatusCode();
                //var body3 = await response3.Content.ReadAsStringAsync();
                //ViewBag.GbpToTry = body3;
                var body3 = await response3.Content.ReadAsStringAsync() + "00000";
                ViewBag.GbpToTry = body3.Substring(0, 7);
            }
            #endregion
            #region
            var client4 = new HttpClient();
            var request4 = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://currency-exchange.p.rapidapi.com/exchange?from=USD&to=EUR&q=1.0"),
                Headers =
    {
        { "X-RapidAPI-Key", "3cfa22c580mshfa509815cb52085p18775ajsn28f68981edb6" },
        { "X-RapidAPI-Host", "currency-exchange.p.rapidapi.com" },
    },
            };
            using (var response4 = await client4.SendAsync(request4))
            {
                response4.EnsureSuccessStatusCode();
                //var body4 = await response4.Content.ReadAsStringAsync();
                //ViewBag.UsdToEur = body4;
                var body4 = await response4.Content.ReadAsStringAsync() + "00000";
                ViewBag.UsdToEur = body4.Substring(0, 7);
            }
            #endregion
            return View();
        }
    }
}
