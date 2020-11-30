using DTO_Clinic.Permission;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Clinic.DAL
{
    public class DAL_Group: BaseDAL
    {
        public async Task<DTO_Group> GetNhomByID(string strMaNhom)
        {
            if (strMaNhom == null) return null;
            DTO_Group res = null;
            using (var context = new SQLServerDBContext())
            {
                res = await context.Group.SqlQuery("select top 1 * from GROUP gr where gr.MaNhom=@id",
                   new SqlParameter("@id", strMaNhom)).FirstOrDefaultAsync();
            }
            return res;
        }
    }
}
