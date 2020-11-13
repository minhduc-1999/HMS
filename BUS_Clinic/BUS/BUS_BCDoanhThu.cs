using DAL_Clinic.DAL;
using DTO_Clinic;
using DTO_Clinic.Form;
using DTO_Clinic.Form;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace BUS_Clinic.BUS
{
    public class BUS_BCDoanhThu : BaseBUS
    {
        public BUS_BCDoanhThu()
        {

        }
        public void AddBCDoanhThu(DTO_BCDoanhThu bCDoanhThu)
        {
            ObservableCollection<DTO_BCDoanhThu> ListBCDT = GetListBCDoanhThu();
            foreach (DTO_BCDoanhThu item in ListBCDT)
            {
                if (bCDoanhThu.Thang == item.Thang &&
                    bCDoanhThu.Nam == item.Nam)
                {
                    return;
                }
            }
            DALManager.BCDoanhThuDAL.AddBCDoanhThu(bCDoanhThu);
        }
        public DTO_BCDoanhThu GetBCDoanhThuToday()
        {
            return GetListBCDoanhThu().Where(c => c.Thang == DateTime.Now.Month && c.Nam == DateTime.Now.Year).FirstOrDefault();
        }
        public void LoadNPCTBaoCaoDoanhThu(DTO_BCDoanhThu bCDoanhThu)
        {
            DALManager.BCDoanhThuDAL.LoadNPCTBaoCaoDoanhThu(bCDoanhThu);
        }
        public ObservableCollection<DTO_BCDoanhThu> GetListBCDoanhThu()
        {
            return DALManager.BCDoanhThuDAL.GetListBCDoanhThu();
        }

    }
}
