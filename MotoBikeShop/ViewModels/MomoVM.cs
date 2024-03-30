namespace MotoBikeShop.ViewModels
{
	public class MomoVM
	{
		public required string partnerCode { get; set; }
		public required string accessKey { get; set; }
		public required string requestId { get; set; }
		public required string amount { get; set; }
		public required string orderId { get; set; }
		public required string orderInfo { get; set; }
		public required string orderType { get; set; }
		public required string transId { get; set; }
		public required string message { get; set; }
		public required string localMessage { get; set; }
		public required string responseTime { get; set; }
		public required	string errorCode { get; set; }
		public required string payType { get; set; }
		public required string extraData { get; set; }
		public required string signature { get; set; }
	}

	public class MomoRequsetVM
	{
		public required string message { get; set; }
		public required string orderId { get; set; }
		public required	string errorCode { get; set; }

	}
}
