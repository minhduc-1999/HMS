using DTO_Clinic.Form;
using System;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Threading.Tasks;

namespace DAL_Clinic.DAL
{
    public class DAL_CTPhieuNhapThuoc : BaseDAL
    {
        public DAL_CTPhieuNhapThuoc()
        {

        }
        public bool LoadNP_Thuoc(DTO_CTPhieuNhapThuoc cTPhieuNhapThuoc)
        {
            try
            {
                using (var context = new SQLServerDBContext())
                {
                    context.CTPhieuNhapThuoc.Attach(cTPhieuNhapThuoc);
                    var entry = context.Entry(cTPhieuNhapThuoc);
                    if (!entry.Reference(p => p.Thuoc).IsLoaded)
                        entry.Reference(p => p.Thuoc).Load();
                    return true;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine($"[ERRROR DAL CT_PHIEUNHAPTHUOC] {e.Message}");
                return false;
            }
        }
        public bool LoadNP_PhieuNhapThuoc(DTO_CTPhieuNhapThuoc cTPhieuNhapThuoc)
        {
            try
            {
                using (var context = new SQLServerDBContext())
                {
                    context.CTPhieuNhapThuoc.Attach(cTPhieuNhapThuoc);
                    var entry = context.Entry(cTPhieuNhapThuoc);
                    if (!entry.Reference(p => p.PhieuNhapThuoc).IsLoaded)
                        entry.Reference(p => p.PhieuNhapThuoc).Load();
                    return true;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine($"[ERRROR DAL CTPHIEUNHAPTHUOC] {e.Message}");
                return false;
            }
        }
      
        public async Task<ObservableCollection<DTO_CTPhieuNhapThuoc>> GetListCTPNTAsync()
        {
            ObservableCollection<DTO_CTPhieuNhapThuoc> res = null;
            using (var context = new SQLServerDBContext())
            {
                try
                {
                    var list = await context.CTPhieuNhapThuoc.SqlQuery("select * from CT_PHIEUNHAPTHUOC").ToListAsync();
                    res = new ObservableCollection<DTO_CTPhieuNhapThuoc>(list);
                }
                catch (Exception e)
                {
                    Debug.WriteLine("[ERROR] " + e.Message);
                }
            }
            return res;
        }

        public void AddCTPhieuNhapThuoc(DTO_CTPhieuNhapThuoc ctPhieuNhapThuoc)
        {
            using (var context = new SQLServerDBContext())
            {
                context.CTPhieuNhapThuoc.Add(ctPhieuNhapThuoc);
                context.SaveChanges();
            }
        }

        public void GetData()
        {

        }
    }
}
