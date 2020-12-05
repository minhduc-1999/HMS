using DTO_Clinic.Component;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DAL_Clinic.DAL
{
    public class DAL_Thuoc: BaseDAL
    {
        public DAL_Thuoc()
        {

        }
        public bool LoadNP_CTPhieuNhapThuoc(DTO_Thuoc thuoc)
        {
            try
            {
                using (var context = new SQLServerDBContext())
                {
                    context.Thuoc.Attach(thuoc);
                    var entry = context.Entry(thuoc);
                    if (!entry.Collection(p => p.DS_CTPhieuNhapThuoc).IsLoaded)
                        entry.Collection(p => p.DS_CTPhieuNhapThuoc).Load();
                    return true;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine($"[ERRROR DAL BENH] {e.Message}");
                return false;
            }
        }
        public async Task<string> AddThuocAsync(DTO_Thuoc thuoc)
        {
            using (var context = new SQLServerDBContext())
            {
                string res = null;
                try
                {
                    var donVi = new SqlParameter("@1", System.Data.SqlDbType.NVarChar);
                    var tenThuoc = new SqlParameter("@2", System.Data.SqlDbType.NVarChar);
                    var congDung = new SqlParameter("@3", System.Data.SqlDbType.NVarChar);
                    donVi.Value = thuoc.DonVi;
                    tenThuoc.Value = thuoc.TenThuoc;
                    congDung.Value = thuoc.CongDung;
                    res = await context.Database.SqlQuery<string>("exec proc_Thuoc_insert @1, @2, @3, @4, @5",
                        new SqlParameter[]
                        {
                            donVi,
                            tenThuoc,
                            congDung,
                            new SqlParameter("@4", thuoc.DonGia),
                            new SqlParameter("@5", thuoc.SoLuong)
                        }).FirstOrDefaultAsync();
                }
                catch (Exception e)
                {
                    Debug.WriteLine("[ERROR] " + e.Message);
                }
                return res;
            }
        }
     
        public async Task<ObservableCollection<DTO_Thuoc>> GetListThuocAsync()
        {
            ObservableCollection<DTO_Thuoc> res = null;
            using (var context = new SQLServerDBContext())
            {
                try
                {
                    context.Database.Log = s => Debug.WriteLine(s);
                    var list = await context.Thuoc.SqlQuery("select * from THUOC").ToListAsync();
                    res = new ObservableCollection<DTO_Thuoc>(list);
                }
                catch (Exception e)
                {
                    Debug.WriteLine("[ERROR] " + e.Message);
                }
            }
            return res;
        }

        public List<string> GetDonViByTenThuoc(string tenThuoc)
        {
            using (var context = new SQLServerDBContext())
            {
                var donVi = context.Thuoc.Where(t => t.TenThuoc == tenThuoc).Select(t => t.DonVi).ToList<string>();
                return donVi;
            }
        }

        public bool CheckIfThuocDaTonTai(DTO_Thuoc thuocMoi)
        {
            using (var context = new SQLServerDBContext())
            {
                return context.Thuoc.Any(t => (t.TenThuoc.Equals(thuocMoi.TenThuoc, StringComparison.OrdinalIgnoreCase)) && (t.DonVi == thuocMoi.DonVi));
            }
        }

        public void UpdateThuocVuaNhap(DTO_Thuoc thuocVuaNhap)
        {
            using (var context = new SQLServerDBContext())
            {
                var res = context.Thuoc.Where(c => (c.MaThuoc == thuocVuaNhap.MaThuoc) && (c.DonVi == thuocVuaNhap.DonVi)).FirstOrDefault();

                if (res != null)
                {
                    res.SoLuong += thuocVuaNhap.SoLuong;
                    res.DonGia = thuocVuaNhap.DonGia;
                }
            }
        }
    }
}
