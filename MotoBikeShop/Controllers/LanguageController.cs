using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

namespace MotoBikeShop.Controllers
{
    public class LanguageController : Controller
    {
        [HttpPost]
        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            Console.WriteLine($"Setting culture to: {culture}, returnUrl: {returnUrl}");

            // Đảm bảo culture hợp lệ
            if (culture != "vi-VN" && culture != "en-US")
            {
                culture = "vi-VN"; // Fallback
            }

            // Đặt culture mới
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions
                {
                    Expires = DateTimeOffset.UtcNow.AddYears(1),
                    IsEssential = true,
                    HttpOnly = false,
                    SameSite = SameSiteMode.Lax
                }
            );

            // Kiểm tra returnUrl có hợp lệ không
            returnUrl = returnUrl ?? "~/";
            if (!Url.IsLocalUrl(returnUrl))
            {
                returnUrl = "~/";
            }

            return LocalRedirect(returnUrl);
        }
        public IActionResult DebugCulture()
        {
            var result = new
            {
                CurrentCulture = Thread.CurrentThread.CurrentCulture.Name,
                CurrentUICulture = Thread.CurrentThread.CurrentUICulture.Name,
                Cookie = Request.Cookies[CookieRequestCultureProvider.DefaultCookieName],
                SupportedCultures = Request.HttpContext.Features
                    .Get<IRequestCultureFeature>()
                    ?.Provider
                    .GetType()
                    .Name
            };

            return Json(result);
        }

    }
}
