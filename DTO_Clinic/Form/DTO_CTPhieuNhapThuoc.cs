using DTO_Clinic.Component;

namespace DTO_Clinic.Form
{
    public class DTO_CTPhieuNhapThuoc : BaseModel
    {
        private bool _isDeleted;
        public bool IsDeleted { get => _isDeleted; set { _isDeleted = value; OnPropertyChanged(); } }
        private int _soLuongNhap;
        private double _donGiaNhap;
        private double _thanhTien;
        public virtual DTO_Thuoc Thuoc { get; set; }
        public string MaThuoc { get; set; }
        public string MaPNT { get; set; }
        public int SoLuongNhap { get => _soLuongNhap; set { _soLuongNhap = value; OnPropertyChanged(); } }
        public double DonGiaNhap { get => _donGiaNhap; set { _donGiaNhap = value; OnPropertyChanged(); } }
        public double ThanhTien { get => _thanhTien; set { _thanhTien = value; OnPropertyChanged(); } }

        public DTO_CTPhieuNhapThuoc() : base()
        {
        }

        public DTO_CTPhieuNhapThuoc(string _maPNT, string _maThuoc, int _soLuongNhap, double _donGiaNhap) : base()
        {
            MaPNT = _maPNT;
            MaThuoc = _maThuoc;
            SoLuongNhap = _soLuongNhap;
            DonGiaNhap = _donGiaNhap;
            ThanhTien = SoLuongNhap * DonGiaNhap;
        }

        public virtual DTO_PhieuNhapThuoc PhieuNhapThuoc { get; set; }
    }
}
