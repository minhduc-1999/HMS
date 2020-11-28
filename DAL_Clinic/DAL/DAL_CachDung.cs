using DTO_Clinic.Component;
using System;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DAL_Clinic.DAL
{
    public class DAL_CachDung: BaseDAL
    {
        public DAL_CachDung()
        {

        }
        public async Task<string> AddCachDungAsync(DTO_CachDung cd)
        {
            using (var context = new SQLServerDBContext())
            {
                string res = null;
                try
                {
                    var tenCD = new SqlParameter("@1", System.Data.SqlDbType.NVarChar);
                    tenCD.Value = cd.TenCachDung;
                    res = await context.Database.SqlQuery<string>("exec proc_CachDung_insert @1",
                        new SqlParameter[]
                        {
                            tenCD
                        }).FirstOrDefaultAsync();
                }
                catch (Exception e)
                {
                    Debug.WriteLine("[ERROR] " + e.Message);
                }
                return res;
            }
        }
        //public void DelCachDung(DTO_CachDung cd)
        //{
        //    SQLServerDBContext.Instant.CachDung.Local.Remove(cd);
        //}
    
        public async Task<ObservableCollection<DTO_CachDung>> GetListCDAsync()
        {
            ObservableCollection<DTO_CachDung> res = null;
            using (var context = new SQLServerDBContext())
            {
                try
                {
                    var list = await context.CachDung.SqlQuery("select * from CACHDUNG").ToListAsync();
                    res = new ObservableCollection<DTO_CachDung>(list);
                }
                catch (Exception e)
                {
                    Debug.WriteLine("[ERROR] " + e.Message);
                }
            }
            return res;
        }

        public bool UpdateCachDung(DTO_CachDung cachDung, string tenCachDungMoi)
        {
            using (var context = new SQLServerDBContext())
            {
                var cDMatch = context.CachDung.Where(t => t.TenCachDung.Equals(tenCachDungMoi, StringComparison.OrdinalIgnoreCase));

                if (cDMatch == null)
                    return false;

                cachDung.TenCachDung = tenCachDungMoi;
                return true;
            }
        }
    }
}
