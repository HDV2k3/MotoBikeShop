
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MotoBikeShop.Data;
using MotoBikeShop.Helpers;
using MotoBikeShop.Models;
using MotoBikeShop.Momo;
using MotoBikeShop.Repository;
using MotoBikeShop.ViewModels;
using Newtonsoft.Json.Linq;
using System.Security.Claims;

namespace MotoBikeShop.Controllers
{
    public class CartController : Controller
    {
        private readonly motoBikeVHDbContext db;
        private readonly UserManager<ApplicationUser> _userManager;

        //private readonly ICartService _cartService;
        public CartController(motoBikeVHDbContext context, UserManager<ApplicationUser> userManager)
        {
            //, ICartService cartService
            //_cartService = cartService;
            db = context;
            _userManager = userManager;
        }
        // dssp trong giỏ hàng
        public List<CartItem> Cart => HttpContext.Session.Get<List<CartItem>>(MySetting.CART_KEY) ?? new List<CartItem>();
        // giao diện
        public IActionResult Index()
        {
            return View(Cart);
        }
        // thêm vào giỏ hàng
        public IActionResult AddToCart(int id, int quantity = 1)
        {
            var gioHang = Cart;
            var item = gioHang.SingleOrDefault(p => p.MaHH == id);
            if (item == null)
            {
                var hangHoa = db.HangHoas.SingleOrDefault(p => p.MaHH == id);
                if (hangHoa == null)
                {
                    TempData["Message"] = $"Không tìm thấy hàng hóa có mã {id}";
                    return Redirect("/404");
                }
                item = new CartItem
                {
                    MaHH = hangHoa.MaHH,
                    TenHH = hangHoa.TenHH,
                    DonGia = hangHoa.DonGia ?? 0,
                    Hinh = hangHoa.Hinh ?? string.Empty,
                    SoLuong = quantity
                };
                gioHang.Add(item);
            }
            else
            {
                item.SoLuong += quantity;
            }


            HttpContext.Session.Set(MySetting.CART_KEY, gioHang);


            return RedirectToAction("Index");
        }
        // xóa sp ở giỏ hàng
        public IActionResult RemoveCart(int id)
        {
            var gioHang = Cart;
            var item = gioHang.SingleOrDefault(p => p.MaHH == id);
            if (item != null)
            {
                gioHang.Remove(item);
                HttpContext.Session.Set(MySetting.CART_KEY, gioHang);
            }
            return RedirectToAction("Index");
        }
        // thanh toán
        [Authorize]
        [HttpGet]
        public IActionResult Checkout()
        {
            if (Cart.Count == 0)
            {
                return Redirect("/");
            }

            return View(Cart);
        }
        [Authorize]
        [HttpPost]
        public IActionResult Checkout(CheckoutVM model)
        {
            // Manually validate required fields
            if (string.IsNullOrWhiteSpace(model.HoTen))
            {
                ModelState.AddModelError("HoTen", "Vui lòng nhập họ tên người nhận");
            }

            if (string.IsNullOrWhiteSpace(model.DiaChi))
            {
                ModelState.AddModelError("DiaChi", "Vui lòng nhập địa chỉ nhận hàng");
            }

            if (string.IsNullOrWhiteSpace(model.DienThoai))
            {
                ModelState.AddModelError("DienThoai", "Vui lòng nhập số điện thoại");
            }

            if (string.IsNullOrWhiteSpace(model.CachThanhToan))
            {
                ModelState.AddModelError("CachThanhToan", "Vui lòng chọn phương thức thanh toán");
            }

            if (ModelState.IsValid)
            {
                if (model.CachThanhToan == "Đến Cửa Hàng")
                {
                    var customerId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "Guest-User";
                    var khachHang = new ApplicationUser();

                    if (model.GiongKhachHang && !string.IsNullOrEmpty(customerId) && customerId != "Guest-User")
                    {
                        khachHang = db.Users.SingleOrDefault(kh => kh.Id == customerId) ?? new ApplicationUser();
                    }

                    var hoadon = new HoaDon
                    {
                        UserId = !string.IsNullOrEmpty(customerId) ? customerId : "Guest-User",
                        HoTen = !string.IsNullOrEmpty(model.HoTen) ? model.HoTen : (khachHang.FullName ?? "Khách hàng"),
                        DiaChi = !string.IsNullOrEmpty(model.DiaChi) ? model.DiaChi : (khachHang.Address ?? "Chưa có địa chỉ"),
                        PhoneNumber = !string.IsNullOrEmpty(model.DienThoai) ? model.DienThoai : (khachHang.PhoneNumber ?? "Chưa có số điện thoại"),
                        NgayDat = DateTime.Now,
                        NgayGiao = DateTime.Now.AddDays(3),
                        CachThanhToan = "Đến Cửa Hàng",
                        CachVanChuyen = "J&T",
                        MaTrangThai = 0,
                        GhiChu = !string.IsNullOrEmpty(model.GhiChu) ? model.GhiChu : "Không có ghi chú",
                        PhiVanChuyen = model.PhiVanChuyen ?? 0,
                    };

                    db.Database.BeginTransaction();
                    try
                    {
                        db.Add(hoadon);
                        db.SaveChanges();

                        var cthds = new List<ChiTietHd>();
                        if (Cart != null && Cart.Any())
                        {
                            foreach (var item in Cart)
                            {
                                cthds.Add(new ChiTietHd
                                {
                                    MaHD = hoadon.MaHD,
                                    SoLuong = item.SoLuong > 0 ? item.SoLuong : 1,
                                    DonGia = item.DonGia > 0 ? item.DonGia : 0,
                                    MaHH = item.MaHH,
                                    GiamGia = 0
                                });
                            }
                            db.AddRange(cthds);
                            db.SaveChanges();
                        }

                        db.Database.CommitTransaction();

                        HttpContext.Session.Set<List<CartItem>>(MySetting.CART_KEY, new List<CartItem>());
                        return View("Success");
                    }
                    catch (Exception ex)
                    {
                        db.Database.RollbackTransaction();
                        // Log exception if you have logging
                        // _logger.LogError(ex, "Error processing store checkout");
                        return View("Error");
                    }
                }
                else if (model.CachThanhToan == "Thanh Toán Momo")
                {
                    //request params need to request to MoMo system
                    string endpoint = "https://test-payment.momo.vn/gw_payment/transactionProcessor";
                    string partnerCode = "MOMOOJOI20210710";
                    string accessKey = "iPXneGmrJH0G8FOP";
                    string serectkey = "sFcbSGRSJjwGxwhhcEktCHWYUuTuPNDB";
                    string orderInfo = "MotoBike Shop";
                    string returnUrl = "https://localhost:44375/Cart/Success";
                    string notifyurl = "https://localhost:44375/Cart/SavePayment";

                    // Null check for TongTien
                    string amount = !string.IsNullOrEmpty(model.TongTien)
                        ? model.TongTien.Replace(".", "").Replace(",00", "").Replace("VND", "").Trim()
                        : Cart.Sum(p => p.ThanhTien).ToString("#").Replace(".", "");

                    string orderid = DateTime.Now.Ticks.ToString();
                    string requestId = DateTime.Now.Ticks.ToString();
                    string extraData = "";

                    //Before sign HMAC SHA256 signature
                    string rawHash = "partnerCode=" +
                        partnerCode + "&accessKey=" +
                        accessKey + "&requestId=" +
                        requestId + "&amount=" +
                        amount + "&orderId=" +
                        orderid + "&orderInfo=" +
                        orderInfo + "&returnUrl=" +
                        returnUrl + "&notifyUrl=" +
                        notifyurl + "&extraData=" +
                        extraData;

                    MoMoSecurity crypto = new MoMoSecurity();
                    //sign signature SHA256
                    string signature = crypto.signSHA256(rawHash, serectkey);

                    //build body json request
                    JObject message = new JObject
            {
                { "partnerCode", partnerCode },
                { "accessKey", accessKey },
                { "requestId", requestId },
                { "amount", amount },
                { "orderId", orderid },
                { "orderInfo", orderInfo },
                { "returnUrl", returnUrl },
                { "notifyUrl", notifyurl },
                { "extraData", extraData },
                { "requestType", "captureMoMoWallet" },
                { "signature", signature }
            };

                    string responseFromMomo = PaymentRequest.sendPaymentRequest(endpoint, message.ToString());

                    JObject jmessage = JObject.Parse(responseFromMomo);

                    if (jmessage.TryGetValue("payUrl", out JToken payUrlToken))
                    {
                        var customerId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "Guest-User";
                        var khachHang = new ApplicationUser();

                        if (model.GiongKhachHang && !string.IsNullOrEmpty(customerId) && customerId != "Guest-User")
                        {
                            khachHang = db.Users.SingleOrDefault(kh => kh.Id == customerId) ?? new ApplicationUser();
                        }

                        var hoadon = new HoaDon
                        {
                            UserId = !string.IsNullOrEmpty(customerId) ? customerId : "Guest-User",
                            HoTen = !string.IsNullOrEmpty(model.HoTen) ? model.HoTen : (khachHang.FullName ?? "Khách hàng"),
                            DiaChi = !string.IsNullOrEmpty(model.DiaChi) ? model.DiaChi : (khachHang.Address ?? "Chưa có địa chỉ"),
                            PhoneNumber = !string.IsNullOrEmpty(model.DienThoai) ? model.DienThoai : (khachHang.PhoneNumber ?? "Chưa có số điện thoại"),
                            NgayDat = DateTime.Now,
                            NgayGiao = DateTime.Now.AddDays(3),
                            CachThanhToan = "MoMo",
                            CachVanChuyen = "J&T",
                            MaTrangThai = 1,
                            GhiChu = !string.IsNullOrEmpty(model.GhiChu) ? model.GhiChu : "Không có ghi chú",
                            PhiVanChuyen = model.PhiVanChuyen ?? 0,
                        };

                        db.Database.BeginTransaction();
                        try
                        {
                            db.Add(hoadon);
                            db.SaveChanges();

                            var cthds = new List<ChiTietHd>();
                            if (Cart != null && Cart.Any())
                            {
                                foreach (var item in Cart)
                                {
                                    cthds.Add(new ChiTietHd
                                    {
                                        MaHD = hoadon.MaHD,
                                        SoLuong = item.SoLuong > 0 ? item.SoLuong : 1,
                                        DonGia = item.DonGia > 0 ? item.DonGia : 0,
                                        MaHH = item.MaHH,
                                        GiamGia = 0
                                    });
                                }
                                db.AddRange(cthds);
                                db.SaveChanges();
                            }

                            db.Database.CommitTransaction();

                            HttpContext.Session.Set<List<CartItem>>(MySetting.CART_KEY, new List<CartItem>());

                            return Redirect(payUrlToken.ToString());
                        }
                        catch (Exception ex)
                        {
                            db.Database.RollbackTransaction();
                            // Log exception if you have logging
                            // _logger.LogError(ex, "Error processing MoMo checkout");
                            return View("Error");
                        }
                    }
                    else
                    {
                        // Handle error when "payUrl" does not exist in the response
                        return View("Error");
                    }
                }
            }

            // If we reach here, model is not valid or something else went wrong
            // Return to the checkout view with existing cart items
            return View(Cart);
        }
        [Authorize]
        public IActionResult GetUserInfo()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
            {
                return Json(new { success = false });
            }

