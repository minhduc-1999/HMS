using DTO_Clinic.Form;
using System.Data.Entity.ModelConfiguration;

namespace DAL_Clinic.BuddyClass
{
    public class PKChuyenKhoaMap : EntityTypeConfiguration<DTO_PKChuyenKhoa>
    {
        public PKChuyenKhoaMap()
        {
            ToTable("PKCHUYENKHOA");
            HasKey(p => p.Id);
            Property(p => p.Id).HasColumnName("MaPKCK");
            Property(p => p.KetQua).IsRequired();
            HasRequired(p => p.PKDaKhoa)
                .WithMany(m => m.DS_PKChuyenKhoa)
                .HasForeignKey(p => p.MaPKDaKhoa)
                .WillCascadeOnDelete();
        }
    }
}
