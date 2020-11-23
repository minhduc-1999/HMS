using DTO_Clinic;
using DTO_Clinic.Component;
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
            HasKey(p => p.MaThuoc);
            Property(p => p.TenThuoc).HasMaxLength(50);
            Property(p => p.DonGia).IsRequired();
            Property(p => p.TenThuoc).IsRequired();
            Property(p => p.SoLuong).IsRequired();
            Property(p => p.DonVi).IsRequired();
            Property(p => p.DonVi).HasMaxLength(50);
        }
    }
}
