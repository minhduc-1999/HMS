using DTO_Clinic.Component;
namespace DTO_Clinic.Form
{
    public class DTO_CTDonThuoc : BaseModel
    {
        public string MaThuoc { get; set; }
        public string MaCachDung { get; set; }
        public virtual DTO_Thuoc Thuoc { get; set; }
        public virtual DTO_CachDung CachDung { get; set; }
        public string MaDonThuoc { get; set; }
        public double DonGia { get => _donGia; set { _donGia = value; OnPropertyChanged(); } }
        public int SoLuong { get => _soLuong; set { _soLuong = value; OnPropertyChanged(); } }
        public double ThanhTien { get => _thanhTien; set { _thanhTien = value; OnPropertyChanged(); } }

        private double _donGia;
        private int _soLuong;
        private double _thanhTien;

        public DTO_CTDonThuoc() : base()
        {
        }
    }
}
