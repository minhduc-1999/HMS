using DTO_Clinic.Component;
using System.Data.Entity.ModelConfiguration;

namespace DAL_Clinic.BuddyClass
{
    public class BenhMap : EntityTypeConfiguration<DTO_Benh>
    {
        public BenhMap()
        {            
            ToTable("BENH");
            HasKey(p => p.MaBenh);
            Property(p => p.TenBenh).HasMaxLength(50);
            Property(p => p.TenBenh).IsRequired();
        }
    }
}
