using System.Collections.Generic;

namespace DTO_Clinic.Component
{
    public class DTO_CachDung: BaseModel
    {
        public string TenCachDung { get => _tenCachDung; set { _tenCachDung = value; OnPropertyChanged(); } }

        private string _tenCachDung;

        public DTO_CachDung() : base()
        {
        }

        public override string ToString()
        {
            return TenCachDung;
        }
    }
}
