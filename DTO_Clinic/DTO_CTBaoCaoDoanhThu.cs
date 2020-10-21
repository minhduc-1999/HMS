using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_Clinic
{
    public class DTO_CTBaoCaoDoanhThu: BaseModel
    {
        private int _ngay;
        private int _thang;
        private int _nam;
        private int _soBenhNhan;
        private float _doanhThu;
        private float _tyLe;
        private bool _isDeleted;
        public int Ngay { get => _ngay; set { _ngay = value; OnPropertyChanged(); } }
        public int Thang { get => _thang; set { _thang = value; OnPropertyChanged(); } }
        public int Nam { get => _nam; set { _nam = value; OnPropertyChanged(); } }
        public int SoBenhNhan { get =>_soBenhNhan; set { _soBenhNhan = value; OnPropertyChanged(); } }
        public float DoanhThu { get => _doanhThu; set { _doanhThu = value; OnPropertyChanged(); } }
        public float TyLe { get => _tyLe; set { _tyLe = value; OnPropertyChanged(); } }
        public virtual DTO_BCDoanhThu BCDoanhThu { get; set; }
        public bool IsDeleted { get => _isDeleted; set { _isDeleted = value; OnPropertyChanged(); } }

        public DTO_CTBaoCaoDoanhThu()
        {
            IsDeleted = false;
        }
        public DTO_CTBaoCaoDoanhThu(DTO_HoaDon hoaDon)
        {
            DateTime dateTime = DateTime.Now;
            SoBenhNhan = 1;
            DoanhThu = (float)hoaDon.ThanhTien;
            Ngay = dateTime.Day;
            Thang = dateTime.Month;
            Nam = dateTime.Year;
            IsDeleted = false;
        }
    }
}
