using DTO_Clinic.Form;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;

namespace DAL_Clinic.DAL
{

    public class DAL_BCDoanhThu : BaseDAL
    {
        public DAL_BCDoanhThu()
        {

        }
        public DTO_BCDoanhThu GetBCDoanhThu(int month, int year)
        {
            using (var context = new SQLServerDBContext())
            {
                var res = context.BaoCaoDoanhThu.Where(bc => bc.Thang == month && bc.Nam == year).FirstOrDefault();
                return res;
            }
            
        }
        public bool IsExisted(int month, int year)
        {
            using (var context = new SQLServerDBContext())
            {
                var count = context.BaoCaoDoanhThu.Count(b => b.Thang == month && b.Nam == year);
                if (count > 0)
                    return true;
                return false;
            }
        }
        public void AddBCDoanhThu(DTO_BCDoanhThu bCDoanhThu)
        {
            using (var context = new SQLServerDBContext())
            {
                context.BaoCaoDoanhThu.Add(bCDoanhThu);
                context.SaveChanges();
            }
        }
        public void UpdateBCDoanhThu(DTO_BCDoanhThu bc)
        {
            using (var context = new SQLServerDBContext())
            {
                context.Entry(bc).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
        public void LoadNPCTBaoCaoDoanhThu(DTO_BCDoanhThu bCDoanhThu)
        {
            using (var context = new SQLServerDBContext())
            {
                context.BaoCaoDoanhThu.Attach(bCDoanhThu);
                var entry = context.Entry(bCDoanhThu);
                entry.Collection(bc => bc.DS_CTBaoCaoDoanhThu).Load();
            }
        }
        public ObservableCollection<DTO_BCDoanhThu> GetListBCDoanhThu()
        {
            return null;
        }
    }
}
