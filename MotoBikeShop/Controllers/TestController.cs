using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Threading;

namespace MotoBikeShop.Controllers
{
    public class TestController : Controller
    {
        private readonly IOptions<RequestLocalizationOptions> _locOptions;

        public TestController(IOptions<RequestLocalizationOptions> locOptions)
        {
            _locOptions = locOptions;
        }

        public IActionResult Index()
        {
            var currentCulture = Thread.CurrentThread.CurrentUICulture;
            var supportedCultures = _locOptions.Value.SupportedUICultures;
            var cookieValue = Request.Cookies[CookieRequestCultureProvider.DefaultCookieName];

            ViewBag.CurrentCulture = currentCulture.Name;
            ViewBag.SupportedCultures = string.Join(", ", supportedCultures.Select(c => c.Name));
            ViewBag.CookieValue = cookieValue;

            return View();
        }

        [HttpPost]
        public IActionResult SetCulture(string culture)
        {
            Console.WriteLine($"SetCulture method called with culture: {culture}");

            try
            {
                Response.Cookies.Append(
                    CookieRequestCultureProvider.DefaultCookieName,
                    CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                    new CookieOptions
                    {
                        Expires = DateTimeOffset.UtcNow.AddYears(1),
                        IsEssential = true
                    }
                );

                Console.WriteLine("Cookie set successfully");
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error setting cookie: {ex.Message}");
                return RedirectToAction("Index");
            }
        }
    }
}