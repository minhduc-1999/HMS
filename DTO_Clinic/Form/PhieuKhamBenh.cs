using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_Clinic.Form
{
    public class PhieuKhamBenh : BaseModel
    {
        private DateTime _ngayKham;

        public DateTime NgayKham { get => _ngayKham; set { _ngayKham = value; OnPropertyChanged(); } }
        public PhieuKhamBenh()
        {
            IsDeleted = false;
        }
    }
}
