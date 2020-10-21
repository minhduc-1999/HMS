using DTO_Clinic;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Clinic.BuddyClass
{
    public class BCDoanhThuMap : EntityTypeConfiguration<DTO_BCDoanhThu>
    {
        public BCDoanhThuMap()
        {
            ToTable("BC_DOANHTHU");
            HasKey(o => new { o.Thang, o.Nam });
            Property(p => p.TongDoanhThu).IsRequired();
        }
    }
}
