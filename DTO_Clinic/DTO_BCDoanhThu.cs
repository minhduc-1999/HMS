using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_Clinic
{
    public class DTO_BCDoanhThu: BaseModel
    {
        private int _thang;
        private int _nam;
        private float _tongDoanhThu;
        private bool _isDeleted;
        public int Thang { get => _thang; set { _thang = value; OnPropertyChanged(); } }
        public int Nam { get => _nam; set { _nam = value; OnPropertyChanged(); } }
        public float TongDoanhThu { get => _tongDoanhThu; set { _tongDoanhThu = value; OnPropertyChanged(); } }
        public virtual ICollection<DTO_CTBaoCaoDoanhThu> DS_CTBaoCaoDoanhThu { get; set; }
        public bool IsDeleted { get => _isDeleted; set { _isDeleted = value; OnPropertyChanged(); } }

        public DTO_BCDoanhThu()
        {
            IsDeleted = false;
        }
        public DTO_BCDoanhThu(DateTime dateTime)
        {
            TongDoanhThu = 0;
            Thang = dateTime.Month;
            Nam = dateTime.Year;
            IsDeleted = false;
        }
    }
}
