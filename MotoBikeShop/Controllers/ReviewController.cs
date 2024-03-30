using Microsoft.AspNetCore.Mvc;
using MotoBikeShop.Models;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MotoBikeShop.Controllers
{
	public class ReviewController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public ReviewController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		[HttpPost]
		public async Task<IActionResult> SubmitReview(string fullName, string review)
		{
			// Xử lý dữ liệu tại đây và gửi lên API

			var model = new ReviewModel
			{
				title = fullName,
				description = review
			};

			var httpClient = _httpClientFactory.CreateClient();

			var requestContent = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");

			var response = await httpClient.PostAsync("https://api.nstack.in/v1/todos", requestContent); 

			if (response.IsSuccessStatusCode)
			{
				// Xử lý thành công, ví dụ: hiển thị thông báo thành công
				ViewBag.Message = "Đã gửi đánh giá thành công!";
			}
			else
			{
				// Xử lý lỗi, ví dụ: hiển thị thông báo lỗi
				ViewBag.Message = "Đã xảy ra lỗi khi gửi đánh giá.";
			}

            // Chuyển hướng người dùng đến một view khác hoặc hiển thị trang hiện tại
            return View(model);
        }
	}
}