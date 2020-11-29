using DTO_Clinic.Form;
using DTO_Clinic.Component;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DAL_Clinic.DAL
{
    public class DAL_PKDaKhoa : BaseDAL
    {
        public DAL_PKDaKhoa()
        {

        }
        public async Task<string> AddPhieuKhamDaKhoaAsync(DTO_PKDaKhoa pKDaKhoa)
        {
            using (var context = new SQLServerDBContext())
            {
                string res = null;
                try
                {
                    res = await context.Database.SqlQuery<string>("exec proc_PKDAKHOA_insert @1",
                        new SqlParameter[]
                        {
                            new SqlParameter("@1", pKDaKhoa.NgayKham)
                        }).FirstOrDefaultAsync();
                }
                catch (Exception e)
                {
                    Debug.WriteLine("[ERROR] " + e.Message);
                }
                return res;
            }
        }

        public bool LoadNPBenh(DTO_PKDaKhoa pKDaKhoa)
        {
            try
            {
                using (var context = new SQLServerDBContext())
                {
                    context.PKDaKhoa.Attach(pKDaKhoa);
                    var entry = context.Entry(pKDaKhoa);
                    if (!entry.Reference(p => p.Benh).IsLoaded)
                        entry.Reference(p => p.Benh).Load();
                    return true;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine($"[ERRROR DAL_PKDAKHOA] {e.Message}");
                return false;
            }

        }

        public bool LoadNPBenhNhan(DTO_PKDaKhoa pKDaKhoa)
        {
            try
            {
                using (var context = new SQLServerDBContext())
                {
                    context.PKDaKhoa.Attach(pKDaKhoa);
                    var entry = context.Entry(pKDaKhoa);
                    if (!entry.Reference(p => p.BenhNhan).IsLoaded)
                        entry.Reference(p => p.BenhNhan).Load();
                    return true;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine($"[ERRROR DAL_PKDAKHOA] {e.Message}");
                return false;
            }
        }

        public async Task<ObservableCollection<DTO_PKDaKhoa>> GetListPKDKAsync()
        {
            ObservableCollection<DTO_PKDaKhoa> res = null;
            using (var context = new SQLServerDBContext())
            {
                try
                {
                    var list = await context.PKDaKhoa.SqlQuery("select * from PKDAKHOA").ToListAsync();
                    res = new ObservableCollection<DTO_PKDaKhoa>(list);
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
