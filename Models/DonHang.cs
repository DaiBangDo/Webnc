namespace WebApplication8.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DonHang")]
    public partial class DonHang
    {
        [Key]
        public int MaDonHang { get; set; }

        public int MaSP { get; set; }

        public int SoLuong { get; set; }

        [Required]
        [StringLength(50)]
        public string TrangThai { get; set; }

        public int MaHoaDon { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgayMua { get; set; }

        public int ThanhTien { get; set; }

        public virtual HoaDon HoaDon { get; set; }

        public virtual SanPham SanPham { get; set; }
    }
}
