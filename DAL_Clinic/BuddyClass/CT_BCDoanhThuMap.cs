using DTO_Clinic.Form;
using System.Data.Entity.ModelConfiguration;

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
