using DTO_Clinic;
using DTO_Clinic.Form;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Diagnostics;
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
            using (var context = new SQLServerDBContext())
            {
                context.Entry(phieuNhapThuoc).Collection(s => s.DS_CTPhieuNhapThuoc).Load();
            }
        }
        public void AddPhieuNhapThuoc(DTO_PhieuNhapThuoc phieuNhapThuoc)
        {
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
  
        public async Task<ObservableCollection<DTO_PhieuNhapThuoc>> GetListPNTAsync()
        {
            ObservableCollection<DTO_PhieuNhapThuoc> res = null;
            using (var context = new SQLServerDBContext())
            {
                try
                {
                    var list = await context.PhieuNhapThuoc.SqlQuery("select * from PHIEUNHAPTHUOC").ToListAsync();
                    res = new ObservableCollection<DTO_PhieuNhapThuoc>(list);
                }
                catch (Exception e)
                {
                    Debug.WriteLine("[ERROR] " + e.Message);
                }
            }
            return res;
        }
    }
}
