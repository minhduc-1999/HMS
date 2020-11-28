using DTO_Clinic.Form;
using System.Data.Entity.ModelConfiguration;

namespace DAL_Clinic.BuddyClass
{
    public class PhieuNhapThuocMap : EntityTypeConfiguration<DTO_PhieuNhapThuoc>
    {
        public PhieuNhapThuocMap()
        {
            ToTable("PHIEUNHAPTHUOC");
            HasKey(p => p.MaPNT);
            Property(p => p.NgayNhap).IsRequired();
            Property(p => p.TongTien).IsRequired();
            //ref to duoc si
            HasRequired(p => p.NguoiLap)
                .WithMany(ds => ds.DS_PhieuNhapThuoc)
                .HasForeignKey(p => p.MaDuocSi);
        }
    }
}
