using DTO_Clinic;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Clinic.BuddyClass
{
    public class ThamSoMap: EntityTypeConfiguration<DTO_ThamSo>
    {
        public ThamSoMap()
        {
            ToTable("THAMSO");
            HasKey(o => o.TenThamSo);
            Property(p => p.TenThamSo).HasMaxLength(50);
            Property(p => p.GiaTri).IsRequired();
        }
    }
}
