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
            HasRequired(p => p.NguoiLap)
                .WithMany(n => n.DS_PKCKDaTao)
                .HasForeignKey(p => p.MaNhanVien)
                .WillCascadeOnDelete(false);
            HasRequired(p => p.BacSiThucHien)
                .WithMany(bs => bs.DS_PKCKhoaDaKham)
                .HasForeignKey(p => p.MaBacSi).WillCascadeOnDelete(false);
            //ref to BENHNHAN table
            HasRequired(p => p.PhieuKhamDaKhoa)
                .WithMany(bn => bn.DS_PKhamChuyenKhoa)
                .HasForeignKey(p => p.MaPKDaKhoa).WillCascadeOnDelete(false);
        }
    }
}
