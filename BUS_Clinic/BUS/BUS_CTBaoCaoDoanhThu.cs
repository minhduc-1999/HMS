using DAL_Clinic.DAL;
using DTO_Clinic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_Clinic.BUS
{
    public class BUS_CTBaoCaoDoanhThu : BaseBUS
    {
        public BUS_CTBaoCaoDoanhThu()
        {

        }
        public void AddCTBaoCaoDoanhThu(DTO_CTBaoCaoDoanhThu cTBaoCaoDoanhThu)
        {
            ObservableCollection<DTO_CTBaoCaoDoanhThu> ListCTBCDT = GetListCTBCDT();
            foreach  (DTO_CTBaoCaoDoanhThu item in ListCTBCDT)
            {
                if (cTBaoCaoDoanhThu.Ngay == item.Ngay &&
                    cTBaoCaoDoanhThu.Thang == item.Thang &&
                    cTBaoCaoDoanhThu.Nam == item.Nam)
                {
                    item.SoBenhNhan += cTBaoCaoDoanhThu.SoBenhNhan;
                    item.DoanhThu += cTBaoCaoDoanhThu.DoanhThu;
                    BUSManager.BCDoanhThuBUS.GetBCDoanhThuToday().TongDoanhThu += cTBaoCaoDoanhThu.DoanhThu;
                    UpdateTyLe(ListCTBCDT);
                    return;
                }
            }
            DTO_BCDoanhThu bCDoanhThu = new DTO_BCDoanhThu(DateTime.Now);
            BUSManager.BCDoanhThuBUS.AddBCDoanhThu(bCDoanhThu);
            DALManager.CTBaoCaoDoanhThuDAL.AddCTBaoCaoDoanhThu(cTBaoCaoDoanhThu);
            BUSManager.BCDoanhThuBUS.GetBCDoanhThuToday().TongDoanhThu += cTBaoCaoDoanhThu.DoanhThu;
            BUSManager.CTBaoCaoDoanhThuBUS.SaveChange();
            UpdateTyLe(ListCTBCDT);
        }
        public void UpdateTyLe(ObservableCollection<DTO_CTBaoCaoDoanhThu> ListCTBCDT)
        {
            float TongDoanhThu = BUSManager.BCDoanhThuBUS.GetBCDoanhThuToday().TongDoanhThu;
            foreach (DTO_CTBaoCaoDoanhThu item in ListCTBCDT)
            {
                item.TyLe = (item.DoanhThu / TongDoanhThu) * 100;
            }
        }
        public ObservableCollection<DTO_CTBaoCaoDoanhThu> GetListCTBCDT()
        {
            return DALManager.CTBaoCaoDoanhThuDAL.GetListCTBCDT();
        }
        public override void LoadLocalData()
        {
            DALManager.CTBaoCaoDoanhThuDAL.LoadLocalData();
        }
    }
}
