using DTO_Clinic.Component;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DAL_Clinic.DAL
{
    public class DAL_Thuoc: BaseDAL
    {
        public DAL_Thuoc()
        {

        }
        public bool LoadNP_CTPhieuNhapThuoc(DTO_Thuoc thuoc)
        {
            try
            {
                using (var context = new SQLServerDBContext())
                {
                    context.Thuoc.Attach(thuoc);
                    var entry = context.Entry(thuoc);
                    if (!entry.Collection(p => p.DS_CTPhieuNhapThuoc).IsLoaded)
                        entry.Collection(p => p.DS_CTPhieuNhapThuoc).Load();
                    return true;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine($"[ERRROR DAL BENH] {e.Message}");
                return false;
            }
        }
        public async Task<string> AddThuocAsync(DTO_Thuoc thuoc)
        {
            using (var context = new SQLServerDBContext())
            {
                string res = null;
                try
                {
                    var donVi = new SqlParameter("@1", System.Data.SqlDbType.NVarChar);
                    var tenThuoc = new SqlParameter("@2", System.Data.SqlDbType.NVarChar);
                    var congDung = new SqlParameter("@3", System.Data.SqlDbType.NVarChar);
                    donVi.Value = thuoc.DonVi;
                    tenThuoc.Value = thuoc.TenThuoc;
                    congDung.Value = thuoc.CongDung;
                    res = await context.Database.SqlQuery<string>("exec proc_Thuoc_insert @1, @2, @3, @4, @5",
                        new SqlParameter[]
                        {
                            donVi,
                            tenThuoc,
                            congDung,
                            new SqlParameter("@4", thuoc.DonGia),
                            new SqlParameter("@5", thuoc.SoLuong)
                        }).FirstOrDefaultAsync();
                }
                catch (Exception e)
                {
                    Debug.WriteLine("[ERROR] " + e.Message);
                }
                return res;
            }
        }
     
        public ObservableCollection<DTO_Thuoc> GetListThuoc()
        {
            ObservableCollection<DTO_Thuoc> res = null;
            using (var context = new SQLServerDBContext())
            {
                try
                {
                    context.Database.Log = s => Debug.WriteLine(s);
                    context.Thuoc.Load();
                    res = new ObservableCollection<DTO_Thuoc>(context.Thuoc.Local);
                }
                catch (Exception e)
                {
                    Debug.WriteLine("[ERROR] " + e.Message);
                }
            }
            return res;
        }

        public List<string> GetDonViByTenThuoc(string tenThuoc)
        {
            using (var context = new SQLServerDBContext())
            {
                var donVi = context.Thuoc.Where(t => t.TenThuoc == tenThuoc).Select(t => t.DonVi).ToList<string>();
                return donVi;
            }
        }

        public bool IsThuocDaTonTai(DTO_Thuoc thuocMoi)
        {
            using (var context = new SQLServerDBContext())
            {
                return context.Thuoc.Any(t => (t.TenThuoc.Equals(thuocMoi.TenThuoc, StringComparison.OrdinalIgnoreCase)) && (t.DonVi == thuocMoi.DonVi));
            }
        }

        public bool UpdateInfoThuoc(DTO_Thuoc thuoc, string ten, string congDung, double donGia)
        {
            using (var context = new SQLServerDBContext())
            {
                var item = context.Thuoc.Where(t => t.TenThuoc == ten).FirstOrDefault();

                bool check;

                if (item != null)
                    check = item.MaThuoc == thuoc.MaThuoc;
                else
                    check = true;

                if (check)
                {
                    thuoc.TenThuoc = ten;
                    thuoc.CongDung = congDung;
                    thuoc.DonGia = donGia;
                    return true;
                }
                else
                    return false;
            }
        }

        public bool CheckIfSoLuongThuocDu(DTO_Thuoc thuocSuDung, int soLuongSuDung)
        {
            ObservableCollection<DTO_Thuoc> listThuoc = GetListThuoc();

            var kq = listThuoc.Where(c => c.MaThuoc == thuocSuDung.MaThuoc).FirstOrDefault();

            if (kq != null)
            {
                if (kq.SoLuong >= soLuongSuDung)
                    return true;
                return false;
            }

            return false;
        }

        public void SuDungThuoc(string maThuoc, int soLuongDung)
        {
            using (var context = new SQLServerDBContext())
            {
                var res = context.Thuoc.Where(t => t.MaThuoc == maThuoc).FirstOrDefault();

                if (res != null)
                {
                    res.SoLuong -= soLuongDung;
                }

                context.SaveChanges();
            }
        }
    }
}
