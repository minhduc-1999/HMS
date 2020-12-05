using DTO_Clinic.Form;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;

namespace DAL_Clinic.DAL
{
    public class DAL_CTBaoCaoDoanhThu : BaseDAL
    {
        public DAL_CTBaoCaoDoanhThu()
        {

        }
        public void AddCTBaoCaoDoanhThu(DTO_CTBaoCaoDoanhThu cTBaoCaoDoanhThu)
        {
            using (var context = new SQLServerDBContext())
            {
                context.CT_BaoCaoDoanhThu.Add(cTBaoCaoDoanhThu);
                context.SaveChanges();
            }
        }
        public void UpdateCTBaoCaoDoanhThu(DTO_CTBaoCaoDoanhThu cTBaoCaoDoanhThu)
        {
            using (var context = new SQLServerDBContext())
            {
                context.Entry(cTBaoCaoDoanhThu).State = EntityState.Modified;
                context.SaveChanges();
            }
        }       
        public List<DTO_CTBaoCaoDoanhThu> GetListByMonth(int month, int year)
        {
            using (var context = new SQLServerDBContext())
            {
               return context.CT_BaoCaoDoanhThu.Where(ct => ct.Thang == month && ct.Nam == year).ToList();
            }
        }
      
    }
}
