using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_Clinic.Component
{
    public class DTO_YeuCau
    {
        private string _maBenhNhan;
        private string _tenBenhNhan;
        private string _noiDung;
        public string MaBenhNhan { get => _maBenhNhan; set { _maBenhNhan = value; } }
        public string TenBenhNhan { get => _tenBenhNhan; set { _tenBenhNhan = value;  } }
        public string NoiDung { get => _noiDung; set { _noiDung = value;  } }
        public DTO_YeuCau() { }
        public DTO_YeuCau(string maBenhNhan, string tenBenhNhan, string noiDung)
        {
            MaBenhNhan = maBenhNhan;
            TenBenhNhan = tenBenhNhan;
            NoiDung = noiDung;
        }
    }
}
