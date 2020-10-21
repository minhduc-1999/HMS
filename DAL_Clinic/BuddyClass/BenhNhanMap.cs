using DTO_Clinic;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Clinic.BuddyClass
{
    public class BenhNhanMap: EntityTypeConfiguration<DTO_BenhNhan>
    {
        public BenhNhanMap()
        {
            ToTable("BENHNHAN");
            HasKey(p => p.Id);
            Property(p => p.Id).HasColumnName("MaBenhNhan");
            Property(p => p.TenBenhNhan).HasMaxLength(50);
            Property(p => p.TenBenhNhan).IsRequired();
            Property(p => p.NgaySinh).IsRequired();
            Property(p => p.DiaChi).IsOptional();
            Property(p => p.SoDienThoai).IsRequired();
        }
    }
}
