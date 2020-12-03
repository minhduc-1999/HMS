using DTO_Clinic.Form;
using System.Data.Entity.ModelConfiguration;

namespace DAL_Clinic.BuddyClass
{
    public class PKDaKhoaMap : EntityTypeConfiguration<DTO_PKDaKhoa>
    {
        public PKDaKhoaMap()
        {
            ToTable("PKDAKHOA");
            HasKey(p => p.MaPKDK);
            Property(p => p.NgayKham).IsRequired();
            Property(p => p.TrieuChung).IsOptional();
            //reference to BENHNHAN table
            HasRequired(p => p.BenhNhan)
                .WithMany(m => m.DS_PKDaKhoa)
                .HasForeignKey(p => p.MaBenhNhan)
                .WillCascadeOnDelete(false);
            //reference to BENH table
            HasOptional(e => e.Benh)
                .WithMany(p => p.DS_PKDaKhoa)
                .HasForeignKey(e => e.MaBenh)
                .WillCascadeOnDelete(false);
            //reference to DONTHUOC table
            HasOptional(dt => dt.DonThuoc)
                .WithRequired(pk => pk.PKDaKhoa);
            //reference to NHANVIEN table
            HasRequired(p => p.NguoiLap)
                .WithMany(n => n.DS_PKDKDaTao)
                .HasForeignKey(p => p.MaNhanVien)
                .WillCascadeOnDelete(false) ;
            HasOptional(p => p.BacSiChuaTri)
                .WithMany(bs => bs.DS_PKDKhoaDaKham)
                .HasForeignKey(p => p.MaBacSi)
                .WillCascadeOnDelete(false);
        }
    }
}
