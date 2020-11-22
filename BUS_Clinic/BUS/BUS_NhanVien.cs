using DAL_Clinic.DAL;
using DTO_Clinic.Person;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace BUS_Clinic.BUS
{
    public class BUS_NhanVien: BaseBUS
    {
        public BUS_NhanVien()
        {

        }
        public BUS_NhanVien(DAL_NhanVien dAL_NhanVien) : base(dAL_NhanVien)
        {

        }
        public async Task<ObservableCollection<DTO_NhanVien>> GetListNVAsync()
        {
            return await DALManager.NhanVienDAL.GetListNVAsync();
        }
    }
}
