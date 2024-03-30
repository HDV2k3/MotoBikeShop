using Microsoft.AspNetCore.Mvc;

namespace MotoBikeShop.Models
{
    public class ReviewModel
    {
        public required string title { get; set; }
        public required string description { get; set; }
    }
}
