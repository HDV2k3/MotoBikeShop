using System.Globalization;

namespace MotoBikeShop.Service
{
    public interface ILocalizationService
    {
        string GetLocalizedString(string key);
        Task<string> GetLocalizedProductNameAsync(int productId);
        Task<string> GetLocalizedProductDescriptionAsync(int productId);
        CultureInfo GetCurrentCulture();
        string GetCurrentLanguageCode();
    }
}
