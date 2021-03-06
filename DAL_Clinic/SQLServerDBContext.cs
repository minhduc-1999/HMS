﻿using DAL_Clinic.BuddyClass;
using DTO_Clinic;
using DTO_Clinic.Component;
using DTO_Clinic.Form;
using DTO_Clinic.Permission;
using DTO_Clinic.Person;
using System.Data.Entity;

namespace DAL_Clinic
{
    internal class SQLServerDBContext : DbContext
    {
        public SQLServerDBContext() : base("name=connectionStringPMT")
        {
            var initializer = new MigrateDatabaseToLatestVersion<SQLServerDBContext, Migrations.Configuration>();
            Database.SetInitializer(initializer);
            this.Configuration.LazyLoadingEnabled = false;
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new BenhNhanMap());
            modelBuilder.Configurations.Add(new PKDaKhoaMap());
            modelBuilder.Configurations.Add(new PKChuyenKhoaMap());
            modelBuilder.Configurations.Add(new NhanVienMap());
            modelBuilder.Configurations.Add(new PhongMap());
            modelBuilder.Configurations.Add(new ThuocMap());
            modelBuilder.Configurations.Add(new BenhMap());
            modelBuilder.Configurations.Add(new CachDungMap());
            modelBuilder.Configurations.Add(new PhieuNhapThuocMap());
            modelBuilder.Configurations.Add(new CT_PhieuNhapThuocMap());
            modelBuilder.Configurations.Add(new BCDoanhThuMap());
            modelBuilder.Configurations.Add(new CT_BCDoanhThuMap());
            modelBuilder.Configurations.Add(new BCSuDungThuocMap());
            modelBuilder.Configurations.Add(new ThamSoMap());
            modelBuilder.Configurations.Add(new HoaDonMap());
            modelBuilder.Configurations.Add(new CTHDThuocMap());
            modelBuilder.Configurations.Add(new CT_DonThuocMap());
            modelBuilder.Configurations.Add(new DonThuocMap());
            modelBuilder.Configurations.Add(new AccountMap());
            modelBuilder.Configurations.Add(new GroupMap());
        }
        public DbSet<DTO_Account> Account { get; set; }
        public DbSet<DTO_Group> Group { get; set; }
        public DbSet<DTO_BenhNhan> BenhNhan { get; set; }
        public DbSet<DTO_PKDaKhoa> PKDaKhoa { get; set; }
        public DbSet<DTO_PKChuyenKhoa> PKChuyenKhoa { get; set; }
        public DbSet<DTO_Benh> Benh { get; set; }
        public DbSet<DTO_CachDung> CachDung { get; set; }
        public DbSet<DTO_DonThuoc> DonThuoc { get; set; }
        public DbSet<DTO_HoaDon> HoaDon { get; set; }
        public DbSet<DTO_CTHDThuoc> CTHoaDdonThuoc { get; set; }
        public DbSet<DTO_PhieuNhapThuoc> PhieuNhapThuoc { get; set; }
        public DbSet<DTO_CTPhieuNhapThuoc> CTPhieuNhapThuoc { get; set; }
        public DbSet<DTO_Thuoc> Thuoc { get; set; }
        public DbSet<DTO_BCDoanhThu> BaoCaoDoanhThu { get; set; }
        public DbSet<DTO_CTBaoCaoDoanhThu> CT_BaoCaoDoanhThu { get; set; }
        public DbSet<DTO_BCSudungThuoc> BaoCaoSuDungThuoc { get; set; }
        public DbSet<DTO_ThamSo> ThamSo { get; set; }
        public DbSet<DTO_NhanVien> NhanVien { get; set; }
        public DbSet<DTO_Phong> Phong { get; set; }
        public DbSet<DTO_CTDonThuoc> CT_DonThuoc { get; set; }
    }
}
