using DTO_Clinic.Person;
using System;
using System.Collections.Generic;

namespace DTO_Clinic.Form
{
    public class DTO_PhieuNhapThuoc : BaseModel
    {
        public string MaPNT { get; set; }
        private bool _isDeleted;
        public bool IsDeleted { get => _isDeleted; set { _isDeleted = value; OnPropertyChanged(); } }
        private DateTime _ngayNhap;
        private double _tongTien;
        public DateTime NgayNhap { get => _ngayNhap; set { _ngayNhap = value; OnPropertyChanged(); } }
        public double TongTien { get => _tongTien; set { _tongTien = value; OnPropertyChanged(); } }
        public virtual ICollection<DTO_CTPhieuNhapThuoc> DS_CTPhieuNhapThuoc { get; set; }
        public string MaDuocSi { get; set; }
        public virtual DTO_NhanVien NguoiLap { get; set; }
        public DTO_PhieuNhapThuoc() : base()
        {
        }

        public DTO_PhieuNhapThuoc(DateTime ngayNhap, double tongTien) : base()
        {
            NgayNhap = ngayNhap;
            TongTien = tongTien;
        }
    }
}
