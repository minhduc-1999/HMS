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
        private const string _idPrefix = "BE";
        public BUS_Benh()
        {

        }
        public bool AddBenh(DTO_Benh benh)
        {
            ObservableCollection<DTO_Benh> benhs = DALManager.BenhDAL.GetListBenh();

            //if (benhs.Any(b => b.TenBenh.Equals(benh.TenBenh, StringComparison.OrdinalIgnoreCase) && b.IsDeleted == true))
            //{
            //    benhs.Where(b => b.TenBenh.Equals(benh.TenBenh, StringComparison.OrdinalIgnoreCase) && b.IsDeleted == true).FirstOrDefault().IsDeleted = false;
            //    return true;
            //}
            if (benhs.Any(b => b.TenBenh.Equals(benh.TenBenh, StringComparison.OrdinalIgnoreCase)))
            {

                return false;
            }

            benh.Id = AutoGenerateID();
            DALManager.BenhDAL.AddBenh(benh);
            return true;
        }
        public bool UpdateBenh(DTO_Benh benh, string tenBenhMoi)
        {
            ObservableCollection<DTO_Benh> benhs = DALManager.BenhDAL.GetListBenh();

            if (benh.TenBenh == tenBenhMoi || benhs.Any(b => b.TenBenh.Equals(tenBenhMoi, StringComparison.OrdinalIgnoreCase)))
            {
                return false;
            }

            benh.TenBenh = tenBenhMoi;
            return true;
            
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
        public override void LoadLocalData()
        {
            DALManager.BenhDAL.LoadLocalData();
        }
        public ObservableCollection<DTO_Benh> GetListBenh()
        {
            return DALManager.BenhDAL.GetListBenh();
        }
        public int GetBenhAmount()
        {
            int amount = DALManager.BenhDAL.GetListBenh().Count;
            return amount;
        }
        public string AutoGenerateID()
        {
            return _idPrefix + (GetBenhAmount() + 1).ToString("D5");
        }

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
