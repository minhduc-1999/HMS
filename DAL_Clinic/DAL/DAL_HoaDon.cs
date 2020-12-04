using DTO_Clinic;
using DTO_Clinic.Form;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Clinic.DAL
{
    public class DAL_HoaDon : BaseDAL
    {
        public async Task<List<string>> AddHoaDonAsync(DTO_HoaDon hd)
        {
            using (var context = new SQLServerDBContext())
            {
                var returnCode = new SqlParameter();
                returnCode.ParameterName = "@ReturnCode";
                returnCode.SqlDbType = SqlDbType.Int;
                returnCode.Direction = ParameterDirection.Output;
                string res = null;
                try
                {
                    res = await context.Database.SqlQuery<string>("exec @ReturnCode = proc_HoaDon_insert @1, @2, @3, @4, @5, @6",
                        new SqlParameter[]
                        {
                            new SqlParameter("@1", hd.ChiTiet),
                            new SqlParameter("@2", hd.ThanhTien),
                            new SqlParameter("@3", hd.NgayLap),
                            new SqlParameter("@4", hd.LoaiHoaDon),
                            new SqlParameter("@5", hd.MaBenhNhan),
                            new SqlParameter("@6", hd.MaNhanVien),
                            returnCode
                        }).FirstOrDefaultAsync();
                    var code = ((int)returnCode.Value).ToString();
                    return new List<string> { code, res };
                }
                catch (Exception e)
                {
                    Debug.WriteLine("[ERROR ADD HoaDon] " + e.Message);
                    throw e;
                }
            }
        }

        public List<DTO_HoaDon> GetListByMonth(int month, int year)
        {
            using (var context = new SQLServerDBContext())
            {
                var res = context.HoaDon.Where(hd => hd.NgayLap.Month == month && hd.NgayLap.Year == year).ToList();
                return res;
            }
        }
    }
}
