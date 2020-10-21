using DTO_Clinic;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Clinic.BuddyClass
{
    public class BenhMap : EntityTypeConfiguration<DTO_Benh>
    {
        public BenhMap()
        {            
            ToTable("BENH");
            HasKey(p => p.Id);
            Property(p => p.Id).HasColumnName("MaBenh");
            Property(p => p.TenBenh).HasMaxLength(50);
            Property(p => p.TenBenh).IsRequired();
        }
    }
}
