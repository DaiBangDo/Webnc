namespace WebApplication8.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Configuration;
    using System.Data;
    using System.Data.Entity.Spatial;
    using System.Data.SqlClient;
    using static System.Configuration.ConfigurationManager;

    [Table("SanPham")]
    public partial class SanPham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SanPham()
        {
            DonHangs = new HashSet<DonHang>();
        }

        [Key]
        public int MaSP { get; set; }

        [Required]
        [StringLength(50)]
        public string TenSP { get; set; }

        public int SoLuong { get; set; }

        [DataType(DataType.Currency)]
        [Range(1, int.MaxValue, ErrorMessage = "Giá phải lớn hơn 0")]
        public int GiaBan { get; set; }

        public int MaDanhMuc { get; set; }

        [StringLength(50)]
        public string Anh { get; set; }

        public virtual DanhMuc DanhMuc { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DonHang> DonHangs { get; set; }

        internal List<SanPham> getAllSP()
        {
            var listsp = new List<SanPham>();
            var conn = new SqlConnection(ConnectionStrings[1].ConnectionString);
            var adt = new SqlDataAdapter("select * from SanPham", conn);
            var dt = new DataTable();
            adt.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                var sp = new SanPham
                {
                    MaSP = Convert.ToInt32(dr["MaSP"]),
                    TenSP = dr["TenSP"].ToString(),
                    SoLuong = Convert.ToInt32(dr["SoLuong"]),
                    GiaBan = Convert.ToInt32(dr["GiaBan"]),
                    MaDanhMuc = Convert.ToInt32(dr["MaDanhMuc"]),
                    Anh = dr["Anh"].ToString()
                };
                listsp.Add(sp);
            }
            return listsp;
        }

        internal SanPham GetSanPham(string id)
        {
            try
            {
                var conn = new SqlConnection(ConnectionStrings[1].ConnectionString);
                var cmd = new SqlCommand
                {
                    Connection = conn,
                    CommandText = "select * from SanPham where MaSP = @MaSP"
                };
                cmd.Parameters.AddWithValue("MaSP", id);
                var sda = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    var sp = new SanPham
                    {
                        MaSP = Convert.ToInt32(dt.Rows[0]["MaSP"]),
                        TenSP = dt.Rows[0]["TenSP"].ToString(),
                        SoLuong = Convert.ToInt32(dt.Rows[0]["SoLuong"]),
                        GiaBan = Convert.ToInt32(dt.Rows[0]["GiaBan"]),
                        MaDanhMuc = Convert.ToInt32(dt.Rows[0]["MaDanhMuc"]),
                        Anh = dt.Rows[0]["Anh"].ToString()
                    };
                    return sp;
                }
                return null;
            }
            catch
            {
                return null;
            }
        }

        internal List<SanPham> getSanPhambyLoai(string id)
        {
            var listsp = new List<SanPham>();
            var conn = new SqlConnection(ConnectionStrings[1].ConnectionString);
            var adt = new SqlDataAdapter("select * from SanPham where MaDanhMuc = @MaDanhMuc", conn);
            adt.SelectCommand.Parameters.AddWithValue("MaDanhMuc", id);
            var dt = new DataTable();
            adt.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                var sp = new SanPham
                {
                    MaSP = Convert.ToInt32(dr["MaSP"]),
                    TenSP = dr["TenSP"].ToString(),
                    SoLuong = Convert.ToInt32(dr["SoLuong"]),
                    GiaBan = Convert.ToInt32(dr["GiaBan"]),
                    MaDanhMuc = Convert.ToInt32(dr["MaDanhMuc"]),
                    Anh = dr["Anh"].ToString()
                };
                listsp.Add(sp);
            }
            return listsp;
        }
    }
}