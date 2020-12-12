using DAL_Clinic.DAL;
using DTO_Clinic;
using DTO_Clinic.Form;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace BUS_Clinic.BUS
{
    public class BUS_BCSuDungThuoc : BaseBUS
    {
        public void AddBCSuDungThuoc(DTO_BCSudungThuoc bCSudungThuoc)
        {
            bCSudungThuoc.SoLanDung++;
            DALManager.BCSuDungThuocDAL.AddBCSuDungThuoc(bCSudungThuoc);
        }

        public bool CheckIfBCSDTTonTai(string maThuoc, DateTime ngaySuDung)
        {
            ObservableCollection<DTO_BCSudungThuoc> ListBCSDT = GetListBCSuDungThuoc();

            return ListBCSDT.Any(t => (t.MaThuoc == maThuoc) && (t.Thang == ngaySuDung.Month) && (t.Nam == ngaySuDung.Year));
        }

        public ObservableCollection<DTO_BCSudungThuoc> GetListBCSuDungThuoc()
        {
            return DALManager.BCSuDungThuocDAL.GetListBCSuDungThuoc();
        }

        public void CapNhatBCSDThuoc(string maThuoc, DateTime ngaySuDung, int soLuongDung)
        {
            DALManager.BCSuDungThuocDAL.CapNhatBCSDThuoc(maThuoc, ngaySuDung, soLuongDung);
        }

        public bool LoadNP_Thuoc(DTO_BCSudungThuoc bCSudungThuoc)
        {
            return DALManager.BCSuDungThuocDAL.LoadNP_Thuoc(bCSudungThuoc);
        }
    }
}
