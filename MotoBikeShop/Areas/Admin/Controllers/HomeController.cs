using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MotoBikeShop.Areas.Admin.Models;
using MotoBikeShop.Data;
using MotoBikeShop.Models;
using System.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Configuration;
using System.Text.Json;

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
            decimal doanhThuNgay = 0;
            decimal doanhThuThang= 0;
            decimal PhanTramDoanhThu= 0;
            decimal ConutEmail = 0;
            using (SqlConnection con = new SqlConnection("Data Source=LAPTOP-S31L0IIU;Initial Catalog=motoBikeVH;Integrated Security=True;Trust Server Certificate=True"))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand("DoanhThuTheoNgay", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@CurrentDate", currentDate));

                    object result = cmd.ExecuteScalar(); // ExecuteScalar dùng cho trường hợp chỉ trả về một giá trị duy nhất

                    if (result != null)
                    {
                        doanhThuNgay = Convert.ToDecimal(result);
                    }
                }
                using (SqlCommand cmd = new SqlCommand("DoanhThuTheoThang", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Month", currentDate.Month));
                    cmd.Parameters.Add(new SqlParameter("@Year", currentDate.Year));

                    object result = cmd.ExecuteScalar(); // ExecuteScalar dùng cho trường hợp chỉ trả về một giá trị duy nhất

                    if (result != null)
                    {
                        doanhThuThang = Convert.ToDecimal(result);
                    }
                }
                using (SqlCommand cmd = new SqlCommand("CalculateRevenuePercentage", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    object result = cmd.ExecuteScalar(); // ExecuteScalar dùng cho trường hợp chỉ trả về một giá trị duy nhất

                    if (result != null)
                    {
                        PhanTramDoanhThu = Convert.ToDecimal(result);
                    }
                }
                using (SqlCommand cmd = new SqlCommand("CalculateRevenuePercentage", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    object result = cmd.ExecuteScalar(); // ExecuteScalar dùng cho trường hợp chỉ trả về một giá trị duy nhất

                    if (result != null)
                    {
                        ConutEmail = Convert.ToDecimal(result);
                    }
                }
            }
            ViewBag.DoanhThuNgay = doanhThuNgay;
            ViewBag.DoanhThuThang = doanhThuThang;
            ViewBag.PhanTramDoanhThu = PhanTramDoanhThu;

            return View();
        }


  


    }
}
