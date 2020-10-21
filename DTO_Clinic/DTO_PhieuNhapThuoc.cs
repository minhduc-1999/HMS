using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_Clinic
{
   public class DTO_PhieuNhapThuoc:BaseModel
    {
        public string Id { get; set; }
        private DateTime _ngayNhap;
        private double _tongTien;
        private bool _isDeleted;
        public DateTime NgayNhap { get => _ngayNhap; set { _ngayNhap = value; OnPropertyChanged(); } }
        public double TongTien { get => _tongTien; set { _tongTien = value; OnPropertyChanged(); } }  
        public virtual ICollection<DTO_CTPhieuNhapThuoc> DS_CTPhieuNhapThuoc { get; set; }
        public bool IsDeleted { get => _isDeleted; set { _isDeleted = value; OnPropertyChanged(); } }

        public DTO_PhieuNhapThuoc()
        {
            IsDeleted = false;
        }

        public DTO_PhieuNhapThuoc(DateTime ngayNhap, double tongTien)
        {
            NgayNhap = ngayNhap;
            TongTien = tongTien;
            IsDeleted = false;
        }
    }
}
