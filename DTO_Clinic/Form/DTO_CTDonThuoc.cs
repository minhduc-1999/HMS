using DTO_Clinic.Component;
namespace DTO_Clinic.Form
{
    public class DTO_CTDonThuoc : BaseModel
    {
        private bool _isDeleted;
        public bool IsDeleted { get => _isDeleted; set { _isDeleted = value; OnPropertyChanged(); } }
        public string MaThuoc { get; set; }
        public string MaCachDung { get; set; }
        public virtual DTO_Thuoc Thuoc { get; set; }
        public virtual DTO_CachDung CachDung { get; set; }
        public virtual DTO_DonThuoc DonThuoc { get; set; }
        public string MaDonThuoc { get; set; }
        public int SoLuong { get => _soLuong; set { _soLuong = value; OnPropertyChanged(); } }

        private int _soLuong;

        public DTO_CTDonThuoc() : base()
        {
        }
    }
}
