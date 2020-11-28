using DTO_Clinic.Form;
using System;
using System.Collections.Generic;

namespace DTO_Clinic.Person
{
    public class DTO_BenhNhan : BaseModel
    {
        public DTO_BenhNhan()
        {
            MaBenhNhan = "";
            IsDeleted = false;
        }
        private string _hoTen;
        private DateTime _ngaySinh;
        private bool _gioiTinh;
        private string _diaChi;
        private string _SDT;
        private string _cmnd;
        private string _email;

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
        public string SoCMND
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
        public string MaBenhNhan { get; set; }
        private bool _isDeleted;
        public bool IsDeleted { get => _isDeleted; set { _isDeleted = value; OnPropertyChanged(); } }
        public virtual ICollection<DTO_PKDaKhoa> DS_PKDaKhoa { get; set; }
        public virtual ICollection<DTO_PKChuyenKhoa> DS_PKCKhoa { get; set; }
        public virtual ICollection<DTO_HoaDon> DS_HoaDon { get; set; }

        public override string ToString()
        {
            return MaBenhNhan + " - " + HoTen;
        }
    }
}
