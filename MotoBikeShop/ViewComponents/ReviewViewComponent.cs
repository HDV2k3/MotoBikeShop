using Microsoft.AspNetCore.Mvc;
using MotoBikeShop.ViewModels;
using Newtonsoft.Json;
using NuGet.Protocol;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using MotoBikeShop.Models;
namespace MotoBikeShop.ViewComponents
{
	[ViewComponent(Name = "Review")]
	public class ReviewViewComponent : ViewComponent
    {
        private readonly HttpClient httpClient;

        public ReviewViewComponent(IHttpClientFactory httpClientFactory)
        {
			//httpClient = new HttpClient();
			httpClient = httpClientFactory.CreateClient();
		}

        public async Task<IViewComponentResult> InvokeAsync()
        {
            HttpResponseMessage response = await httpClient.GetAsync("https://api.nstack.in/v1/todos?page=1&limit=10");

            if (response.IsSuccessStatusCode)
            {
                string jsonContent = await response.Content.ReadAsStringAsync();

                var result = JsonConvert.DeserializeObject<Service.Models.ApiResponse>(jsonContent);

                List<Service.Models.Item> data = result.Items;

                return View(data);
            }
            else
            {
              

                return View();
            }
        }
    }
}