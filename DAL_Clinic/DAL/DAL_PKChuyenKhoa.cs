using DTO_Clinic.Form;
using DTO_Clinic.Person;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;


namespace DAL_Clinic.DAL
{
    public class DAL_PKChuyenKhoa : BaseDAL
    {
        public DAL_PKChuyenKhoa()
        {

        }
        public async Task<List<string>> AddPhieuKhamChuyenKhoaAsync(DTO_PKChuyenKhoa pKChuyenKhoa)
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
                    res = await context.Database.SqlQuery<string>("exec @ReturnCode = proc_PKCK_insert @1, @2, @3, @4",
                        new SqlParameter[]
                        {
                            new SqlParameter("@1", pKChuyenKhoa.NgayKham),
                            new SqlParameter("@2", pKChuyenKhoa.YeuCau),
                            new SqlParameter("@3", pKChuyenKhoa.MaNhanVien),
                            new SqlParameter("@4", pKChuyenKhoa.PhieuKhamDaKhoa.MaPKDK),
                            returnCode
                        }).FirstOrDefaultAsync();
                    var code = ((int)returnCode.Value).ToString();
                    return new List<string> { code, res };
                }
                catch (Exception e)
                {
                    Debug.WriteLine("[ERROR ADD PKCK] " + e.Message);
                    throw e;
                }
            }
        }

        public List<DTO_BenhNhan> GetListBNByDate(DateTime dt)
        {
            using (var context = new SQLServerDBContext())
            {
                var list = context.PKChuyenKhoa.Where(p => p.NgayKham.Day == dt.Day && p.NgayKham.Month == dt.Month && p.NgayKham.Year == dt.Year).Select(p => p.PhieuKhamDaKhoa.BenhNhan).ToList();
                return list;
            }
        }
        public void UpdatePKCK(DTO_PKChuyenKhoa pkck)
        {
            using (var context = new SQLServerDBContext())
            {
                context.Entry(pkck).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
        public List<DTO_PKChuyenKhoa> GetListPKCKByDate(DateTime dt)
        {
            using (var context = new SQLServerDBContext())
            {
                var list = context.PKChuyenKhoa.Where(p => p.NgayKham.Day == dt.Day && p.NgayKham.Month == dt.Month && p.NgayKham.Year == dt.Year).ToList();
                return list;
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
                    if (!entry.Reference(p => p.PhieuKhamDaKhoa).IsLoaded)
                        entry.Reference(p => p.PhieuKhamDaKhoa).Load();
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
