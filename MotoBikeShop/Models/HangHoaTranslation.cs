using MotoBikeShop.Data;
using System.ComponentModel.DataAnnotations;

namespace MotoBikeShop.Models
{
    public class HangHoaTranslation
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int MaHH { get; set; }

        [Required]
        [StringLength(10)]
        public string LanguageCode { get; set; }

        [Required]
        [StringLength(200)]
        public string TenHH { get; set; }

        [StringLength(4000)]
        public string MoTa { get; set; }

        [StringLength(500)]
        public string MoTaNgan { get; set; }

        // Foreign key
        public HangHoa HangHoa { get; set; }
    }
}
