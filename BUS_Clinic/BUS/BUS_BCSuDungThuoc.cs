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
    public class BUS_BCSuDungThuoc : BaseBUS
    {
        public void AddBCSuDungThuoc(DTO_BCSudungThuoc bCSudungThuoc)
        {
            ObservableCollection<DTO_BCSudungThuoc> ListBCSDT = GetListBCSuDungThuoc();
            //bool flag = true;
            foreach (DTO_BCSudungThuoc item in ListBCSDT)
            {
                if (item.MaThuoc == bCSudungThuoc.MaThuoc && item.Nam == bCSudungThuoc.Nam && item.Thang == bCSudungThuoc.Thang)
                {
                    item.SoLanDung++;
                    item.SoLuongDung += bCSudungThuoc.SoLuongDung;
                    return;
                }
            }
            bCSudungThuoc.SoLanDung++;
            DALManager.BCSuDungThuocDAL.AddBCSuDungThuoc(bCSudungThuoc);
        }
        public ObservableCollection<DTO_BCSudungThuoc> GetListBCSuDungThuoc()
        {
            return DALManager.BCSuDungThuocDAL.GetListBCSuDungThuoc();
        }
        public override void LoadLocalData()
        {
            DALManager.BCSuDungThuocDAL.LoadLocalData();
        }
    }
}
