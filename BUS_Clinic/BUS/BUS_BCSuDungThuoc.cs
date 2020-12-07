using DAL_Clinic.DAL;
using DTO_Clinic;
using System.Collections.ObjectModel;

namespace BUS_Clinic.BUS
{
    public class BUS_BCSuDungThuoc : BaseBUS
    {
        public async void AddBCSuDungThuoc(DTO_BCSudungThuoc bCSudungThuoc)
        {
            ObservableCollection<DTO_BCSudungThuoc> ListBCSDT = await GetListBCSuDungThuocAsync();
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
        public async System.Threading.Tasks.Task<ObservableCollection<DTO_BCSudungThuoc>> GetListBCSuDungThuocAsync()
        {
            return await DALManager.BCSuDungThuocDAL.GetListBCSuDungThuocAsync();
        }
    }
}
