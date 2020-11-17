using DTO_Clinic.Person;
using System.Data.Entity.ModelConfiguration;

namespace DAL_Clinic.BuddyClass
{
    public class BenhNhanMap: EntityTypeConfiguration<DTO_BenhNhan>
    {
        public BenhNhanMap()
        {
            ToTable("BENHNHAN");
            HasKey(p => p.MaBenhNhan);
            Property(p => p.HoTen).IsRequired();
            Property(p => p.SoCMND).IsRequired();
            Property(p => p.NgaySinh).IsRequired();
            Property(p => p.DiaChi).IsOptional();
            Property(p => p.SoDienThoai).IsRequired();
            Property(p => p.Email).IsOptional();

            Property(p => p.SoCMND).HasMaxLength(20);
            Property(p => p.HoTen).HasMaxLength(50);
            Property(p => p.SoDienThoai).HasMaxLength(20);
            Property(p => p.Email).HasMaxLength(50);
        }
    }
}
