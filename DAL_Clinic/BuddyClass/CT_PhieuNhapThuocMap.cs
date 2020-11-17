using DTO_Clinic.Form;
using System.Data.Entity.ModelConfiguration;

namespace DAL_Clinic.BuddyClass
{
    public class CT_PhieuNhapThuocMap : EntityTypeConfiguration<DTO_CTPhieuNhapThuoc>
    {
        public CT_PhieuNhapThuocMap()
        {
            //create ref to table CT_PHIEUNHAPTHUOC
            HasRequired(e => e.PhieuNhapThuoc)
                .WithMany(p => p.DS_CTPhieuNhapThuoc)
                .HasForeignKey(e => e.MaPNT)
                .WillCascadeOnDelete();
            ToTable("CT_PHIEUNHAPTHUOC");
            HasKey(o => new { o.MaPNT, o.MaThuoc });
            Property(p => p.SoLuongNhap).IsRequired();
            Property(p => p.DonGiaNhap).IsRequired();
        }
    }
}
