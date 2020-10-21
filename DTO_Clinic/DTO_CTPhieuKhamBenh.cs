using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_Clinic
{
    public class DTO_CTPhieuKhamBenh: BaseModel
    {
        public string MaThuoc { get; set; }
        public string MaCachDung { get; set; }
        public virtual DTO_Thuoc Thuoc { get; set; }
        public virtual DTO_CachDung CachDung { get; set; }
        public virtual DTO_PhieuKhamBenh PhieuKhamBenh { get; set; }
        public string MaPKB { get; set; }
        public double DonGia { get => _donGia; set { _donGia = value; OnPropertyChanged(); } }
        public int SoLuong { get => _soLuong; set { _soLuong = value; OnPropertyChanged(); } }
        public double ThanhTien { get => _thanhTien; set { _thanhTien = value; OnPropertyChanged(); } }
        public bool IsDeleted { get => _isDeleted; set { _isDeleted = value; OnPropertyChanged(); } }

        private double _donGia;
        private int _soLuong;
        private double _thanhTien;
        private bool _isDeleted;

        public DTO_CTPhieuKhamBenh()
        {
            IsDeleted = false;
        }

        public DTO_CTPhieuKhamBenh(string maPKB, string maThuoc, string maCachDung, int soLuong, double donGia)
        {
            MaPKB = maPKB;
            MaThuoc = maThuoc;
            MaCachDung = maCachDung;
            SoLuong = soLuong;
            DonGia = donGia;
            ThanhTien = SoLuong * DonGia;
            IsDeleted = false;
        }



    }
}
