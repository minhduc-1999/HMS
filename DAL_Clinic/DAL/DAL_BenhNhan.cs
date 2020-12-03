using DTO_Clinic.Person;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Threading.Tasks;

namespace DAL_Clinic.DAL
{
    public class DAL_BenhNhan : BaseDAL
    {
        public async Task<List<string>> AddBenhNhanAsync(DTO_BenhNhan bn)
        {
            using (var context = new SQLServerDBContext())
            {
                context.Database.Log = s => Debug.WriteLine(s);
                string res = null;
                try
                {
                    var returnCode = new SqlParameter();
                    returnCode.ParameterName = "@ReturnCode";
                    returnCode.SqlDbType = SqlDbType.Int;
                    returnCode.Direction = ParameterDirection.Output;

                    var emailParam = new SqlParameter("@7", SqlDbType.NVarChar);
                    var nameParam = new SqlParameter("@1", SqlDbType.NVarChar);
                    var addressParam = new SqlParameter("@4", SqlDbType.NVarChar);
                    nameParam.Value = bn.HoTen;
                    addressParam.Value = bn.DiaChi;
                    if (string.IsNullOrEmpty(bn.Email))
                        emailParam.Value = DBNull.Value;
                    else
                        emailParam.Value = bn.Email;
                    res = await context.Database.SqlQuery<string>("exec @ReturnCode = proc_BenhNhan_insert @1, @2, @3, @4, @5, @6, @7",
                           new SqlParameter[]
                           {
                    returnCode,
                    nameParam,
                    new SqlParameter("@2", bn.NgaySinh),
                    new SqlParameter("@3", bn.GioiTinh),
                    addressParam,
                    new SqlParameter("@5", bn.SoDienThoai),
                    new SqlParameter("@6", bn.SoCMND),
                    emailParam
                           }).FirstOrDefaultAsync();
                    var code = ((int)returnCode.Value).ToString();
                    return new List<string> { code, res };
                }
                catch (Exception e)
                {
                    Debug.WriteLine("[ERROR ADD PATIENT] " + e.Message);
                    throw e;
                }
            }
        }
        public async Task<ObservableCollection<DTO_BenhNhan>> GetListBNAsync()
        {
            ObservableCollection<DTO_BenhNhan> res = null;
            using (var context = new SQLServerDBContext())
            {
                context.Database.Log = s => Debug.WriteLine(s);
                try
                {
                    context.Database.Log = s => Debug.WriteLine(s);
                    await context.BenhNhan.LoadAsync();
                    res =new ObservableCollection<DTO_BenhNhan>(context.BenhNhan.Local);
                }
                catch (Exception e)
                {
                    Debug.WriteLine("[ERROR GET LIST PATIENT] " + e.Message);
                }
            }
            return res;
        }
        public bool LoadNP_DSPKDK(DTO_BenhNhan bn)
        {
            try
            {
                using (var context = new SQLServerDBContext())
                {
                    context.BenhNhan.Attach(bn);
                    var entry = context.Entry(bn);
                    if (!entry.Collection(p => p.DS_PKDaKhoa).IsLoaded)
                        entry.Collection(p => p.DS_PKDaKhoa).Load();
                    return true;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine($"[ERRROR LOADNP_DSPKDK] {e.Message}");
                return false;
            }

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
