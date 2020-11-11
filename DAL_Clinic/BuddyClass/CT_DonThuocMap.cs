using DTO_Clinic.Form;
using System.Data.Entity.ModelConfiguration;

namespace DAL_Clinic.BuddyClass
{
    public class CT_DonThuocMap : EntityTypeConfiguration<DTO_CTDonThuoc>
    {
        public CT_DonThuocMap()
        {
            ToTable("CT_DONTHUOC");
            HasKey(p => p.Id);
            Property(p => p.Id).HasColumnName("MaCTDT");
            //reference to THUOC table
            HasRequired(p => p.Thuoc)
                .WithMany(m => m.DS_CTDonThuoc)
                .HasForeignKey(p => p.MaThuoc)
                .WillCascadeOnDelete();
            //reference to CACHDUNG table
            HasRequired(p => p.CachDung)
                .WithMany(m => m.DS_CTDonThuoc)
                .HasForeignKey(p => p.MaCachDung)
                .WillCascadeOnDelete();
            //reference to DONTHUOC table
            HasRequired(p => p.DonThuoc)
                .WithMany(m => m.DS_CTDonThuoc)
                .HasForeignKey(p => p.MaDonThuoc)
                .WillCascadeOnDelete();

        }
    }
}
