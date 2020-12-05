using System;
using System.Collections.Generic;
namespace DTO_Clinic.Form
{
    public class DTO_BCDoanhThu: BaseModel
    {
        private int _thang;
        private int _nam;
        private double _tongDoanhThu;
        private int _tongBenhNhan;
        public int Thang { get => _thang; set { _thang = value; OnPropertyChanged(); } }
        public int Nam { get => _nam; set { _nam = value; OnPropertyChanged(); } }
        public double TongDoanhThu { get => _tongDoanhThu; set { _tongDoanhThu = value; OnPropertyChanged(); } }
        public virtual ICollection<DTO_CTBaoCaoDoanhThu> DS_CTBaoCaoDoanhThu { get; set; }
        public int TongBenhNhan { get => _tongBenhNhan; set { _tongBenhNhan = value; OnPropertyChanged(); } }

        public DTO_BCDoanhThu() : base()
        {
        }
        public DTO_BCDoanhThu(DateTime dateTime) : base()
        {
            TongDoanhThu = 0;
            Thang = dateTime.Month;
            Nam = dateTime.Year;
        }
    }
}
