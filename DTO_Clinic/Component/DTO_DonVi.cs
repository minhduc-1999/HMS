using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_Clinic.Component
{
    public class DTO_DonVi : BaseModel
    {
        private string _tenDonVi;
        public string TenDonVi { get => _tenDonVi; set { _tenDonVi = value; OnPropertyChanged(); } }
        public DTO_DonVi() : base() { }

        public override string ToString()
        {
            return TenDonVi;
        }
        public virtual ICollection<DTO_Thuoc> DSThuoc { get; set; }
    }
}
