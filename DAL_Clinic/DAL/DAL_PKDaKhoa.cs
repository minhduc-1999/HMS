using DTO_Clinic.Form;
using DTO_Clinic.Component;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DTO_Clinic.Person;
using System.Data;
using System.Data.Entity;

namespace DAL_Clinic.DAL
{
    public class DAL_PKDaKhoa : BaseDAL
    {
        public DAL_PKDaKhoa()
        {

        }
        public async Task<List<string>> AddPhieuKhamDaKhoaAsync(DTO_PKDaKhoa pKDaKhoa)
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
                    res = await context.Database.SqlQuery<string>("exec @ReturnCode = proc_PKDK_insert @1, @2, @3",
                        new SqlParameter[]
                        {
                            new SqlParameter("@1", pKDaKhoa.NgayKham),
                            new SqlParameter("@2", pKDaKhoa.MaBenhNhan),
                            new SqlParameter("@3", pKDaKhoa.MaNhanVien),
                            returnCode
                        }).FirstOrDefaultAsync();
                    var code = ((int)returnCode.Value).ToString();
                    return new List<string> { code, res };
                }
                catch (Exception e)
                {
                    Debug.WriteLine("[ERROR ADD PKDK] " + e.Message);
                    throw e;
                }
            }
        }

        public bool LoadNPDonThuoc(DTO_PKDaKhoa pKDaKhoa)
        {
            try
            {
                using (var context = new SQLServerDBContext())
                {
                    context.PKDaKhoa.Attach(pKDaKhoa);
                    var entry = context.Entry(pKDaKhoa);
                    if (!entry.Reference(p => p.DonThuoc).IsLoaded)
                        entry.Reference(p => p.DonThuoc).Load();
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
        public bool LoadNP_DSPKCK(DTO_PKDaKhoa pKDaKhoa)
        {
            try
            {
                using (var context = new SQLServerDBContext())
                {
                    context.PKDaKhoa.Attach(pKDaKhoa);
                    var entry = context.Entry(pKDaKhoa);
                        entry.Collection(p => p.DS_PKhamChuyenKhoa).Load();
                    return true;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine($"[ERRROR LOADNP_DSPKCK] {e.Message}");
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
                    await context.PKDaKhoa.LoadAsync();
                    res = new ObservableCollection<DTO_PKDaKhoa>(context.PKDaKhoa.Local);
                }
                catch (Exception e)
                {
                    Debug.WriteLine("[ERROR] " + e.Message);
                }
            }
            return res;
        }
      
        public List<DTO_BenhNhan> GetListBNByDate(DateTime dt)
        {
            using (var context = new SQLServerDBContext())
            {
                //try
                //{
                    var list = context.PKDaKhoa.Where(p => p.NgayKham.Day == dt.Day && p.NgayKham.Month == dt.Month && p.NgayKham.Year == dt.Year).Select(p => p.BenhNhan).ToList();
                    return list;
                //}
                //catch (Exception e)
                //{
                //    Debug.WriteLine("[ERROR GetListBNbyDate PKDK] " + e.Message);
                //    throw e;
                //}
            }
        }
        public List<DTO_PKDaKhoa> GetListPKBByDate(DateTime dt)
        {
            using (var context = new SQLServerDBContext())
            {
                var list = context.PKDaKhoa.Where(p => p.NgayKham.Day == dt.Day && p.NgayKham.Month == dt.Month && p.NgayKham.Year == dt.Year).ToList();
                return list;
            }
        }


        public int GetAmountByDate(DateTime dt)
        {
            using (var context = new SQLServerDBContext())
            {
                int res = context.PKDaKhoa.Count(p => p.NgayKham.Day == dt.Day && p.NgayKham.Month == dt.Month && p.NgayKham.Year == dt.Year);
                return res;
            }
        }
        public void UpdatePKDK(DTO_PKDaKhoa pkdk)
        {
            using (var context = new SQLServerDBContext())
            {
                context.Entry(pkdk).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
        public bool isSigned(DTO_BenhNhan bn)
        {
            using (var context = new SQLServerDBContext())
            {
                try
                {
                    var res = context.PKDaKhoa.Count(p => p.MaBenhNhan == bn.MaBenhNhan 
                    && p.NgayKham.Day == DateTime.Now.Day && p.NgayKham.Month == DateTime.Now.Month && p.NgayKham.Year == DateTime.Now.Year
                    && (p.MaBacSi == null ||  p.ChanDoan == null));
                    if (res == 0)
                    {
                        return false;
                    }
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
                
            }    
        }
    }
}
