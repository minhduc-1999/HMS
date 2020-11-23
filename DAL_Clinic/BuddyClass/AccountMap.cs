using DTO_Clinic.Permission;
using System.Data.Entity.ModelConfiguration;

namespace DAL_Clinic.BuddyClass
{
    public class AccountMap: EntityTypeConfiguration<DTO_Account>
    {
        public AccountMap()
        {
            ToTable("ACCOUNT");
            HasKey(ac => ac.MaNhanVien);
            HasIndex(ac => ac.Username).IsUnique();
            Property(ac => ac.Username).HasMaxLength(10).IsRequired();
            Property(ac => ac.Password).IsRequired().HasMaxLength(20);
            //ref to GROUP
            HasRequired(ac => ac.Nhom)
                .WithMany(gr => gr.DS_Account)
                .HasForeignKey(ac => ac.MaNhom);
            //ref to NHANVIEN
            HasRequired(ac => ac.NhanVien)
                .WithRequiredDependent(nv => nv.Account);
        }
    }
}
