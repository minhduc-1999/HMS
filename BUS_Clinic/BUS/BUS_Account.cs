﻿using DAL_Clinic.DAL;
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

        public bool LoadNPNhanVien(DTO_Account acc)
        {
            return DALManager.AccountDAL.LoadNPNhanVien(acc);
        }
        public async Task<ObservableCollection<DTO_Account>> GetListAccAsync()
        {
            return await DALManager.AccountDAL.GetListAccAsync();
        }
        public bool IsAccDaTonTai(DTO_Account acc)
        {
            return DALManager.AccountDAL.IsAccDaTonTai(acc);
        }

        public async Task<DTO_Account> AddAccAsync(DTO_Account acc)
        {
            acc.MaNhanVien = await DALManager.AccountDAL.AddAccAsync(acc);
            return acc;
        }

        public bool UpdateInfoAcc(DTO_Account acc, string username, string password)
        {
            if (DALManager.AccountDAL.UpdateInfoAcc(acc, username, password))
            {
                acc.Username = username;
                acc.Password = password;
                return true;
            }
            return false;
        }
    }
}
