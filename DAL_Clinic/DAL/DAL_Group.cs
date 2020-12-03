using DTO_Clinic.Permission;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Clinic.DAL
{
    public class DAL_Group : BaseDAL
    {
        public DTO_Group GetNhomByID(string strMaNhom)
        {
            if (strMaNhom == null) return null;
            DTO_Group res = null;
            using (var context = new SQLServerDBContext())
            {
                res = context.Group.Where(g => g.MaNhom == strMaNhom).FirstOrDefault();
            }
            return res;
        }

        public async Task<ObservableCollection<DTO_Group>> GetListNhomAsync()
        {
            ObservableCollection<DTO_Group> res = null;
            using (var context = new SQLServerDBContext())
            {
                try
                {
                    //context.Database.Log = s => Debug.WriteLine(s);
                    await context.Group.LoadAsync();
                    res = new ObservableCollection<DTO_Group>(context.Group.Local);
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
