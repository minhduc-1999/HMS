using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_Clinic.Form
{
    public class PhieuKhamBenh : BaseModel
    {
        public string Id { get; set; }
        private DateTime _ngayKham;
        private bool _isDeleted;

        public DateTime NgayKham { get => _ngayKham; set { _ngayKham = value; OnPropertyChanged(); } }
        public bool IsDeleted { get => _isDeleted; set { _isDeleted = value; OnPropertyChanged(); } }
        public PhieuKhamBenh()
        {
            IsDeleted = false;
        }
    }
}
