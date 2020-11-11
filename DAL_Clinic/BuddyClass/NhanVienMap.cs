using DTO_Clinic.Person;
using System.Data.Entity.ModelConfiguration;

namespace DAL_Clinic.BuddyClass
{
    public class NhanVienMap : EntityTypeConfiguration<DTO_NhanVien>
    {
        public NhanVienMap()
        {
            ToTable("NHANVIEN");
            HasKey(p => p.Id);
            Property(p => p.Id).HasColumnName("MaNV");
            Property(p => p.HoTen).IsRequired();
            Property(p => p.HoTen).HasMaxLength(50);
            Property(p => p.Cmnd).IsRequired();
            Property(p => p.Cmnd).HasColumnName("SoCMND");
            Property(p => p.GioiTinh).IsRequired();
            Property(p => p.NgaySinh).IsRequired();
            Property(p => p.SoDienThoai).IsRequired();
            Property(p => p.Email).IsOptional();
            Property(p => p.DiaChi).IsRequired();
            //reference to PHONG table
            HasRequired(p => p.Phong)
                .WithMany(m => m.DS_NhanVien)
                .HasForeignKey(p => p.MaPhong)
                .WillCascadeOnDelete();

        }
    }
}
