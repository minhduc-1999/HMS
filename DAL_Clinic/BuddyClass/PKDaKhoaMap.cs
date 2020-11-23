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
                .WillCascadeOnDelete();
            //reference to BENH table
            HasRequired(e => e.Benh)
                .WithMany(p => p.DS_PKDaKhoa)
                .HasForeignKey(e => e.MaBenh)
                .WillCascadeOnDelete();
            //reference to DONTHUOC table
            HasOptional(dt => dt.DonThuoc)
                .WithRequired(pk => pk.PKDaKhoa);
            //reference to NHANVIEN table
            HasOptional(p => p.NguoiLap)
                .WithMany(n => n.DS_PKDKDaTao)
                .HasForeignKey(p => p.MaNhanVien)
                .WillCascadeOnDelete();
        }
    }
}
