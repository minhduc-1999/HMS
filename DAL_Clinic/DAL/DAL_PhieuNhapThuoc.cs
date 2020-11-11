using DTO_Clinic;
using DTO_Clinic.Form;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Clinic.DAL
{
    public class DAL_PhieuNhapThuoc: BaseDAL
    {
        public DAL_PhieuNhapThuoc()
        {

        }
        public void LoadNPCTPhieuNhapThuoc(DTO_PhieuNhapThuoc phieuNhapThuoc)
        {
            var entry = SQLServerDBContext.Instant.Entry(phieuNhapThuoc);
            entry.Collection(c => c.DS_CTPhieuNhapThuoc).Load();
        }
        public void AddPhieuNhapThuoc(DTO_PhieuNhapThuoc phieuNhapThuoc)
        {
            SQLServerDBContext.Instant.PhieuNhapThuoc.Local.Add(phieuNhapThuoc);
        }
        //public void TransferTongTien(DTO_PhieuNhapThuoc phieuNhapThuoc)
        //{
        //    phieuNhapThuoc.TongTien.ToString();
        //}
        //public void CapNhatTongTien(DTO_PhieuNhapThuoc phieuNhapThuoc)
        //{
        //    ObservableCollection<DTO_CTPhieuNhapThuoc> CTPNTs = DALManager.CTPhieuNhapThuocDAL.GetListCTPNT();

        //    var cTPNT = from p in CTPNTs
        //                where p.MaPNT == phieuNhapThuoc.Id
        //                select p;

        //    foreach (var item in cTPNT)
        //    {
        //        phieuNhapThuoc.TongTien += item.ThanhTien;
        //    }
        //}
        public override void LoadLocalData()
        {
            SQLServerDBContext.Instant.PhieuNhapThuoc.Load();
        }
        public ObservableCollection<DTO_PhieuNhapThuoc> GetListPNT()
        {
            return SQLServerDBContext.Instant.PhieuNhapThuoc.Local;
        }
    }
}
