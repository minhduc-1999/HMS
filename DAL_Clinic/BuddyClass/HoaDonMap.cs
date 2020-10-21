using DTO_Clinic;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Clinic.BuddyClass
{
    public class HoaDonMap : EntityTypeConfiguration<DTO_HoaDon>
    {
        public HoaDonMap()
        {
            ToTable("HOADON");
            HasKey(p => p.Id);
            Property(p => p.Id).HasColumnName("MaPKB");
            Property(p => p.TienKham).IsRequired();
            Property(p => p.TienThuoc).IsRequired();
            Property(p => p.ThanhTien).IsRequired();
        }
    }
}
