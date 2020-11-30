using DAL_Clinic.DAL;
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
    public class BUS_Benh : BaseBUS
    {
        public BUS_Benh()
        {

        }
        public async Task<DTO_Benh> AddBenhAsync(DTO_Benh benh)
        {
            ObservableCollection<DTO_Benh> benhs = await DALManager.BenhDAL.GetListBenhAsync();

            //if (benhs.Any(b => b.TenBenh.Equals(benh.TenBenh, StringComparison.OrdinalIgnoreCase) && b.IsDeleted == true))
            //{
            //    benhs.Where(b => b.TenBenh.Equals(benh.TenBenh, StringComparison.OrdinalIgnoreCase) && b.IsDeleted == true).FirstOrDefault().IsDeleted = false;
            //    return true;
            //}
            if (benhs.Any(b => b.TenBenh.Equals(benh.TenBenh, StringComparison.OrdinalIgnoreCase)))
            {
                return null;
            }
            benh.MaBenh = await DALManager.BenhDAL.AddBenhAsync(benh);
            return benh;
        }
        public bool UpdateBenh(DTO_Benh benh, string tenBenhMoi)
        {
            return DALManager.BenhDAL.UpdateBenh(benh, tenBenhMoi);
            
        }
        //public bool Delbenh(DTO_Benh benh)
        //{
        //    ObservableCollection<DTO_Benh> benhs = DALManager.BenhDAL.GetListBenh();
        //    if (benh != null)
        //    {
        //        if (benhs.Any(b=>b.TenBenh.Equals(benh.TenBenh, StringComparison.OrdinalIgnoreCase)))
        //        {
        //            DALManager.BenhDAL.DelBenh(benh);
        //            return true;
        //        }
        //    }
        //    return false;
        //}
      
        public async Task<ObservableCollection<DTO_Benh>> GetListBenhAsync()
        {
            return await DALManager.BenhDAL.GetListBenhAsync();
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
