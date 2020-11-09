using DTO_Clinic.Component;
using System.Data.Entity.ModelConfiguration;

namespace DAL_Clinic.BuddyClass
{
    public class DonViMap : EntityTypeConfiguration<DTO_DonVi>
    {
        public DonViMap()
        {
            ToTable("DONVI");
            HasKey(p => p.Id);
            Property(p => p.Id).HasColumnName("MaDonVi");
            Property(p => p.TenDonVi).HasMaxLength(50);
            Property(p => p.TenDonVi).IsRequired();
        }
    }
}
