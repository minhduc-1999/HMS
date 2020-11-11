using DTO_Clinic.Component;

namespace DTO_Clinic.Person
{
    public class DTO_NhanVien : Person
    {
        public enum ChucNang { BSDK, BSCK, DUOCSI, THUTUC };
        public virtual DTO_Phong Phong { get; set; }
        public int ChucVu { get => _chucVu; set => _chucVu = value; }
        public string MaPhong { get; set; }
        private int _chucVu;
    }
}
