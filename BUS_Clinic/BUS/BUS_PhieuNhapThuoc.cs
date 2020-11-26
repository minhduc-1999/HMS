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
        public void LoadNPCTPhieuNhapThuoc(DTO_PhieuNhapThuoc phieuNhapThuoc)
        {
            DALManager.PhieuNhapThuocDAL.LoadNPCTPhieuNhapThuoc(phieuNhapThuoc);
        }
        public void AddPhieuNhapThuoc(DTO_PhieuNhapThuoc phieuNhapThuoc)
        {
            DALManager.PhieuNhapThuocDAL.AddPhieuNhapThuoc(phieuNhapThuoc);
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
