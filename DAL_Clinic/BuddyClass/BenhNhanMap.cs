using DTO_Clinic.Person;
using System.Data.Entity.ModelConfiguration;

namespace DAL_Clinic.BuddyClass
{
    public class BenhNhanMap: EntityTypeConfiguration<DTO_BenhNhan>
    {
        public BenhNhanMap()
        {
            ToTable("BENHNHAN");
            HasKey(p => p.Id);
            Property(p => p.Id).HasColumnName("MaBenhNhan");
            Property(p => p.HoTen).HasMaxLength(50);
            Property(p => p.HoTen).IsRequired();
            Property(p => p.Cmnd).IsRequired();
            Property(p => p.Cmnd).HasColumnName("SoCMND");
            Property(p => p.NgaySinh).IsRequired();
            Property(p => p.DiaChi).IsOptional();
            Property(p => p.SoDienThoai).IsRequired();
            Property(p => p.Email).IsOptional();
        }
    }
}
