using DTO_Clinic;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Clinic.BuddyClass
{
    public class PhieuKhamBenhMap:EntityTypeConfiguration<DTO_PhieuKhamBenh>
    {
        public PhieuKhamBenhMap()
        {
            //create ref to table BENHNHAN
            HasRequired(e => e.BenhNhan)
                .WithMany(p => p.DSPhieuKhamBenh)
                .HasForeignKey(e => e.MaBenhNhan)
                .WillCascadeOnDelete();
            //create ref in table CT_PHIEUKHAMBENH
            HasMany(p => p.DSCTPhieuKhamBenh)
                .WithRequired(e => e.PhieuKhamBenh)
                .HasForeignKey(e => e.MaPKB)
                .WillCascadeOnDelete();
            //create ref to table BENH
            HasRequired(e => e.Benh)
                .WithMany(p => p.DS_PhieuKhamBenh)
                .HasForeignKey(e => e.MaBenh)
                .WillCascadeOnDelete();
            //create ref with table HOADON
            HasRequired(p => p.HoaDon)
                .WithRequiredPrincipal(e => e.PhieuKhamBenh)
                .WillCascadeOnDelete();
            ToTable("PHIEUKHAMBENH");
            HasKey(p => p.Id);
            Property(p => p.Id).HasColumnName("MaPKB");
            Property(p => p.NgayKham).IsRequired();
            Property(p => p.TrieuChung).IsOptional();
        }
    }
}
