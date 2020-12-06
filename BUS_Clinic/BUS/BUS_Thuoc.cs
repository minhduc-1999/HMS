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
        public async Task<ObservableCollection<DTO_Thuoc>> GetListThuocAsync()
        {
            return await DALManager.ThuocDAL.GetListThuocAsync();
        }

        public List<string> GetDonViByTenThuoc(string tenThuoc)
        {
            return DALManager.ThuocDAL.GetDonViByTenThuoc(tenThuoc);
        }

        public bool IsThuocDaTonTai(DTO_Thuoc thuocMoi)
        {
            return DALManager.ThuocDAL.IsThuocDaTonTai(thuocMoi);
        }

        public void UpdateListThuoc(ObservableCollection<DTO_Thuoc> thuocHienThi, ObservableCollection<DTO_Thuoc> thuocMoi)
        {
            foreach (var item in thuocMoi)
            {
                bool has = IsThuocDaTonTai(item);

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
        //public void SuDungThuoc(string idThuocSuDung, int soLuongThuocSuDung)
        //{
        //    ObservableCollection<DTO_Thuoc> thuocs = DALManager.ThuocDAL.GetListThuoc();

        //    var kq = thuocs.Where(c => c.MaThuoc == idThuocSuDung).FirstOrDefault();

        //    if (kq != null)
        //    {
        //        kq.SoLuong -= soLuongThuocSuDung;
        //    }
        //}
        //public bool CheckIfSoLuongThuocDu(DTO_Thuoc thuocSuDung, int soLuongSuDung)
        //{
        //    ObservableCollection<DTO_Thuoc> thuocs = DALManager.ThuocDAL.GetListThuoc();

        //    var kq = thuocs.Where(c => c.MaThuoc == thuocSuDung.MaThuoc).FirstOrDefault();

        //    if (kq != null)
        //    {
        //        if (kq.SoLuong >= soLuongSuDung)
        //            return true;
        //        return false;
        //    }

        //    return false;
        //}
        public bool UpdateInfoThuoc(DTO_Thuoc thuoc, string ten, string congDung, double donGia)
        {
            return DALManager.ThuocDAL.UpdateInfoThuoc(thuoc, ten, congDung, donGia);
        }

    }
}
