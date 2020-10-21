using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_Clinic
{
    public class DTO_PhieuKhamBenh:BaseModel
    {
        public string Id { get; set; }
        private DateTime _ngayKham;
        private string _trieuChung;
        private bool _isDeleted;
        public string TrieuChung { get => _trieuChung; set { _trieuChung = value; OnPropertyChanged(); }  }
        public DateTime NgayKham { get => _ngayKham; set { _ngayKham = value; OnPropertyChanged(); }  }
        public string MaBenhNhan { get; set; }
        public string MaBenh { get; set; }
        public virtual DTO_HoaDon HoaDon { get; set; }
        public virtual DTO_Benh Benh { get; set; }
        public virtual DTO_BenhNhan BenhNhan { get; set; }
        public virtual ICollection<DTO_CTPhieuKhamBenh> DSCTPhieuKhamBenh { get; set; }
        public bool IsDeleted { get => _isDeleted; set { _isDeleted = value; OnPropertyChanged(); } }
        
        public DTO_PhieuKhamBenh()
        {
            IsDeleted = false;
        }

        public DTO_PhieuKhamBenh(string maBenhNhan, DateTime ngayKham, string maBenh, string trieuChung)
        {
            MaBenhNhan = maBenhNhan;
            MaBenh = maBenh;
            NgayKham = ngayKham;
            TrieuChung = trieuChung;
            IsDeleted = false;
        }
    }
}
