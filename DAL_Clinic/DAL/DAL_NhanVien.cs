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
    public class DAL_NhanVien: BaseDAL
    {

        public async Task<ObservableCollection<DTO_NhanVien>> GetListNVAsync()
        {
            ObservableCollection<DTO_NhanVien> res = null;
            using (var context = new SQLServerDBContext())
            {
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

        public bool IsNVDaTonTai(DTO_NhanVien nhanVien)
        {
            using (var context = new SQLServerDBContext())
            {
                return context.NhanVien.Any(t => (t.SoCMND == nhanVien.SoCMND));
            }
        }

        public bool UpdateInfoNV(DTO_NhanVien nv, string ten, DateTime ngaySinh, bool gioiTinh, string email, string diaChi, string sdt, string soCMND, string maNhom, string maPhong)
        {
            using (var context = new SQLServerDBContext())
            {
                var res = context.NhanVien.FirstOrDefault(n => n.MaNhanVien == nv.MaNhanVien);
                if (res != null)
                {
                    res.HoTen = ten;
                    res.NgaySinh = ngaySinh;
                    res.GioiTinh = gioiTinh;
                    res.Email = email;
                    res.DiaChi = diaChi;
                    res.SoDienThoai = sdt;
                    res.SoCMND = soCMND;
                    res.MaNhom = maNhom;
                    res.MaPhong = maPhong;

                    context.SaveChanges();

                    return true;
                }
            }
            return false;
        }
        public bool LoadNPAccount(DTO_NhanVien nhanVien)
        {
            try
            {
                using (var context = new SQLServerDBContext())
                {
                    context.NhanVien.Attach(nhanVien);
                    var entry = context.Entry(nhanVien);
                    if (!entry.Reference(p => p.Account).IsLoaded)
                        entry.Reference(p => p.Account).Load();
                    return true;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine($"[ERRROR DAL NHANVIEN] {e.Message}");
                return false;
            }
        }

        public bool LoadNPGroup(DTO_NhanVien nhanVien)
        {
            try
            {
                using (var context = new SQLServerDBContext())
                {
                    context.NhanVien.Attach(nhanVien);
                    var entry = context.Entry(nhanVien);
                    //if (!entry.Reference(p => p.Nhom).IsLoaded)
                        entry.Reference(p => p.Nhom).Load();
                    return true;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine($"[ERRROR DAL NHANVIEN] {e.Message}");
                return false;
            }
        }
        public bool LoadNPPhong(DTO_NhanVien nhanVien)
        {
            try
            {
                using (var context = new SQLServerDBContext())
                {
                    context.NhanVien.Attach(nhanVien);
                    var entry = context.Entry(nhanVien);
                    //if (!entry.Reference(p => p.Nhom).IsLoaded)
                    entry.Reference(p => p.Phong).Load();
                    return true;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine($"[ERRROR DAL NHANVIEN] {e.Message}");
                return false;
            }
        }


        public async Task<DTO_NhanVien> GetNVByID(string strMaNV)
        {
            if (strMaNV == null) return null;
            DTO_NhanVien res = null;
            using (var context = new SQLServerDBContext())
            {
                res = await context.NhanVien.SqlQuery("select top 1 * from NHANVIEN nv where nv.MaNhanVien=@id",
                   new SqlParameter("@id", strMaNV)).FirstOrDefaultAsync();
            }
            return res;
        }

        public async Task<List<string>> AddNhanVienAsync(DTO_NhanVien nv)
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
                    nameParam.Value = nv.HoTen;
                    addressParam.Value = nv.DiaChi;
                    if (string.IsNullOrEmpty(nv.Email))
                        emailParam.Value = DBNull.Value;
                    else
                        emailParam.Value = nv.Email;
                    res = await context.Database.SqlQuery<string>("exec @ReturnCode = proc_NhanVien_insert @1, @2, @3, @4, @5, @6, @7, @8, @9",
                           new SqlParameter[]
                           {
                    returnCode,
                    nameParam,
                    new SqlParameter("@2", nv.NgaySinh),
                    new SqlParameter("@3", nv.GioiTinh),
                    addressParam,
                    new SqlParameter("@5", nv.SoDienThoai),
                    new SqlParameter("@6", nv.SoCMND),
                    emailParam,
                    new SqlParameter("@8", nv.MaNhom),
                    new SqlParameter("@9", nv.MaPhong)
                           }).FirstOrDefaultAsync();
                    var code = ((int)returnCode.Value).ToString();
                    return new List<string> { code, res };
                }
                catch (Exception e)
                {
                    Debug.WriteLine("[ERROR ADD NHANVIEN] " + e.Message);
                    throw e;
                }
            }
        }
    }
}
