using DTO_Clinic;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Clinic.BuddyClass
{
    public class CachDungMap : EntityTypeConfiguration<DTO_CachDung>
    {
        public CachDungMap()
        {
            ToTable("CACHDUNG");
            HasKey(p => p.Id);
            Property(p => p.Id).HasColumnName("MaCachDung");
            Property(p => p.TenCachDung).HasMaxLength(50);
            Property(p => p.TenCachDung).IsRequired();
        }
    }
}
