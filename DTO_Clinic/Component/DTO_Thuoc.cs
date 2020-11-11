using System.Collections.Generic;
using DTO_Clinic.Form;
namespace DTO_Clinic.Component
{
    public class DTO_Thuoc : BaseModel
    {
        private string _tenThuoc;
        private string _congDung;
        private double _donGia;
        private int _soLuong;
        private string _maDonVi;
        public string MaDonVi { get => _maDonVi; set { _maDonVi = value; OnPropertyChanged(); } }
        public string TenThuoc { get => _tenThuoc; set { _tenThuoc = value; OnPropertyChanged(); } }
        public string CongDung { get => _congDung; set { _congDung = value; OnPropertyChanged(); } }
        public double DonGia { get => _donGia; set { _donGia = value; OnPropertyChanged(); } }
        public int SoLuong { get => _soLuong; set { _soLuong = value; OnPropertyChanged(); } }

        public DTO_Thuoc()
        {
            IsDeleted = false;
        }

        public override string ToString()
        {
            return TenThuoc;
        }
        public virtual DTO_DonVi DonVi { get; set; }
        public virtual ICollection<DTO_CTDonThuoc> DS_CTDonThuoc { get; set; }
        public virtual ICollection<DTO_BCSudungThuoc> DS_BCSuDungThuoc { get; set; }
        public virtual ICollection<DTO_CTPhieuNhapThuoc> DS_CTPhieuNhapThuoc { get; set; }

    }
}

