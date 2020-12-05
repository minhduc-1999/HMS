using DAL_Clinic.DAL;
using DTO_Clinic.Form;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace BUS_Clinic.BUS
{
    public class BUS_HoaDon : BaseBUS
    {
        public async Task<string> AddHoaDonAsync(DTO_HoaDon hd)
        {
            try
            {
                var res = await DALManager.HoaDonDAL.AddHoaDonAsync(hd);
                if (res.Count == 2)
                {
                    var code = Convert.ToInt32(res[0]);
                    if (code == SUCCESS_CODE)
                        return res[1];
                }
                throw new Exception("Đã có lỗi xảy ra. Vui lòng thực hiện lại.");
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public bool LoadNPBenhNhan(DTO_HoaDon hoaDon)
        {
            return DALManager.HoaDonDAL.LoadNPBenhNhan(hoaDon);
        }
        public ObservableCollection<DTO_HoaDon> GetListHDCKByDate(DateTime date)
        {
            var res = new ObservableCollection<DTO_HoaDon>(DALManager.HoaDonDAL.GetListHDCKByDate(date));
            return res;
        }

        public ObservableCollection<DTO_HoaDon> GetListHoaDon()
        {
            return DALManager.HoaDonDAL.GetListHoaDon();
        }

        public DTO_HoaDon GetHoaDonById(string id)
        {
            DTO_HoaDon hoaDon = GetListHoaDon().Where(x => x.MaHoaDon == id).FirstOrDefault();
            return hoaDon;
        }
    }
}
