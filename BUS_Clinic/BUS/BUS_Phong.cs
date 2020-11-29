﻿using DAL_Clinic.DAL;
using DTO_Clinic;
using DTO_Clinic.Component;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_Clinic.BUS
{
    public class BUS_Phong : BaseBUS
    {
        public BUS_Phong()
        {

        }
        public async Task<DTO_Phong> AddPhongAsync(DTO_Phong phong)
        {
            ObservableCollection<DTO_Phong> phongs = await DALManager.PhongDAL.GetListPhongAsync();

            if (phongs.Any(b => b.TenPhong.Equals(phong.TenPhong, StringComparison.OrdinalIgnoreCase)))
            {
                return null;
            }
            phong.MaPhong = await DALManager.PhongDAL.AddPhongAsync(phong);
            return phong;
        }
        public bool UpdatePhong(DTO_Phong phong, string tenPhongMoi)
        {
            return DALManager.PhongDAL.UpdatePhong(phong, tenPhongMoi);

        }

        public async Task<ObservableCollection<DTO_Phong>> GetListPhongAsync()
        {
            return await DALManager.PhongDAL.GetListPhongAsync();
        }
        //public int GetBenhAmount()
        //{
        //    int amount = DALManager.BenhDAL.GetListBenhAsync().Count;
        //    return amount;
        //}

        //public bool BenhFilter(Object item)
        //{
        //    var benh= item as DTO_Benh;
        //    if (benh.IsDeleted)
        //    {
        //        return false;
        //    }
        //    else
        //        return true;
        //}
    }
}