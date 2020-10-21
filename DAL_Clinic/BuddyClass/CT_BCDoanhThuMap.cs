using DTO_Clinic;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Clinic.BuddyClass
{
    public class CT_BCDoanhThuMap : EntityTypeConfiguration<DTO_CTBaoCaoDoanhThu>
    {
        public CT_BCDoanhThuMap()
        {
            //create ref to table BCDOANHTHU
            HasRequired(e => e.BCDoanhThu)
                .WithMany(p => p.DS_CTBaoCaoDoanhThu)
                .HasForeignKey(e => new { e.Thang, e.Nam })
                .WillCascadeOnDelete();
            ToTable("CT_BCDOANHTHU");
            HasKey(o => new { o.Ngay, o.Thang, o.Nam });
            Property(p => p.SoBenhNhan).IsRequired();
            Property(p => p.DoanhThu).IsRequired();
            Property(p => p.TyLe).IsRequired();
        }
    }
}
