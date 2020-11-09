using DTO_Clinic.Form;
using System.Data.Entity.ModelConfiguration;

namespace DAL_Clinic.BuddyClass
{
    public class PhieuNhapThuocMap : EntityTypeConfiguration<DTO_PhieuNhapThuoc>
    {
        public PhieuNhapThuocMap()
        {
            ToTable("PHIEUNHAPTHUOC");
            HasKey(p => p.Id);
            Property(p => p.Id).HasColumnName("MaPNT");
            Property(p => p.NgayNhap).IsRequired();
            Property(p => p.TongTien).IsRequired();
        }
    }
}
