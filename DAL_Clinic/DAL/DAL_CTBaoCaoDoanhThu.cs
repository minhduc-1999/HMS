using DTO_Clinic.Form;
using System.Collections.ObjectModel;
using System.Data.Entity;

namespace DAL_Clinic.DAL
{
    public class DAL_CTBaoCaoDoanhThu : BaseDAL
    {
        public DAL_CTBaoCaoDoanhThu()
        {

        }
        public void AddCTBaoCaoDoanhThu(DTO_CTBaoCaoDoanhThu cTBaoCaoDoanhThu)
        {
            SQLServerDBContext.Instant.CT_BaoCaoDoanhThu.Local.Add(cTBaoCaoDoanhThu);
        }
        public ObservableCollection<DTO_CTBaoCaoDoanhThu> GetListCTBCDT()
        {
            return SQLServerDBContext.Instant.CT_BaoCaoDoanhThu.Local;
        }
        public override void LoadLocalData()
        {
            SQLServerDBContext.Instant.CT_BaoCaoDoanhThu.Load();
        }
    }
}
