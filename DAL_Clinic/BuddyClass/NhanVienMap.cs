using DTO_Clinic.Person;
using System.Data.Entity.ModelConfiguration;

namespace DAL_Clinic.BuddyClass
{
    public class NhanVienMap : EntityTypeConfiguration<DTO_NhanVien>
    {
        public NhanVienMap()
        {
            ToTable("NHANVIEN");
            HasKey(p => p.MaNhanVien);
            HasIndex(p => p.SoCMND)
                .IsUnique();
            Property(p => p.HoTen).IsRequired();
            Property(p => p.SoCMND).IsRequired();
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
            HasRequired(ac => ac.Nhom)
                .WithMany(gr => gr.DS_NhanVien)
                .HasForeignKey(ac => ac.MaNhom);
            Property(p => p.HoTen).HasMaxLength(50);
            Property(p => p.SoCMND).HasMaxLength(20);
            Property(p => p.SoDienThoai).HasMaxLength(20);
            Property(p => p.Email).HasMaxLength(50);
        }
    }
}
