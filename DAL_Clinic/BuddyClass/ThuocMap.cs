using DTO_Clinic;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Clinic.BuddyClass
{
    public class ThuocMap : EntityTypeConfiguration<DTO_Thuoc>
    {
        public ThuocMap()
        {
            //Create ref to table DONVI
            HasRequired(e => e.DonVi)
                .WithMany(p => p.DSThuoc)
                .HasForeignKey(e => e.MaDonVi)
                .WillCascadeOnDelete();
            //create ref in table CT_PHIEUNHAPTHUOC
            HasMany(p => p.DS_CTPhieuNhapThuoc)
                .WithRequired(e => e.Thuoc)
                .HasForeignKey(e => e.MaThuoc)
                .WillCascadeOnDelete();
            //ceate ref in table CT_BCSuDungThuoc
            HasMany(p => p.DS_BCSuDungThuoc)
                .WithRequired(e => e.Thuoc)
                .HasForeignKey(e => e.MaThuoc)
                .WillCascadeOnDelete();
            ToTable("THUOC");
            HasKey(p => p.Id);
            Property(p => p.Id).HasColumnName("MaThuoc");
            Property(p => p.TenThuoc).HasMaxLength(50);
            Property(p => p.DonGia).IsRequired();
            Property(p => p.TenThuoc).IsRequired();
            Property(p => p.SoLuong).IsRequired();
        }
    }
}
