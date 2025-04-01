using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Localization;
using MotoBikeShop.Data;
using MotoBikeShop.Resources;
using System.Globalization;

namespace MotoBikeShop.Service
{
    public class LocalizationService : ILocalizationService
    {
        private readonly IStringLocalizer<SharedResource> _sharedLocalizer;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly motoBikeVHDbContext _dbContext;
        private readonly IMemoryCache _cache;

        public LocalizationService(
            IStringLocalizer<SharedResource> sharedLocalizer,
            IHttpContextAccessor httpContextAccessor,
            motoBikeVHDbContext dbContext,
            IMemoryCache cache)
        {
            _sharedLocalizer = sharedLocalizer;
            _httpContextAccessor = httpContextAccessor;
            _dbContext = dbContext;
            _cache = cache;
        }

        public string GetLocalizedString(string key)
        {
            return _sharedLocalizer[key];
        }

        public async Task<string> GetLocalizedProductNameAsync(int productId)
        {
            string cacheKey = $"product_name_{GetCurrentLanguageCode()}_{productId}";

            if (!_cache.TryGetValue(cacheKey, out string name))
            {
                var translation = await _dbContext.HangHoaTranslations
                    .FirstOrDefaultAsync(t => t.MaHH == productId && t.LanguageCode == GetCurrentLanguageCode());

                name = translation?.TenHH;

                if (string.IsNullOrEmpty(name))
                {
                    // Fallback vào bản gốc nếu không có bản dịch
                    var product = await _dbContext.HangHoas.FindAsync(productId);
                    name = product?.TenHH;
                }

                // Cache trong 24 giờ
                _cache.Set(cacheKey, name, TimeSpan.FromHours(24));
            }

            return name;
        }

        public async Task<string> GetLocalizedProductDescriptionAsync(int productId)
        {
            string cacheKey = $"product_desc_{GetCurrentLanguageCode()}_{productId}";

            if (!_cache.TryGetValue(cacheKey, out string description))
            {
                var translation = await _dbContext.HangHoaTranslations
                    .FirstOrDefaultAsync(t => t.MaHH == productId && t.LanguageCode == GetCurrentLanguageCode());

                description = translation?.MoTa;

                if (string.IsNullOrEmpty(description))
                {
                    // Fallback vào bản gốc nếu không có bản dịch
                    var product = await _dbContext.HangHoas.FindAsync(productId);
                    description = product?.MoTa;
                }

                // Cache trong 24 giờ
                _cache.Set(cacheKey, description, TimeSpan.FromHours(24));
            }

            return description;
        }

        public CultureInfo GetCurrentCulture()
        {
            return Thread.CurrentThread.CurrentUICulture;
        }

        public string GetCurrentLanguageCode()
        {
            return Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName;
        }
    }
}
