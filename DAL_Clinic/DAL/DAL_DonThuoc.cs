using DTO_Clinic.Form;
using DTO_Clinic.Person;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;


namespace DAL_Clinic.DAL
{
    public class DAL_DonThuoc : BaseDAL
    {
        public DAL_DonThuoc()
        {
        }
        public async Task<string> AddDonThuocAsync(DTO_DonThuoc donThuoc)
        {
            using (var context = new SQLServerDBContext())
            {
                string res = null;
                try
                {
                    var maDon = new SqlParameter("@1", System.Data.SqlDbType.NVarChar);
                    var loiDan = new SqlParameter("@2", System.Data.SqlDbType.NVarChar);
                    maDon.Value = donThuoc.MaDonThuoc;
                    loiDan.Value = donThuoc.LoiDan;
                    res = await context.Database.SqlQuery<string>("exec proc_DonThuoc_insert @1, @2",
                        new SqlParameter[]
                        {
                            maDon,
                            loiDan
                        }).FirstOrDefaultAsync();
                }
                catch (Exception e)
                {
                    Debug.WriteLine("[ERROR] " + e.Message);
                }
                return res;
            }
        }

            public bool LoadNPPKDaKhoa(DTO_DonThuoc donThuoc)
        {
            try
            {
                using (var context = new SQLServerDBContext())
                {
                    context.DonThuoc.Attach(donThuoc);
                    var entry = context.Entry(donThuoc);
                    if (!entry.Reference(p => p.PKDaKhoa).IsLoaded)
                        entry.Reference(p => p.PKDaKhoa).Load();
                    return true;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine($"[ERRROR DAL DonThuoc] {e.Message}");
                return false;
            }
        }
        public bool LoadNP_DSCTDonThuoc(DTO_DonThuoc donThuoc)
        {
            try
            {
                using (var context = new SQLServerDBContext())
                {
                    context.DonThuoc.Attach(donThuoc);
                    var entry = context.Entry(donThuoc);
                    if (!entry.Collection(p => p.DS_CTDonThuoc).IsLoaded)
                        entry.Collection(p => p.DS_CTDonThuoc).Load();
                    return true;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine($"[ERRROR DAL DonThuoc] {e.Message}");
                return false;
            }
        }


    }
}
