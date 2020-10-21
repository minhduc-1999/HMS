using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_Clinic
{
    public class DTO_ThamSo:BaseModel
    {
        private string _tenThamSo;
        private int _giaTri;

        public string TenThamSo { get => _tenThamSo; set { _tenThamSo = value; OnPropertyChanged(); } }
        public int GiaTri { get => _giaTri; set { _giaTri = value; OnPropertyChanged(); } }
        public DTO_ThamSo(string tenThamSo, int giatri)
        {
            TenThamSo = tenThamSo;
            GiaTri = giatri;
        }
        public DTO_ThamSo()
        {

        }
    }
}
