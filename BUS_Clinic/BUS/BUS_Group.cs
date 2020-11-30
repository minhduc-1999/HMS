using DAL_Clinic.DAL;
using DTO_Clinic.Permission;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_Clinic.BUS
{
    public class BUS_Group: BaseBUS
    {
        public BUS_Group()
        {

        }
        public BUS_Group(DAL_Group dAL_Group) : base(dAL_Group)
        {

        }
        public async Task<ObservableCollection<DTO_Group>> GetListNhomAsync()
        {
            return await DALManager.GroupDAL.GetListNhomAsync();
        }
        public async Task<DTO_Group> GetNhomByID(string strMaNhom)
        {
            return await DALManager.GroupDAL.GetNhomByID(strMaNhom);
        }
    }
}
