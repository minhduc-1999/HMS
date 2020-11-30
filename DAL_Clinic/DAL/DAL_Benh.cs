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
    public class DAL_Benh : BaseDAL
    {
        public DAL_Benh()
        {
        }
        public async Task<string> AddBenhAsync(DTO_Benh benh)
        {
            using (var context = new SQLServerDBContext())
            {
                string res = null;
                try
                {
                    var tenBenh = new SqlParameter("@1", System.Data.SqlDbType.NVarChar);
                    tenBenh.Value = benh.TenBenh;
                    res = await context.Database.SqlQuery<string>("exec proc_Benh_insert @1",
                        new SqlParameter[]
                        {
                            tenBenh
                        }).FirstOrDefaultAsync();
                }
                catch (Exception e)
                {
                    Debug.WriteLine("[ERROR] " + e.Message);
                }
                return res;
            }
        }
        //public void DelBenh(DTO_Benh benh)
        //{
        //    SQLServerDBContext.Instant.Benh.Local.Where(x => x.Id == benh.Id).FirstOrDefault().IsDeleted=true;
        //}

        public async Task<ObservableCollection<DTO_Benh>> GetListBenhAsync()
        {
            ObservableCollection<DTO_Benh> res = null;
            using (var context = new SQLServerDBContext())
            {
                try
                {
                    context.Database.Log = s => Debug.WriteLine(s);
                    var list = await context.Benh.SqlQuery("select * from BENH").ToListAsync();
                    res = new ObservableCollection<DTO_Benh>(list);
                }
                catch (Exception e)
                {
                    Debug.WriteLine("[ERROR] " + e.Message);
                }
            }
            return res;
        }

        public bool UpdateBenh(DTO_Benh benh, string tenBenhMoi)
        {
            using (var context = new SQLServerDBContext())
            {
                var benhMatch = context.Benh.Where(t => t.TenBenh.Equals(tenBenhMoi, StringComparison.OrdinalIgnoreCase));

                if (benhMatch == null)
                    return false;

                benh.TenBenh = tenBenhMoi;
                return true;
            }
        }

    }
}
