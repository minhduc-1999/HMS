using DTO_Clinic;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Clinic.BuddyClass
{
    public class PhieuNhapThuocMap : EntityTypeConfiguration<DTO_PhieuNhapThuoc>
    {
        public PhieuNhapThuocMap()
        {
            ToTable("PHIEUNHAPTHUOC");
            HasKey(p => p.Id);
            Property(p => p.Id).HasColumnName("MaPNT");
            Property(p => p.NgayNhap).IsRequired();
            Property(p => p.TongTien).IsRequired();
        }
    }
}
