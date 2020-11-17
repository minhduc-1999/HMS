using DTO_Clinic.Form;
using System.Collections.Generic;

namespace DTO_Clinic.Component
{
    public class DTO_CachDung: BaseModel
    {
        public string MaCachDung { get; set; }
        private bool _isDeleted;
        public bool IsDeleted { get => _isDeleted; set { _isDeleted = value; OnPropertyChanged(); } }
        public string TenCachDung { get => _tenCachDung; set { _tenCachDung = value; OnPropertyChanged(); } }

        private string _tenCachDung;
        public virtual ICollection<DTO_CTDonThuoc> DS_CTDonThuoc { get; set; }

        public DTO_CachDung() : base()
        {
        }

        public override string ToString()
        {
            return TenCachDung;
        }
    }
}
