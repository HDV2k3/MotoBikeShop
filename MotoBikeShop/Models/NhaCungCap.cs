using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MotoBikeShop.Data
{
    public class NhaCungCap
    {
        [Key]
        public string MaNCC { get; set; }

        [Required]
        [MaxLength(50)]
        public string TenCongTy { get; set; }

        public string Logo { get; set; }

        [MaxLength(50)]
        public string NguoiLienLac { get; set; }

        [Required]
        [MaxLength(50)]
        public string Email { get; set; }

        [MaxLength(50)]
        public string DienThoai { get; set; }

        public string DiaChi { get; set; }

        public string MoTa { get; set; }
       
    }
}