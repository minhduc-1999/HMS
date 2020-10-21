using DTO_Clinic;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
