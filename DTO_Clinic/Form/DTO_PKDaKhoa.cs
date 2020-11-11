using DTO_Clinic.Component;
using DTO_Clinic.Person;
using System.Collections.Generic;

namespace DTO_Clinic.Form
{
    public class DTO_PKDaKhoa: PhieuKhamBenh
    {
        private string _trieuChung;
        public string TrieuChung { get => _trieuChung; set { _trieuChung = value; OnPropertyChanged(); } }
        public string MaBenhNhan { get; set; }
        public string MaBenh { get; set; }
        public string MaDonThuoc { get; set; }

        public virtual DTO_Benh Benh { get; set; }
        public virtual DTO_BenhNhan BenhNhan { get; set; }
        public virtual DTO_DonThuoc DonThuoc { get; set; }
        public virtual ICollection<DTO_PKChuyenKhoa> DS_PKChuyenKhoa { get; set; }


        public DTO_PKDaKhoa() : base() { }
    }
}
