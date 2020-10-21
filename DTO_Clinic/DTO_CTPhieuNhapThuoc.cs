using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_Clinic
{
    public class DTO_CTPhieuNhapThuoc:BaseModel
    {
        private int _soLuongNhap;
        private double _donGiaNhap;
        private double _thanhTien;
        private bool _isDeleted;
        public virtual DTO_PhieuNhapThuoc PhieuNhapThuoc  { get; set; }
        public virtual DTO_Thuoc Thuoc { get; set; }
        public string MaThuoc { get; set; }
        public string MaPNT { get; set; }
        public int SoLuongNhap { get => _soLuongNhap; set { _soLuongNhap = value; OnPropertyChanged(); } }
        public double DonGiaNhap { get => _donGiaNhap; set { _donGiaNhap = value; OnPropertyChanged(); } }
        public double ThanhTien { get => _thanhTien; set { _thanhTien = value; OnPropertyChanged(); } }
        public bool IsDeleted { get => _isDeleted; set { _isDeleted = value; OnPropertyChanged(); } }

        public DTO_CTPhieuNhapThuoc()
        {
            IsDeleted = false;
        }

        public DTO_CTPhieuNhapThuoc(string _maPNT, string _maThuoc, int _soLuongNhap, double _donGiaNhap)
        {
            MaPNT = _maPNT;
            MaThuoc = _maThuoc;
            SoLuongNhap = _soLuongNhap;
            DonGiaNhap = _donGiaNhap;
            ThanhTien = SoLuongNhap * DonGiaNhap;
            IsDeleted = false;
        }
    }
}
