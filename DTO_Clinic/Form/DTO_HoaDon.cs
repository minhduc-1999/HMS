using DTO_Clinic.Person;
using System;

namespace DTO_Clinic.Form
{
    public class DTO_HoaDon : BaseModel
    {
        public string MaHoaDon { get; set; }
        private bool _isDeleted;
        public bool IsDeleted { get => _isDeleted; set { _isDeleted = value; OnPropertyChanged(); } }
        public string ChiTiet { get => _chiTiet; set { _chiTiet = value; OnPropertyChanged(); } }
        public double ThanhTien { get => _thanhTien; set { _thanhTien = value; OnPropertyChanged(); } }
        public DateTime NgayLap { get => _ngayLap; set { _ngayLap = value; OnPropertyChanged(); } }

        private string _chiTiet;
        private double _thanhTien;
        private DateTime _ngayLap;

        public DTO_HoaDon(): base()
        {
        }
        public string MaBenhNhan { get; set; }
        public string MaNhanVien { get; set; }
        public virtual DTO_NhanVien NguoiLap { get; set; }
        public virtual DTO_BenhNhan BenhNhan { get; set; }


    }
}
