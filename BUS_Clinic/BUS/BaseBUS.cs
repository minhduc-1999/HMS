using DAL_Clinic.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_Clinic.BUS
{
    public abstract class BaseBUS
    {
        public abstract void LoadLocalData();
        public virtual void SaveChange()
        {
            DALManager.BenhNhanDAL.SaveChange();
        }
    }
}
