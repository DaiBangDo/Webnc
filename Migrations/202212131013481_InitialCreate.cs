namespace WebApplication8.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DanhMuc",
                c => new
                    {
                        MaDanhMuc = c.Int(nullable: false, identity: true),
                        TenDanhMuc = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.MaDanhMuc);
            
            CreateTable(
                "dbo.SanPham",
                c => new
                    {
                        MaSP = c.Int(nullable: false, identity: true),
                        TenSP = c.String(nullable: false, maxLength: 50),
                        SoLuong = c.Int(nullable: false),
                        GiaBan = c.Int(nullable: false),
                        MaDanhMuc = c.Int(nullable: false),
                        Anh = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.MaSP)
                .ForeignKey("dbo.DanhMuc", t => t.MaDanhMuc)
                .Index(t => t.MaDanhMuc);
            
            CreateTable(
                "dbo.DonHang",
                c => new
                    {
                        MaDonHang = c.Int(nullable: false, identity: true),
                        MaSP = c.Int(nullable: false),
                        SoLuong = c.Int(nullable: false),
                        TrangThai = c.String(nullable: false, maxLength: 50),
                        MaHoaDon = c.Int(nullable: false),
                        NgayMua = c.DateTime(nullable: false, storeType: "date"),
                        ThanhTien = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MaDonHang)
                .ForeignKey("dbo.HoaDon", t => t.MaHoaDon)
                .ForeignKey("dbo.SanPham", t => t.MaSP)
                .Index(t => t.MaSP)
                .Index(t => t.MaHoaDon);
            
            CreateTable(
                "dbo.HoaDon",
                c => new
                    {
                        MaHoaDon = c.Int(nullable: false, identity: true),
                        TaiKhoan = c.String(nullable: false, maxLength: 50),
                        TrangThai = c.String(nullable: false, maxLength: 50),
                        TongTien = c.Int(nullable: false),
                        NgayBan = c.DateTime(nullable: false, storeType: "date"),
                    })
                .PrimaryKey(t => t.MaHoaDon)
                .ForeignKey("dbo.NguoiDung", t => t.TaiKhoan)
                .Index(t => t.TaiKhoan);
            
            CreateTable(
                "dbo.NguoiDung",
                c => new
                    {
                        TaiKhoan = c.String(nullable: false, maxLength: 50),
                        MatKhau = c.String(nullable: false, maxLength: 50),
                        Quyen = c.String(nullable: false, maxLength: 50),
                        HoTen = c.String(nullable: false, maxLength: 50),
                        DiaChi = c.String(nullable: false, maxLength: 50),
                        SDT = c.String(nullable: false, maxLength: 10, fixedLength: true, unicode: false),
                    })
                .PrimaryKey(t => t.TaiKhoan);
            
            CreateTable(
                "dbo.sysdiagrams",
                c => new
                    {
                        diagram_id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 128),
                        principal_id = c.Int(nullable: false),
                        version = c.Int(),
                        definition = c.Binary(),
                    })
                .PrimaryKey(t => t.diagram_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SanPham", "MaDanhMuc", "dbo.DanhMuc");
            DropForeignKey("dbo.DonHang", "MaSP", "dbo.SanPham");
            DropForeignKey("dbo.HoaDon", "TaiKhoan", "dbo.NguoiDung");
            DropForeignKey("dbo.DonHang", "MaHoaDon", "dbo.HoaDon");
            DropIndex("dbo.HoaDon", new[] { "TaiKhoan" });
            DropIndex("dbo.DonHang", new[] { "MaHoaDon" });
            DropIndex("dbo.DonHang", new[] { "MaSP" });
            DropIndex("dbo.SanPham", new[] { "MaDanhMuc" });
            DropTable("dbo.sysdiagrams");
            DropTable("dbo.NguoiDung");
            DropTable("dbo.HoaDon");
            DropTable("dbo.DonHang");
            DropTable("dbo.SanPham");
            DropTable("dbo.DanhMuc");
        }
    }
}
