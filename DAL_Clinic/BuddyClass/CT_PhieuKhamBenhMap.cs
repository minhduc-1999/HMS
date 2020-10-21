using DTO_Clinic;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Clinic.BuddyClass
{
    public class CT_PhieuKhamBenhMap : EntityTypeConfiguration<DTO_CTPhieuKhamBenh>
    {
        public CT_PhieuKhamBenhMap()
        {
            //create ref to table THUOC
            HasRequired(e => e.Thuoc)
                .WithMany(p => p.DS_CTPhieuKhamBenh)
                .HasForeignKey(e => e.MaThuoc)
                .WillCascadeOnDelete();
            //create ref to table CACHDUNG
            HasRequired(e => e.CachDung)
                .WithMany(p => p.DS_CTPhieuKhamBenh)
                .HasForeignKey(e => e.MaCachDung)
                .WillCascadeOnDelete();
            ToTable("CT_PHIEUKHAMBENH");
            HasKey(o => new { o.MaPKB, o.MaThuoc });
            Property(p => p.DonGia).IsRequired();
            Property(p => p.SoLuong).IsRequired();
            Property(p => p.ThanhTien).IsRequired();
        }
    }
}
