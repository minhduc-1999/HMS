using DTO_Clinic.Component;
using System.Data.Entity.ModelConfiguration;

namespace DAL_Clinic.BuddyClass
{
    public class CachDungMap : EntityTypeConfiguration<DTO_CachDung>
    {
        public CachDungMap()
        {
            ToTable("CACHDUNG");
            HasKey(p => p.MaCachDung);
            Property(p => p.TenCachDung).HasMaxLength(50);
            Property(p => p.TenCachDung).IsRequired();
        }
    }
}
