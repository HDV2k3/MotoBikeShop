using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MotoBikeShop.Models;
using MotoBikeShop.ViewModels;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MotoBikeShop.Data
{
    public class HoaDon
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaHD { get; set; }

        [Required]
        public DateTime NgayDat { get; set; }

        public DateTime? NgayGiao { get; set; }

        [MaxLength(50)]
        public string HoTen { get; set; }

        [Required]
        [MaxLength(60)]
        public string DiaChi { get; set; }

        [Required]
        [MaxLength(50)]
        public string CachThanhToan { get; set; }

        [Required]
        [MaxLength(50)]
        public string CachVanChuyen { get; set; }

        public double PhiVanChuyen { get; set; }

        public int MaTrangThai { get; set; }

        [MaxLength(50)]

        public string GhiChu { get; set; }

        public string PhoneNumber { get; set; }
       
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }
        public virtual ICollection<ChiTietHd> ChiTietHds { get; set; } = new List<ChiTietHd>();
    }
}