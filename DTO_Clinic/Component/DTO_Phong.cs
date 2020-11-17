using DTO_Clinic.Person;
using System.Collections.Generic;

namespace DTO_Clinic.Component
{
    public class DTO_Phong : BaseModel
    {
        public string MaPhong { get; set; }
        private bool _isDeleted;
        public bool IsDeleted { get => _isDeleted; set { _isDeleted = value; OnPropertyChanged(); } }
        public string TenPhong 
        {
            get => _tenPhong;
            set
            {
                _tenPhong = value;
                OnPropertyChanged();
            }
        }

        private string _tenPhong;
        public virtual ICollection<DTO_NhanVien> DS_NhanVien { get; set; }

    }
}
