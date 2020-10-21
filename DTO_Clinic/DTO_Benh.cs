using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_Clinic
{
    public class DTO_Benh : BaseModel
    {
        private bool _isDeleted;
        public string Id { get; set; }
        public string TenBenh { get => _tenBenh; set { _tenBenh = value; OnPropertyChanged(); }  }

        private string _tenBenh;
        public virtual ICollection<DTO_PhieuKhamBenh> DS_PhieuKhamBenh { get; set; }
        public bool IsDeleted { get => _isDeleted; set { _isDeleted = value; OnPropertyChanged(); } }

        public DTO_Benh()
        {
            IsDeleted = false;
        }

        public DTO_Benh(string tenBenh)
        {
            TenBenh = tenBenh;
            IsDeleted = false;
        }

        public DTO_Benh(string maBenh, string tenBenh)
        {
            Id = maBenh;
            TenBenh = tenBenh;
            IsDeleted = false;
        }

        public override string ToString()
        {
            return TenBenh;
        }
    }
}
