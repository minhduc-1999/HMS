using DTO_Clinic.Form;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DAL_Clinic.DAL
{
    public class DAL_PKChuyenKhoa : BaseDAL
    {
        public DAL_PKChuyenKhoa()
        {

        }
        public async Task<string> AddPhieuKhamChuyenKhoaAsync(DTO_PKChuyenKhoa pKChuyenKhoa)
        {
            using (var context = new SQLServerDBContext())
            {
                string res = null;
                try
                {
                    res = await context.Database.SqlQuery<string>("exec proc_PKDAKHOA_insert @1",
                        new SqlParameter[]
                        {
                            new SqlParameter("@1", pKChuyenKhoa.MaPKDaKhoa)
                        }).FirstOrDefaultAsync();
                }
                catch (Exception e)
                {
                    Debug.WriteLine("[ERROR] " + e.Message);
                }
                return res;
            }
        }


        public async Task<ObservableCollection<DTO_PKChuyenKhoa>> GetListPKCKAsync()
        {
            ObservableCollection<DTO_PKChuyenKhoa> res = null;
            using (var context = new SQLServerDBContext())
            {
                try
                {
                    var list = await context.PKChuyenKhoa.SqlQuery("select * from PKCHUYENKHOA").ToListAsync();
                    res = new ObservableCollection<DTO_PKChuyenKhoa>(list);
                }
                catch (Exception e)
                {
                    Debug.WriteLine("[ERROR] " + e.Message);
                }
            }
            return res;
        }

        public bool LoadNPPKDaKhoa (DTO_PKChuyenKhoa pKChuyenKhoa)
        {
            try
            {
                using (var context = new SQLServerDBContext())
                {
                    context.PKChuyenKhoa.Attach(pKChuyenKhoa);
                    var entry = context.Entry(pKChuyenKhoa);
                    if (!entry.Reference(p => p.MaPKDaKhoa).IsLoaded)
                        entry.Reference(p => p.MaPKDaKhoa).Load();
                    return true;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine($"[ERRROR DAL_PKCHUYENKHOA] {e.Message}");
                return false;
            }
        }

        public bool LoadNPBenhNhan(DTO_PKChuyenKhoa pKChuyenKhoa)
        {
            try
            {
                using (var context = new SQLServerDBContext())
                {
                    context.PKChuyenKhoa.Attach(pKChuyenKhoa);
                    var entry = context.Entry(pKChuyenKhoa);
                    if (!entry.Reference(p => p.MaPKDaKhoa).IsLoaded)
                        entry.Reference(p => p.MaPKDaKhoa).Load();
                    return true;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine($"[ERRROR DAL_PKCHUYENKHOA] {e.Message}");
                return false;
            }
        }

        public bool LoadNPYeuCau(DTO_PKChuyenKhoa pKChuyenKhoa)
        {
            try
            {
                using (var context = new SQLServerDBContext())
                {
                    context.PKChuyenKhoa.Attach(pKChuyenKhoa);
                    var entry = context.Entry(pKChuyenKhoa);
                    if (!entry.Reference(p => p.YeuCau).IsLoaded)
                        entry.Reference(p => p.YeuCau).Load();
                    return true;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine($"[ERRROR DAL_PKDAKHOA] {e.Message}");
                return false;
            }
        }
    }
}
