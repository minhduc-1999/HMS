using DAL_Clinic.DAL;
using DTO_Clinic.Component;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

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
            return DALManager.ThuocDAL.CheckIfThuocDaTonTai(thuocMoi);
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
        //public bool UpdateInfoThuoc(DTO_Thuoc thuoc, string ten, string congDung, double donGia)
        //{
        //    var list = DALManager.ThuocDAL.GetListThuoc();
        //    var item = list.Where(x => x.TenThuoc == ten).FirstOrDefault();
        //    bool check;
        //    if (item != null)
        //        check = item.MaThuoc == thuoc.MaThuoc;
        //    else
        //        check = true;
        //    if (check)
        //    {
        //        thuoc.TenThuoc = ten;
        //        thuoc.CongDung = congDung;
        //        thuoc.DonGia = donGia;
        //        return true;
        //    }
        //    else
        //        return false;
        //}

    }
}
