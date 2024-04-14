using Microsoft.AspNetCore.Mvc;

namespace MotoBikeShop.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
