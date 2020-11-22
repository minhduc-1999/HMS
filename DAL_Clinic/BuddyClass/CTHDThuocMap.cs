using DTO_Clinic.Form;
using System.Data.Entity.ModelConfiguration;

namespace DAL_Clinic.BuddyClass
{
    public class CTHDThuocMap : EntityTypeConfiguration<DTO_CTHDThuoc>
    {
        public CTHDThuocMap()
        {
            ToTable("CT_HOADONTHUOC");
            HasKey(p => p.MaCTHDThuoc);
            Property(p => p.SoLuong).IsRequired();
            Property(p => p.DonGia).IsRequired();
            //ref to HOADON
            HasRequired(p => p.HoaDon)
                .WithMany(o => o.DS_Thuoc)
                .HasForeignKey(p => p.MaHoaDon);
            //ref to THUOC
            HasRequired(p => p.Thuoc)
                .WithMany(o => o.DS_CTHoaDonThuoc)
                .HasForeignKey(p => p.MaThuoc);
        }
    }
}
