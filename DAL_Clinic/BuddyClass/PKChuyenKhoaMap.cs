using DTO_Clinic.Form;
using System.Data.Entity.ModelConfiguration;

namespace DAL_Clinic.BuddyClass
{
    public class PKChuyenKhoaMap : EntityTypeConfiguration<DTO_PKChuyenKhoa>
    {
        public PKChuyenKhoaMap()
        {
            ToTable("PKCHUYENKHOA");
            HasKey(p => p.MaPKCK);
            Property(p => p.KetQua).IsRequired();
            //ref to NHANVIEN table
            HasOptional(p => p.NguoiLap)
                .WithMany(n => n.DS_PKCKDaTao)
                .HasForeignKey(p => p.MaNhanVien)
                .WillCascadeOnDelete();
        }
    }
}
