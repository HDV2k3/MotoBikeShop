using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MotoBikeShop.Areas.Admin.Models;
using MotoBikeShop.Data;
using MotoBikeShop.Models;
using System.Data;

namespace MotoBikeShop.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin")]
    [Authorize(Roles = SD.Role_Admin)]
    [Route("home")]

    public class HomeController : Controller
    {
        private readonly motoBikeVHDbContext _context;
        public HomeController(motoBikeVHDbContext context)
        {
            _context = context;
        }
        [Route("")]
        [Route("index")]
        public ActionResult Index()
        {
       
            var currentDate = DateTime.Now.Date;
            var doanhThu = _context.Set<DoanhThuTheoNgay>()
                .FromSqlInterpolated($"EXEC DoanhThuTheoNgay {currentDate}")
                .AsEnumerable()
                .SingleOrDefault();
          
            return View(doanhThu);
        }


    }
}
