using DTO_Clinic.Form;
using System;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Threading.Tasks;

namespace DAL_Clinic.DAL
{
    public class DAL_PhieuNhapThuoc: BaseDAL
    {
        public DAL_PhieuNhapThuoc()
        {

        }
        public bool LoadNP_CTPhieuNhapThuoc(DTO_PhieuNhapThuoc phieuNhapThuoc)
        {
            try
            {
                using (var context = new SQLServerDBContext())
                {
                    context.PhieuNhapThuoc.Attach(phieuNhapThuoc);
                    var entry = context.Entry(phieuNhapThuoc);
                    if (!entry.Collection(p => p.DS_CTPhieuNhapThuoc).IsLoaded)
                        entry.Collection(p => p.DS_CTPhieuNhapThuoc).Load();
                    return true;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine($"[ERRROR DAL THUOC] {e.Message}");
                return false;
            }
        }
        public async Task<string> AddPhieuNhapThuocAsync(DTO_PhieuNhapThuoc phieuNhapThuoc)
        {
            using (var context = new SQLServerDBContext())
            {
                string res = null;
                try
                {
                    res = await context.Database.SqlQuery<string>("exec proc_PNhapThuoc_insert @1, @2",
                        new SqlParameter[]
                        {
                            new SqlParameter("@1", phieuNhapThuoc.NgayNhap),
                            new SqlParameter("@2", phieuNhapThuoc.MaDuocSi)
                        }).FirstOrDefaultAsync();
                }
                catch (Exception e)
                {
                    Debug.WriteLine("[ERROR] " + e.Message);
                }
                return res;
            }
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
