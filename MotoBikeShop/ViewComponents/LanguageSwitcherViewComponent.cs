using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MotoBikeShop.Service;
using MotoBikeShop.ViewModels;

namespace MotoBikeShop.ViewComponents
{
    public class LanguageSwitcherViewComponent : ViewComponent
    {
        private readonly IOptions<RequestLocalizationOptions> _locOptions;

        public LanguageSwitcherViewComponent(IOptions<RequestLocalizationOptions> locOptions)
        {
            _locOptions = locOptions;
        }

        public IViewComponentResult Invoke()
        {
            var requestCulture = HttpContext.Features.Get<IRequestCultureFeature>();
            var currentCulture = requestCulture?.RequestCulture.UICulture.Name ?? "vi-VN";
            var cultureItems = _locOptions.Value.SupportedUICultures
                .Select(c => new LanguageViewModel
                {
                    Code = c.Name,
                    Name = c.NativeName
                })
                .ToList();

            return View(new LanguageSwitcherViewModel
            {
                CurrentLanguage = currentCulture,
                SupportedLanguages = cultureItems
            });
        }
    }
}
