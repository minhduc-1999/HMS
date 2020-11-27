using DTO_Clinic.Person;

namespace DTO_Clinic.Permission
{
    public class DTO_Account
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string MaNhanVien { get; set; }
        public virtual DTO_NhanVien NhanVien { get; set; }
    }
}
