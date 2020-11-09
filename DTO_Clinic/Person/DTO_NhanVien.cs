using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_Clinic.Person
{
    public class DTO_NhanVien : Person
    {
        public enum ChucNang { BSDK, BSCK, DUOCSI, THUTUC };
        public virtual DTO_Phong Phong { get; set; }
        public int ChucVu { get => _chucVu; set => _chucVu = value; }

        private int _chucVu;
    }
}
