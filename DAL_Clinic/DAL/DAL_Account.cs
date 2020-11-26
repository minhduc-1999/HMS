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

        public void LoadNPNhanVienAsync(DTO_Account acc)
        {
            using (var context = new SQLServerDBContext())
            {
                try
                {
                    var tempAcc = context.Account.Where(c => c.MaNhanVien == acc.MaNhanVien).FirstOrDefault();
                    var entry = context.Entry(tempAcc);
                    entry.Reference(c => c.NhanVien).Load();
                    acc.NhanVien = tempAcc.NhanVien;
                }
                catch (Exception e)
                {
                    Debug.WriteLine("[ERROR] " + e.Message);
                }
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
