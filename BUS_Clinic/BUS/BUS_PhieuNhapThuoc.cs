using DAL_Clinic.DAL;
using DTO_Clinic;
using DTO_Clinic.Form;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_Clinic.BUS
{
    public class BUS_PhieuNhapThuoc : BaseBUS
    {
        private const string _idPrefix = "PNT";
        public BUS_PhieuNhapThuoc()
        {

        }
        public void LoadNPCTPhieuNhapThuoc(DTO_PhieuNhapThuoc phieuNhapThuoc)
        {
            DALManager.PhieuNhapThuocDAL.LoadNPCTPhieuNhapThuoc(phieuNhapThuoc);
        }
        public void AddPhieuNhapThuoc(DTO_PhieuNhapThuoc phieuNhapThuoc)
        {
            phieuNhapThuoc.Id = AutoGenerateID();
            DALManager.PhieuNhapThuocDAL.AddPhieuNhapThuoc(phieuNhapThuoc);
        }
        //public void TransferTongTien(DTO_PhieuNhapThuoc phieuNhapThuoc)
        //{
        //    DALManager.PhieuNhapThuocDAL.TransferTongTien(phieuNhapThuoc);
        //}
        public void TinhTongTien(DTO_PhieuNhapThuoc phieuNhapThuoc)
        {
            ObservableCollection<DTO_CTPhieuNhapThuoc> CTPNTs = DALManager.CTPhieuNhapThuocDAL.GetListCTPNT();

            var cTPNT = from p in CTPNTs
                        where p.MaPNT == phieuNhapThuoc.Id
                        select p;

            foreach (var item in cTPNT)
            {
                phieuNhapThuoc.TongTien += item.ThanhTien;
            }
        }
        public override void LoadLocalData()
        {
            DALManager.PhieuNhapThuocDAL.LoadLocalData();
        }
        public ObservableCollection<DTO_PhieuNhapThuoc> GetListPNT()
        {
            return DALManager.PhieuNhapThuocDAL.GetListPNT();
        }
        public int GetPNTAmount()
        {
            int amount = DALManager.PhieuNhapThuocDAL.GetListPNT().Count;
            return amount;
        }
        public string AutoGenerateID()
        {
            return _idPrefix + (GetPNTAmount() + 1).ToString("D5");
        }
    }
}
