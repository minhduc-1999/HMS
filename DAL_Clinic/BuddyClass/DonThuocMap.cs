using DTO_Clinic.Form;
using System.Data.Entity.ModelConfiguration;

namespace DAL_Clinic.BuddyClass
{
    public class DonThuocMap : EntityTypeConfiguration<DTO_DonThuoc>
    {
        public DonThuocMap()
        {
            ToTable("DONTHUOC");
            HasKey(p => p.MaDonThuoc);
            
        }
    }
}
