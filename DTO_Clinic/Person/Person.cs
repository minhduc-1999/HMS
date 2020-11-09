using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_Clinic.Person
{
    public class Person : BaseModel
    {
        public Person()
        {
            IsDeleted = false;
        }
        private string _hoTen;
        private DateTime _ngaySinh;
        private bool _gioiTinh;
        private string _diaChi;
        private string _SDT;
        private string _cmnd;
        private string _email;
        private bool _isDeleted;
        public string Id { get; set; }

        public string HoTen
        {
            get => _hoTen;
            set
            {
                _hoTen = value;
                OnPropertyChanged();
            }
        }
        public DateTime NgaySinh
        {
            get => _ngaySinh;
            set
            {
                _ngaySinh = value;
                OnPropertyChanged();
            }
        }
        public bool GioiTinh
        {
            get => _gioiTinh;
            set
            {
                _gioiTinh = value;
                OnPropertyChanged();
            }
        }
        public string DiaChi
        {
            get => _diaChi;
            set
            {
                _diaChi = value;
                OnPropertyChanged();
            }
        }
        public string SoDienThoai
        {
            get => _SDT;
            set
            {
                _SDT = value;
                OnPropertyChanged();
            }
        }
        public bool IsDeleted { get => _isDeleted; set { _isDeleted = value; OnPropertyChanged(); } }

        public string Cmnd
        {
            get => _cmnd;
            set
            {
                _cmnd = value;
                OnPropertyChanged();
            }
        }
        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }
    }
}
