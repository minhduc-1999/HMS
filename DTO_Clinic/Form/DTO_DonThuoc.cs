using System.Collections.Generic;

namespace DTO_Clinic.Form
{
    public class DTO_DonThuoc : BaseModel
    {
        public DTO_DonThuoc() : base()
        {

        }
        public string ID_PKDaKhoa { get; set; }
        public DTO_PKDaKhoa PKDaKhoa { get; set; }
        public virtual ICollection<DTO_CTDonThuoc> DS_CTDonThuoc { get; set; }
    }
}
