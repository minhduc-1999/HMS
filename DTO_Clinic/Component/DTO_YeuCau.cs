using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_Clinic.Component
{
    public class DTO_YeuCau
    {
        string MaBenhNhan;
        string TenBenhNhan;
        string NoiDung { get; set; }
        public DTO_YeuCau() { }
        public DTO_YeuCau(string ma, string ten, string nd)
        {
            MaBenhNhan = ma;
            TenBenhNhan = ten;
            NoiDung = nd;
        }
          
    }
}
