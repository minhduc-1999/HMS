using System.Collections.Generic;

namespace DTO_Clinic.Permission
{
    public class DTO_Group : BaseModel
    {
        public int MaNhom { get; set; }
        public string TenNhom { get; set; }
        public virtual ICollection<DTO_Account> DS_Account { get; set; }
    }
}
