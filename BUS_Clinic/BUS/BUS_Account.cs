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
    public class BUS_Account: BaseBUS
    {
        public BUS_Account()
        {

        }
        public BUS_Account(DAL_Account dAL_Account) : base(dAL_Account)
        {

        }

        public bool LoadNPNhanVien(DTO_Account acc)
        {
            return DALManager.AccountDAL.LoadNPNhanVien(acc);
        }
        public async Task<ObservableCollection<DTO_Account>> GetListAccAsync()
        {
            return await DALManager.AccountDAL.GetListAccAsync();
        }
    }
}
