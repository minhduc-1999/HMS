using DTO_Clinic.Permission;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Clinic.DAL
{
    public class DAL_Account: BaseDAL
    {
        public async Task<ObservableCollection<DTO_Account>> GetListAccAsync()
        {
            ObservableCollection<DTO_Account> res = null;
            using (var context = new SQLServerDBContext())
            {
                try
                {
                    context.Database.Log = s => Debug.WriteLine(s);
                    var list = await context.Account.SqlQuery("select * from ACCOUNT").ToListAsync();
                    res = new ObservableCollection<DTO_Account>(list);
                }
                catch (Exception e)
                {
                    Debug.WriteLine("[ERROR] " + e.Message);
                }
            }
            return res;
        }

        public bool LoadNPNhanVien(DTO_Account acc)
        {
            try
            {
                using (var context = new SQLServerDBContext())
                {
                    context.Account.Attach(acc);
                    var entry = context.Entry(acc);
                    if (!entry.Reference(p => p.NhanVien).IsLoaded)
                        entry.Reference(p => p.NhanVien).Load();
                    return true;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine($"[ERRROR DAL ACCOUNT] {e.Message}");
                return false;
            }
        }

        public async Task<DTO_Account> GetAccByID(string strMaNV)
        {
            if (strMaNV == null) return null;
            DTO_Account res = null;
            using (var context = new SQLServerDBContext())
            {
                res = await context.Account.SqlQuery("select top 1 * from ACCOUNT ac where acc.MaNhanVien=@id",
                   new SqlParameter("@id", strMaNV)).FirstOrDefaultAsync();
            }
            return res;
        }
    }
}
