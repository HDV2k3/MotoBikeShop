using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MotoBikeShop.Data
{
    public class Loai
    {
        [Key]
        public int MaLoai { get; set; }

        [Required]
        [MaxLength(50)]
        public string TenLoai { get; set; }

        [MaxLength(50)]
        public string TenLoaiAlias { get; set; }

        public string MoTa { get; set; }

        [MaxLength(50)]
        public string Hinh { get; set; }
        public virtual ICollection<HangHoa> HangHoas { get; set; } = new List<HangHoa>();
      
    }
}