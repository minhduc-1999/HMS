using DAL_Clinic.DAL;
using DTO_Clinic.Component;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace BUS_Clinic.BUS
{
    public class BUS_Thuoc : BaseBUS
    {
        public BUS_Thuoc()
        {

        }
        public bool LoadNP_CTPhieuNhapThuoc(DTO_Thuoc thuoc)
        {
            return DALManager.ThuocDAL.LoadNP_CTPhieuNhapThuoc(thuoc);
        }
        public async Task<string> AddThuocAsync(DTO_Thuoc thuoc)
        {
            return await DALManager.ThuocDAL.AddThuocAsync(thuoc);
        }
        public ObservableCollection<DTO_Thuoc> GetListThuoc()
        {
            return DALManager.ThuocDAL.GetListThuoc();
        }

        public List<string> GetDonViByTenThuoc(string tenThuoc)
        {
            return DALManager.ThuocDAL.GetDonViByTenThuoc(tenThuoc);
        }

        public bool IsThuocDaTonTai(DTO_Thuoc thuocMoi)
        {
            return DALManager.ThuocDAL.IsThuocDaTonTai(thuocMoi);
        }

        public bool CheckIfThuocNhapTrung(ObservableCollection<DTO_Thuoc> listThuoc, DTO_Thuoc thuocNhap)
        {
            if (listThuoc == null)
                return false;
            return listThuoc.Any(t => (t.TenThuoc.Equals(thuocNhap.TenThuoc, StringComparison.OrdinalIgnoreCase)) && (t.DonVi.Equals(thuocNhap.DonVi, StringComparison.OrdinalIgnoreCase)));
        }

        public void UpdateListThuoc(ObservableCollection<DTO_Thuoc> thuocHienThi, ObservableCollection<DTO_Thuoc> thuocMoi)
        {
            foreach (var item in thuocMoi)
            {
                bool has = thuocHienThi.Any(t => (t.TenThuoc.Equals(item.TenThuoc, StringComparison.OrdinalIgnoreCase))) && thuocHienThi.Any(t => (t.DonVi.Equals(item.DonVi, StringComparison.OrdinalIgnoreCase)));

                if (has)
                {
                    var kq = thuocHienThi.Where(t => t.TenThuoc == item.TenThuoc).FirstOrDefault();
                    kq.SoLuong += item.SoLuong;
                    kq.DonGia = item.DonGia;
                }
                else
                {
                    thuocHienThi.Add(item);
                }
            }
        }

        //public void UpdateThuocVuaNhap(DTO_Thuoc thuocVuaNhap)
        //{
        //    DALManager.ThuocDAL.UpdateThuocVuaNhap(thuocVuaNhap);
        //}
        public void SuDungThuoc(string idThuocSuDung, int soLuongThuocSuDung, DTO_Thuoc thuoc)
        {
            DALManager.ThuocDAL.SuDungThuoc(idThuocSuDung, soLuongThuocSuDung);

            thuoc.SoLuong -= soLuongThuocSuDung;
        }
        public bool CheckIfSoLuongThuocDu(DTO_Thuoc thuocSuDung, int soLuongSuDung)
        {
            return DALManager.ThuocDAL.CheckIfSoLuongThuocDu(thuocSuDung, soLuongSuDung);
        }

        public bool UpdateInfoThuoc(DTO_Thuoc thuoc, string ten, string congDung, double donGia)
        {
            return DALManager.ThuocDAL.UpdateInfoThuoc(thuoc, ten, congDung, donGia);
        }

    }
}
