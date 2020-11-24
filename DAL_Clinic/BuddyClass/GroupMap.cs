using DTO_Clinic.Permission;
using System.Data.Entity.ModelConfiguration;

namespace DAL_Clinic.BuddyClass
{
    public class GroupMap : EntityTypeConfiguration<DTO_Group>
    {
        public GroupMap()
        {
            ToTable("GROUP");
            HasKey(gr => gr.MaNhom);
            Property(gr => gr.TenNhom).HasMaxLength(20).IsRequired();
        }
    }
}
