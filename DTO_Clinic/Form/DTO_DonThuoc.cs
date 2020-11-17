using System.Collections.Generic;

namespace DTO_Clinic.Form
{
    public class DTO_DonThuoc : BaseModel
    {
        public string MaDonThuoc { get; set; }
        private bool _isDeleted;
        public bool IsDeleted { get => _isDeleted; set { _isDeleted = value; OnPropertyChanged(); } }
        public DTO_DonThuoc() : base()
        {

        }
        public string MaPKDK { get; set; }
        public DTO_PKDaKhoa PKDaKhoa { get; set; }
        public virtual ICollection<DTO_CTDonThuoc> DS_CTDonThuoc { get; set; }
    }
}
