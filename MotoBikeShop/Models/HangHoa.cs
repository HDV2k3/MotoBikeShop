using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MotoBikeShop.Data
{
    public class HangHoa
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaHH { get; set; }

        [Required]
        [MaxLength(50)]
        public string TenHH { get; set; }

        [MaxLength(50)]
        public string TenAlias { get; set; }

        public int MaLoai { get; set; }

        [MaxLength(50)]
        public string MoTaDonVi { get; set; }

        public double? DonGia { get; set; }

        [MaxLength(50)]
        public string Hinh { get; set; }

        [Required]
        public DateTime NgaySX { get; set; }

        public double GiamGia { get; set; }

        public int SoLanXem { get; set; }

        public string MoTa { get; set; }
        public string? ThietKe { get; set; }
        public string? DongCoCongNghe { get; set; }
        public string? TienIchAnToan { get; set; }

        [Required]
 
        public string MaNCC { get; set; }

        public virtual ICollection<ChiTietHd> ChiTietHds { get; set; } = new List<ChiTietHd>();

        public virtual ICollection<YeuThich> YeuThiches { get; set; } = new List<YeuThich>();

        [ForeignKey("MaLoai")]
        public virtual Loai MaLoaiNavigation { get; set; } = null!;

        [ForeignKey("MaNCC")]
        public virtual NhaCungCap MaNccNavigation { get; set; } = null!;       
    }
}