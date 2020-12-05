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
        public async Task AddPhieuNhapThuocAsync(DTO_PhieuNhapThuoc phieuNhapThuoc)
        {
            await DALManager.PhieuNhapThuocDAL.AddPhieuNhapThuocAsync(phieuNhapThuoc);
            
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
