using DAL_Clinic.DAL;
using DTO_Clinic.Person;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace BUS_Clinic.BUS
{
    public class BUS_NhanVien: BaseBUS
    {
        public BUS_NhanVien()
        {

        }

        public bool LoadNPAccount(DTO_NhanVien nhanVien)
        {
            return DALManager.NhanVienDAL.LoadNPAccount(nhanVien);
        }
        public bool LoadNPGroup(DTO_NhanVien nhanVien)
        {
            return DALManager.NhanVienDAL.LoadNPGroup(nhanVien);
        }
        public bool LoadNPPhong(DTO_NhanVien nhanVien)
        {
            return DALManager.NhanVienDAL.LoadNPPhong(nhanVien);
        }
        public async Task<ObservableCollection<DTO_NhanVien>> GetListNVAsync()
        {
            return await DALManager.NhanVienDAL.GetListNVAsync();
        }

        public bool IsNVDaTonTai(DTO_NhanVien nhanVien)
        {
            return DALManager.NhanVienDAL.IsNVDaTonTai(nhanVien);
        }

        public bool UpdateInfoNV(DTO_NhanVien nv, string ten, DateTime ngaySinh, bool gioiTinh, string email, string diaChi,  string sdt, string soCMND, string maNhom, string maPhong)
        {
            if (DALManager.NhanVienDAL.UpdateInfoNV(nv, ten, ngaySinh, gioiTinh, email, diaChi, sdt, soCMND, maNhom, maPhong))
            {
                nv.HoTen = ten;
                nv.NgaySinh = ngaySinh;
                nv.GioiTinh = gioiTinh;
                nv.Email = email;
                nv.DiaChi = diaChi;
                nv.SoDienThoai = sdt;
                nv.SoCMND = soCMND;
                nv.MaNhom = maNhom;
                nv.Nhom = null;
                nv.MaPhong = maPhong;
                nv.Phong = null;
                BUSManager.NhanVienBUS.LoadNPGroup(nv);
                BUSManager.NhanVienBUS.LoadNPPhong(nv);
                return true;
            }
            return false;
        }

        public async Task<string> AddNhanVienAsync(DTO_NhanVien nv)
        {
            try
            {
                var res = await DALManager.NhanVienDAL.AddNhanVienAsync(nv);
                if (res.Count == 2)
                {
                    var code = Convert.ToInt32(res[0]);
                    if (code == SUCCESS_CODE)
                        return res[1];
                    var errorNumber = Convert.ToInt32(res[1]);
                    if (code == 1 && errorNumber == 2601)
                        throw new Exception("Số CMND này đã tồn tại. Vui lòng kiểm tra lại.");
                }
                throw new Exception("Đã có lỗi xảy ra. Vui lòng thực hiện lại.");
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
