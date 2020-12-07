using DAL_Clinic.DAL;
using DTO_Clinic;
using DTO_Clinic.Form;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace BUS_Clinic.BUS
{
    public class BUS_PhieuNhapThuoc : BaseBUS
    {
        public BUS_PhieuNhapThuoc()
        {

        }
        public bool LoadNP_CTPhieuNhapThuoc(DTO_PhieuNhapThuoc phieuNhapThuoc)
        {
            return DALManager.PhieuNhapThuocDAL.LoadNP_CTPhieuNhapThuoc(phieuNhapThuoc);
        }
        public bool LoadNP_NhanVien(DTO_PhieuNhapThuoc phieuNhapThuoc)
        {
            return DALManager.PhieuNhapThuocDAL.LoadNP_NhanVien(phieuNhapThuoc);
        }
        public async Task<string> AddPhieuNhapThuocAsync(DTO_PhieuNhapThuoc phieuNhapThuoc)
        {
            return await DALManager.PhieuNhapThuocDAL.AddPhieuNhapThuocAsync(phieuNhapThuoc);
        }
        public void UpdatePNT(ObservableCollection<DTO_PhieuNhapThuoc> listPNT, DTO_PhieuNhapThuoc phieuNhapThuoc, ObservableCollection<DTO_CTPhieuNhapThuoc> listCTPNT)
        {
            List<double> kq = listCTPNT.Where(c => c.MaPNT == phieuNhapThuoc.MaPNT).Select(c => c.ThanhTien).ToList<double>();

            foreach (var item in kq)
            {
                phieuNhapThuoc.TongTien += item;
            }

            LoadNP_NhanVien(phieuNhapThuoc);

            listPNT.Add(phieuNhapThuoc);
        }
        //public void TransferTongTien(DTO_PhieuNhapThuoc phieuNhapThuoc)
        //{
        //    DALManager.PhieuNhapThuocDAL.TransferTongTien(phieuNhapThuoc);
        //}
        public async Task<ObservableCollection<DTO_PhieuNhapThuoc>> GetListPNTAsync()
        {
            return await DALManager.PhieuNhapThuocDAL.GetListPNTAsync();
        }
    }
}
