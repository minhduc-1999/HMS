using DTO_Clinic.Component;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Threading.Tasks;

namespace DAL_Clinic.DAL
{
    public class DAL_Thuoc: BaseDAL
    {
        public DAL_Thuoc()
        {

        }
        public void LoadNPCTPhieuNhapThuoc(DTO_Thuoc thuoc)
        {
            using (var context = new SQLServerDBContext())
            {
                context.Entry(thuoc).Collection(s => s.DS_CTPhieuNhapThuoc).Load();
            }
        }
        public async Task<string> AddThuocAsync(DTO_Thuoc thuoc)
        {
            using (var context = new SQLServerDBContext())
            {
                context.Database.Log = s => Debug.WriteLine(s);
                string res = null;
                try
                {
                    res = await context.Database.SqlQuery<string>("exec proc_Thuoc_insert @1, @2, @3, @4, @5",
                        new SqlParameter[]
                        {
                            new SqlParameter("@1", thuoc.DonVi),
                            new SqlParameter("@2", thuoc.TenThuoc),
                            new SqlParameter("@3", thuoc.CongDung),
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
    }
}
