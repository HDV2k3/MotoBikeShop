using MotoBikeShop.ViewModels;

namespace MotoBikeShop.Service
{
	public class Models
	{
		public class ApiResponse
		{
			public int Code { get; set; }
			public bool Success { get; set; }
			public long Timestamp { get; set; }
			public required string Message { get; set; } 
			public List<Item> Items { get; set; }
			public  Meta Meta { get; set; }
		}

		public class Item : CTHangHoaVM
		{
			public required string _id { get; set; }
			public required string Title { get; set; }
			public required string Description { get; set; }
			public bool Is_completed { get; set; }
			public DateTime Created_at { get; set; }
			public DateTime Updated_at { get; set; }
		}

		public class Meta
		{
			public int Total_items { get; set; }
			public int Total_pages { get; set; }
			public int Per_page_item { get; set; }
			public int Current_page { get; set; }
			public int Page_size { get; set; }
			public bool Has_more_page { get; set; }
		}
	}
}
