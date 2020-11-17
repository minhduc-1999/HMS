using DTO_Clinic.Person;
using System;

namespace DTO_Clinic.Form
{
    public class DTO_PKChuyenKhoa : BaseModel
    {
        public string MaPKCK { get; set; }
        private bool _isDeleted;
        public bool IsDeleted { get => _isDeleted; set { _isDeleted = value; OnPropertyChanged(); } }
        private string _yeuCau;
        private string _ketQua;
        private DateTime _ngayKham;
        public DateTime NgayKham { get => _ngayKham; set { _ngayKham = value; OnPropertyChanged(); } }
        public string YeuCau { get => _yeuCau; set { _yeuCau = value; OnPropertyChanged(); } }
        public string KetQua { get => _ketQua; set { _ketQua = value; OnPropertyChanged(); } }
        public string MaNhanVien { get; set; }

        public virtual DTO_NhanVien NguoiLap { get; set; }

        public DTO_PKChuyenKhoa() : base() { }
    }
}
