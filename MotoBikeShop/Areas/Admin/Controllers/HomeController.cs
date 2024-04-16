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
    [Authorize(Roles = SD.Role_Admin)]

    public class HomeController : Controller
    {
        private readonly motoBikeVHDbContext _context;
        public HomeController(motoBikeVHDbContext context)
        {
            _context = context;
        }
      
        public ActionResult Index()
        {
            var currentDate = DateTime.Now.Date;
            double doanhThuNgay = 0;
            double doanhThuThang = 0;
            double PhanTramDoanhThu = 0;
            double ConutEmail = 0;
            using (SqlConnection con = new SqlConnection("Data Source=LAPTOP-S31L0IIU;Initial Catalog=Hutech;Integrated Security=True;Trust Server Certificate=True"))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand("DoanhThuTheoNgay", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CurrentDate", currentDate);

                    object result = cmd.ExecuteScalar();
                 
                    if (result != DBNull.Value && result !=null)
                    {
                       doanhThuNgay =Convert.ToDouble(result);
                    }
                    else
                    {
                        doanhThuNgay = 0.0;
                    }
                   
                }
                using (SqlCommand cmd = new SqlCommand("DoanhThuTheoThang", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Month", currentDate.Month));
                    cmd.Parameters.Add(new SqlParameter("@Year", currentDate.Year));

                    object result = cmd.ExecuteScalar(); // ExecuteScalar dùng cho trường hợp chỉ trả về một giá trị duy nhất

                    if (result != DBNull.Value && result != null)
                    {
                        doanhThuThang = Convert.ToDouble(result);
                    }
                     else
                    {
                        doanhThuThang = 0.0;
                    }
                }
                using (SqlCommand cmd = new SqlCommand("CalculateRevenuePercentage", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    object result = cmd.ExecuteScalar(); // ExecuteScalar dùng cho trường hợp chỉ trả về một giá trị duy nhất

                    if (result != DBNull.Value && result != null)
                    {
                        PhanTramDoanhThu = Convert.ToDouble(result);
                    }
                    else
                    {
                        PhanTramDoanhThu = 0.0;
                    }
                }
                using (SqlCommand cmd = new SqlCommand("CalculateRevenuePercentage", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    object result = cmd.ExecuteScalar(); // ExecuteScalar dùng cho trường hợp chỉ trả về một giá trị duy nhất

                    if (result != null)
                    {
                        ConutEmail = Convert.ToDouble(result);
                    }
                }
            }
            ViewBag.DoanhThuNgay = doanhThuNgay;
            ViewBag.DoanhThuThang = doanhThuThang;
            ViewBag.PhanTramDoanhThu = PhanTramDoanhThu;

            return View();
        }


        public IActionResult ThongKeHienTai()
        {
            var currentDate = DateTime.Now.Date;
            List<OrderDetail> orderDetails = new List<OrderDetail>(); // Danh sách chứa các đối tượng OrderDetail

            using (SqlConnection con = new SqlConnection("Data Source=LAPTOP-S31L0IIU;Initial Catalog=motoBikeVH;Integrated Security=True;Trust Server Certificate=True"))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("GetOrderDetailsByDate", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@NgayThangNam", SqlDbType.Date).Value = currentDate;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        // Đọc và xử lý dữ liệu từ SqlDataReader
                        while (reader.Read())
                        {
                            // Lấy giá trị từ các cột tương ứng trong kết quả trả về
                            string hoTen = reader.GetString(0);
                            string diaChi = reader.GetString(1);
                            string cachThanhToan = reader.GetString(2);
                            int maTrangThai = reader.GetInt32(3);
                            string ghiChu = reader.GetString(4);
                            string phoneNumber = reader.GetString(5);
                            string tenHH = reader.GetString(6);
                            int soLuong = reader.GetInt32(7);
                            double donGia = reader.GetDouble(8);
                            // Tạo một đối tượng OrderDetail và thêm vào danh sách
                            var orderDetail = new OrderDetail
                            {
                                HoTen = hoTen,
                                DiaChi = diaChi,
                                CachThanhToan = cachThanhToan,
                                MaTrangThai = maTrangThai,
                                GhiChu = ghiChu,
                                PhoneNumber = phoneNumber,
                                TenHH = tenHH,
                                SoLuong = soLuong,
                                DonGia = donGia

                            };
                            orderDetails.Add(orderDetail); // Thêm đối tượng vào danh sách
                        }
                    }
                }
            }

            return View(orderDetails); // Truyền danh sách orderDetails đến view
        }
        public IActionResult ThongKe()
        {
            using (SqlConnection con = new SqlConnection("Data Source=LAPTOP-S31L0IIU;Initial Catalog=Hutech;Integrated Security=True;Trust Server Certificate=True"))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("GetOrderDetailsByAll", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Thực hiện truy vấn và lấy kết quả
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<OrderDetail> orderDetails = new List<OrderDetail>();

                        // Đọc và xử lý dữ liệu từ SqlDataReader
                        while (reader.Read())
                        {
                            // Lấy giá trị từ các cột tương ứng trong kết quả trả về
                            string hoTen = reader.GetString(0);
                            string diaChi = reader.GetString(1);
                            string cachThanhToan = reader.GetString(2);
                            int maTrangThai = reader.GetInt32(3);
                            string ghiChu = reader.GetString(4);
                            string phoneNumber = reader.GetString(5);
                            string tenHH = reader.GetString(6);
                            int soLuong = reader.GetInt32(7);
                            double donGia = reader.GetDouble(8);

                            // Tạo một đối tượng OrderDetail và thêm vào danh sách
                            var orderDetail = new OrderDetail
                            {
                                HoTen = hoTen,
                                DiaChi = diaChi,
                                CachThanhToan = cachThanhToan,
                                MaTrangThai = maTrangThai,
                                GhiChu = ghiChu,
                                PhoneNumber = phoneNumber,
                                TenHH = tenHH,
                                SoLuong = soLuong,
                                DonGia = donGia
                            };

                            orderDetails.Add(orderDetail); // Thêm đối tượng vào danh sách
                        }

                        // Truyền danh sách orderDetails đến view
                        return View(orderDetails);
                    }
                }
            }
        }

    }
}
