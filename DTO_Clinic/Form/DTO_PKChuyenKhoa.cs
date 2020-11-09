using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_Clinic.Form
{
    public class DTO_PKChuyenKhoa : PhieuKhamBenh
    {
        private string _yeuCau;
        private string _ketQua;
        public string YeuCau { get => _yeuCau; set { _yeuCau = value; OnPropertyChanged(); } }
        public string KetQua { get => _ketQua; set { _ketQua = value; OnPropertyChanged(); } }
        public string MaPKDaKhoa { get; set; }
        public virtual DTO_PKDaKhoa PKDaKhoa { get; set; }

        public DTO_PKChuyenKhoa() : base() { }
    }
}
