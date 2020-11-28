using DTO_Clinic.Person;
using System.Collections.Generic;

namespace DTO_Clinic.Permission
{
    public class DTO_Group : BaseModel
    {
        public string MaNhom { get; set; }
        public string TenNhom { get; set; }
        public virtual ICollection<DTO_NhanVien> DS_NhanVien { get; set; }
    }
}
