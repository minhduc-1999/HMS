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
    public class DAL_Phong : BaseDAL
    {
        public DAL_Phong()
        {
        }
        public async Task<string> AddPhongAsync(DTO_Phong phong)
        {
            using (var context = new SQLServerDBContext())
            {
                string res = null;
                try
                {
                    var tenPhong = new SqlParameter("@1", System.Data.SqlDbType.NVarChar);
                    tenPhong.Value = phong.TenPhong;
                    res = await context.Database.SqlQuery<string>("exec proc_Phong_insert @1",
                        new SqlParameter[]
                        {
                            tenPhong
                        }).FirstOrDefaultAsync();
                }
                catch (Exception e)
                {
                    Debug.WriteLine("[ERROR] " + e.Message);
                }
                return res;
            }
        }

        public async Task<ObservableCollection<DTO_Phong>> GetListPhongAsync()
        {
            ObservableCollection<DTO_Phong> res = null;
            using (var context = new SQLServerDBContext())
            {
                try
                {
                    context.Database.Log = s => Debug.WriteLine(s);
                    var list = await context.Phong.SqlQuery("select * from PHONG").ToListAsync();
                    res = new ObservableCollection<DTO_Phong>(list);
                }
                catch (Exception e)
                {
                    Debug.WriteLine("[ERROR] " + e.Message);
                }
            }
            return res;
        }

        public bool UpdatePhong(DTO_Phong phong, string tenPhongMoi)
        {
            using (var context = new SQLServerDBContext())
            {
                var phongMatch = context.Phong.Where(t => t.TenPhong.Equals(tenPhongMoi, StringComparison.OrdinalIgnoreCase));

                if (phongMatch == null)
                    return false;

                phong.TenPhong = tenPhongMoi;
                return true;
            }
        }

    }
}
