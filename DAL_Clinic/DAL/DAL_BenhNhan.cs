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
    public class DAL_BenhNhan : BaseDAL
    {
        public async Task<string> AddBenhNhanAsync(DTO_BenhNhan bn)
        {
            using (var context = new SQLServerDBContext())
            {
                context.Database.Log = s => Debug.WriteLine(s);
                string res = null;
                try
                {
                    var emailParam = new SqlParameter("@7", System.Data.SqlDbType.NVarChar);
                    if (string.IsNullOrEmpty(bn.Email))
                        emailParam.Value = DBNull.Value;
                    else
                        emailParam.Value = bn.Email;
                    res = await context.Database.SqlQuery<string>("exec proc_BenhNhan_insert @1, @2, @3, @4, @5, @6, @7",
                            new SqlParameter[]
                            {
                    new SqlParameter("@1", bn.HoTen),
                    new SqlParameter("@2", bn.NgaySinh),
                    new SqlParameter("@3", bn.GioiTinh),
                    new SqlParameter("@4", bn.DiaChi),
                    new SqlParameter("@5", bn.SoDienThoai),
                    new SqlParameter("@6", bn.SoCMND),
                    emailParam
                            }).FirstOrDefaultAsync();                   
                    //else
                    //    Debug.WriteLine("no id return");
                    //Debug.WriteLine(list.Count);
                    //foreach (var str in list)
                    //    Debug.WriteLine(str);
                }
                catch (Exception e)
                {
                    Debug.WriteLine("[ERROR] " + e.Message);
                }
                return res;
            }
        }
        public async Task<ObservableCollection<DTO_BenhNhan>> GetListBNAsync()
        {
            ObservableCollection<DTO_BenhNhan> res = null;
            using (var context = new SQLServerDBContext())
            {
                //context.Database.Log = s => Debug.WriteLine(s);
                //context.BenhNhan.Load();
                //res = context.BenhNhan.Local;
                try
                {
                    context.Database.Log = s => Debug.WriteLine(s);
                    var list = await context.BenhNhan.SqlQuery("select * from BENHNHAN").ToListAsync();
                    res = new ObservableCollection<DTO_BenhNhan>(list);
                }
                catch (Exception e)
                {
                    Debug.WriteLine("[ERROR] "+ e.Message);
                }
            }
            return res;
        }

        public async Task<DTO_BenhNhan> GetBNByID(string id)
        {
            if (id == null) return null;
            DTO_BenhNhan res = null;
            using (var context = new SQLServerDBContext())
            {
                res = await context.BenhNhan.SqlQuery("select top 1 * from BENHNHAN bn where bn.MaBenhNhan=@id",
                   new SqlParameter("@id", id)).FirstOrDefaultAsync();
            }
            return res;
        }

    }
}
