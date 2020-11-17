using DTO_Clinic.Form;
using System.Data.Entity.ModelConfiguration;

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
