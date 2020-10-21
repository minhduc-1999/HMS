using DAL_Clinic.DAL;
using DTO_Clinic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_Clinic.BUS
{
    public class BUS_Thuoc: BaseBUS
    {
        private const string _idPrefix = "TH";
        public BUS_Thuoc()
        {

        }
        public void LoadNPCTPhieuNhapThuoc(DTO_Thuoc thuoc)
        {
            DALManager.ThuocDAL.LoadNPCTPhieuNhapThuoc(thuoc);
        }
        public void LoadNPDonVi(DTO_Thuoc thuoc)
        {
            DALManager.ThuocDAL.LoadNPDonVi(thuoc);
        }
        public void AddThuoc(DTO_Thuoc thuoc)
        {
            thuoc.Id = AutoGenerateID();
            DALManager.ThuocDAL.AddThuoc(thuoc);
        }
        public bool CheckIfThuocDaTonTai(DTO_Thuoc thuocMoi)
        {
            ObservableCollection<DTO_Thuoc> thuocs = DALManager.ThuocDAL.GetListThuoc();

            bool has = thuocs.Any(t => (t.TenThuoc.Equals(thuocMoi.TenThuoc, StringComparison.OrdinalIgnoreCase)) && (t.MaDonVi == thuocMoi.MaDonVi));

            return has;
        }
        public void CapNhatThuocVuaNhap(DTO_Thuoc thuocVuaNhap)
        {
            ObservableCollection<DTO_Thuoc> thuocs = DALManager.ThuocDAL.GetListThuoc();

            var kq = thuocs.Where(c => (c.Id == thuocVuaNhap.Id) && (c.MaDonVi == thuocVuaNhap.MaDonVi)).FirstOrDefault();

            if (kq != null)
            {
                kq.SoLuong += thuocVuaNhap.SoLuong;
                kq.DonGia = thuocVuaNhap.DonGia;
            }
        }
        public void SuDungThuoc(string idThuocSuDung, int soLuongThuocSuDung)
        {
            ObservableCollection<DTO_Thuoc> thuocs = DALManager.ThuocDAL.GetListThuoc();

            var kq = thuocs.Where(c => c.Id == idThuocSuDung).FirstOrDefault();

            if (kq != null)
            {
                kq.SoLuong -= soLuongThuocSuDung;
            }
        }
        public bool CheckIfSoLuongThuocDu(DTO_Thuoc thuocSuDung, int soLuongSuDung)
        {
            ObservableCollection<DTO_Thuoc> thuocs = DALManager.ThuocDAL.GetListThuoc();

            var kq = thuocs.Where(c => c.Id == thuocSuDung.Id).FirstOrDefault();

            if (kq != null)
            {
                if (kq.SoLuong >= soLuongSuDung)
                    return true;
                return false;
            }

            return false;
        }
        public override void LoadLocalData()
        {
            DALManager.ThuocDAL.LoadLocalData();
        }
        public ObservableCollection<DTO_Thuoc> GetListThuoc()
        {
            return DALManager.ThuocDAL.GetListThuoc();
        }
        public int GetThuocAmount()
        {
            int amount = DALManager.ThuocDAL.GetListThuoc().Count;
            return amount;
        }
        public string AutoGenerateID()
        {
            return _idPrefix + (GetThuocAmount() + 1).ToString("D5");
        }
        public bool UpdateInfoThuoc(DTO_Thuoc thuoc, string ten, string congDung, double donGia)
        {
            var list = DALManager.ThuocDAL.GetListThuoc();
            var item = list.Where(x => x.TenThuoc == ten).FirstOrDefault();
            bool check;
            if (item != null)
                check = item.Id == thuoc.Id;
            else
                check = true;
            if (check)
            {
                thuoc.TenThuoc = ten;
                thuoc.CongDung = congDung;
                thuoc.DonGia = donGia;
                return true;
            }
            else
                return false;
        }
        
    }
}
