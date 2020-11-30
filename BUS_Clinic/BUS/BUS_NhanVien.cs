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
        public BUS_NhanVien(DAL_NhanVien dAL_NhanVien) : base(dAL_NhanVien)
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

        public async Task AddNhanVienAsync(DTO_NhanVien nv, ObservableCollection<DTO_NhanVien> listNV)
        {
            //if (!IsValidInfo(bn, listBN))
            //    return;
            var res = await DALManager.NhanVienDAL.AddNhanVienAsync(nv);
            if (res != null)
            {
                nv.MaNhanVien = res;
                listNV.Add(nv);
            }
        }
    }
}
