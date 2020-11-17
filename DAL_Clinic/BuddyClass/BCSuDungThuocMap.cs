using DTO_Clinic;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Clinic.BuddyClass
{
    public class BCSuDungThuocMap : EntityTypeConfiguration<DTO_BCSudungThuoc>
    {
        public BCSuDungThuocMap()
        {
            ToTable("BC_SUDUNGTHUOC");
            HasKey(o => new { o.Thang, o.Nam , o.MaThuoc});
            Property(p => p.SoLanDung).IsRequired();
            Property(p => p.SoLuongDung).IsRequired();
        }
    }
}
