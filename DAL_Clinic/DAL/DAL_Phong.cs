using DTO_Clinic.Component;
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
    public class DAL_Phong : BaseDAL
    {
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

        public async Task<DTO_Phong> GetPhongById(string strMaPhong)
        {
            if (strMaPhong == null) return null;
            DTO_Phong res = null;
            using (var context = new SQLServerDBContext())
            {
                res = await context.Phong.SqlQuery("select top 1 * from PHONG p where p.MaPhong=@id",
                   new SqlParameter("@id", strMaPhong)).FirstOrDefaultAsync();
            }
            return res;
        }
    }
}