            var user = db.Users.SingleOrDefault(u => u.Id == userId);
            if (user == null)
            {
                return Json(new { success = false });
            }

            return Json(new
            {
                success = true,
                fullName = user.FullName ?? string.Empty,
                address = user.Address ?? string.Empty,
                phoneNumber = user.PhoneNumber ?? string.Empty
            });
        }
        // result check out 
        [Authorize]

        public IActionResult Success()
        {
            return View();
        }
        [Authorize]
        // result check out
        public IActionResult Error()
        {
            return View();
        }
        // giam so luong
        public IActionResult Down(int id)
        {
            var giohang = Cart;
            CartItem item = giohang.Where(p => p.MaHH == id).FirstOrDefault();
            if (item.SoLuong >= 1)
            {
                --item.SoLuong;
            }
            else
            {
                giohang.RemoveAll(p => p.MaHH == id);
            }
            if (giohang.Count == 0)
            {
                HttpContext.Session.Remove(MySetting.CART_KEY);
            }
            else
            {
                HttpContext.Session.Set(MySetting.CART_KEY, giohang);
            }

            return RedirectToAction("Index");
        }
        // tăng số lượng
        public IActionResult Up(int id)
        {
            var giohang = Cart;
            CartItem item = giohang.Where(p => p.MaHH == id).FirstOrDefault();
            if (item.SoLuong >= 1)
            {
                ++item.SoLuong;
            }
            else
            {
                giohang.RemoveAll(p => p.MaHH == id);
            }
            if (giohang.Count == 0)
            {
                HttpContext.Session.Remove(MySetting.CART_KEY);
            }
            else
            {
                HttpContext.Session.Set(MySetting.CART_KEY, giohang);
            }

            return RedirectToAction("Index");
        }


    }
}
