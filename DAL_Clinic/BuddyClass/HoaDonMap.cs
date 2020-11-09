using DTO_Clinic;
using DTO_Clinic.Form;
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
            Property(p => p.ThanhTien).IsRequired();
            Property(p => p.ChiTiet).IsRequired();
        }
    }
}
