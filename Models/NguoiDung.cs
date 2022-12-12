namespace WebApplication8.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NguoiDung")]
    public partial class NguoiDung
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NguoiDung()
        {
            HoaDons = new HashSet<HoaDon>();
        }

        [Key]
        [StringLength(50)]
        [Display(Name = "Tài khoản")]
        // regex
        [RegularExpression(@"^[A-Za-z][A-Za-z0-9_-]{7,49}$", ErrorMessage = "Tên tàu khoản không hợp lệ")]
        public string TaiKhoan { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Mật khẩu")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,50}$", ErrorMessage = "Mật khẩu không đạt yêu cầu")]
        public string MatKhau { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Quyền hạn")]

        public string Quyen { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Họ tên")]
        public string HoTen { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Địa chỉ")]
        public string DiaChi { get; set; }
        
        [Required]
        [StringLength(10)]
        [Display(Name = "Số điện thoại")]
        [RegularExpression(@"^0[0-9]{9}$", ErrorMessage = "Số điện thoại không hợp lệ")]
        public string SDT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoaDon> HoaDons { get; set; }
    }
}
