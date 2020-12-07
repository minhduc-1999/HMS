using DTO_Clinic.Component;
using DTO_Clinic.Person;
using System;
using System.Collections.Generic;

namespace DTO_Clinic.Form
{
    public class DTO_PKDaKhoa: BaseModel
    {
        public string MaPKDK { get; set; }
        private bool _isDeleted;
        public bool IsDeleted { get => _isDeleted; set { _isDeleted = value; OnPropertyChanged(); } }
        private DateTime _ngayKham;
        public DateTime NgayKham { get => _ngayKham; set { _ngayKham = value; OnPropertyChanged(); } }
        private string _trieuChung;
        public string TrieuChung { get => _trieuChung; set { _trieuChung = value; OnPropertyChanged(); } }
        private string _chanDoan;
        public string ChanDoan { get => _chanDoan; set { _chanDoan = value; OnPropertyChanged(); } }
        public string MaBenhNhan { get; set; }
        public string MaBenh { get; set; }
        public string MaNhanVien { get; set; }
        public string MaBacSi { get; set; }
        public virtual DTO_Benh Benh { get; set; }
        public virtual DTO_NhanVien NguoiLap { get; set; }
        public virtual DTO_NhanVien BacSiChuaTri { get; set; }
        public virtual DTO_BenhNhan BenhNhan { get; set; }
        public virtual DTO_DonThuoc DonThuoc { get; set; }
        public virtual ICollection<DTO_PKChuyenKhoa> DS_PKhamChuyenKhoa { get; set; }
        public DTO_PKDaKhoa() : base() { _isDeleted = false; }
        public DTO_PKDaKhoa(string maBenhNhan, DateTime ngayKham, string maBenh, string trieuChung)
        {
            MaBenhNhan = maBenhNhan;
            MaBenh = maBenh;
            NgayKham = ngayKham;
            TrieuChung = trieuChung;
            IsDeleted = false;
        }
    }
}
