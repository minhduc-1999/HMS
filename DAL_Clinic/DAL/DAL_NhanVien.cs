using DTO_Clinic.Person;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Threading.Tasks;

namespace DAL_Clinic.DAL
{
    public class DAL_NhanVien: BaseDAL
    {

        public async Task<ObservableCollection<DTO_NhanVien>> GetListNVAsync()
        {
            ObservableCollection<DTO_NhanVien> res = null;
            using (var context = new SQLServerDBContext())
            {
                //context.Database.Log = s => Debug.WriteLine(s);
                //context.BenhNhan.Load();
                //res = context.BenhNhan.Local;
                try
                {
                    context.Database.Log = s => Debug.WriteLine(s);
                    var list = await context.NhanVien.SqlQuery("select * from NHANVIEN").ToListAsync();
                    res = new ObservableCollection<DTO_NhanVien>(list);
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
