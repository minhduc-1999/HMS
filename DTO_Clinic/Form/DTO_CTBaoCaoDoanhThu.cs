using System;

namespace DTO_Clinic.Form
{
    public class DTO_CTBaoCaoDoanhThu: BaseModel
    {
        private int _ngay;
        private int _thang;
        private int _nam;
        private int _soBenhNhan;
        private float _doanhThu;
        private float _tyLe;
        public int Ngay { get => _ngay; set { _ngay = value; OnPropertyChanged(); } }
        public int Thang { get => _thang; set { _thang = value; OnPropertyChanged(); } }
        public int Nam { get => _nam; set { _nam = value; OnPropertyChanged(); } }
        public int SoBenhNhan { get =>_soBenhNhan; set { _soBenhNhan = value; OnPropertyChanged(); } }
        public float DoanhThu { get => _doanhThu; set { _doanhThu = value; OnPropertyChanged(); } }
        public float TyLe { get => _tyLe; set { _tyLe = value; OnPropertyChanged(); } }
        public virtual DTO_BCDoanhThu BCDoanhThu { get; set; }
        public DTO_CTBaoCaoDoanhThu() : base()
        {
        }
        public DTO_CTBaoCaoDoanhThu(DTO_HoaDon hoaDon) : base()
        {
            DateTime dateTime = DateTime.Now;
            SoBenhNhan = 1;
            DoanhThu = (float)hoaDon.ThanhTien;
            Ngay = dateTime.Day;
            Thang = dateTime.Month;
            Nam = dateTime.Year;
        }
    }
}
