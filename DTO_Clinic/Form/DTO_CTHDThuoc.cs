﻿using DTO_Clinic.Component;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_Clinic.Form
{
    public class DTO_CTHDThuoc : BaseModel
    {
        private bool _isDeleted;
        public bool IsDeleted { get => _isDeleted; set { _isDeleted = value; OnPropertyChanged(); } }
        public string MaThuoc { get; set; }
        public virtual DTO_HoaDon HoaDon { get; set; }
        public virtual DTO_Thuoc Thuoc { get; set; }
        public string MaHoaDon { get; set; }
        public int SoLuong { get => _soLuong; set { _soLuong = value; OnPropertyChanged(); } }
        public double DonGia { get => _donGia; set { _donGia = value; OnPropertyChanged(); } }

        public double ThanhTien { get => _thanhTien; set { _thanhTien = value; OnPropertyChanged(); } }

        private int _soLuong;
        private double _donGia;
        private double _thanhTien;

        public DTO_CTHDThuoc() : base()
        {

        }
    }
}
