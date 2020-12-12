using DTO_Clinic.Component;
using System;

namespace DTO_Clinic.Form
{
    public class DTO_BCSudungThuoc:BaseModel
    {
        private int _thang;
        private int _nam;
        private int _soLanDung;
        private int _soLuongDung;
        public int Thang { get => _thang; set { _thang = value; OnPropertyChanged(); } }
        public int Nam { get => _nam; set { _nam = value; OnPropertyChanged(); } }
        public int SoLanDung { get => _soLanDung; set { _soLanDung = value; OnPropertyChanged(); } }
        public int SoLuongDung { get => _soLuongDung; set { _soLuongDung = value; OnPropertyChanged(); } }
        public virtual DTO_Thuoc Thuoc { get; set; }
        public string MaThuoc { get; set; }

        public DTO_BCSudungThuoc() : base()
        {
        }

        public DTO_BCSudungThuoc(string maThuoc, int soLuongDung, DateTime ngayDung) : base()
        {
            MaThuoc = maThuoc;
            SoLuongDung = soLuongDung;
            Thang = ngayDung.Month;
            Nam = ngayDung.Year;
            SoLanDung = 0;
        }
    }
}
