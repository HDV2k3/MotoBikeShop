﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MotoBikeShop.Data
{
	public class ThongSoKyThuat
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		[MaxLength(50)]
		public string khoiluongbanthan { get; set; }
		[MaxLength(50)]
		public string dairongcao { get; set; }
		public string khoangcachtrucxe { get; set; }
		public string docaoyen { get; set; }
		public string khoangsanggamxe { get; set; }
		public string dungtichbinhxang { get; set; }
		public string kichthuocloptruocsau { get; set; }
		public string phuoctruoc { get; set; }
		public string phuocsau { get; set; }
		public string loaidongco { get; set; }
		public string congsuattoida { get; set; }
		public string dungtichnhotmay { get; set; }
		public string muctieuthunhienlieu { get; set; }
		public string loaitruyendong { get; set; }
		public string hethongkhoidong { get; set; }
		public string momentcucdai { get; set; }
		public string dungtichxylanh { get; set; }
		public string duongkinhhanhtrinhpittong { get; set; }

		public string tysonen { get; set; }

		[ForeignKey("HangHoa")]
		public int MaHangHoaNavigation { get; set; }

		public virtual HangHoa HangHoa { get; set; }
	}
}