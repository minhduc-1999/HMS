using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Clinic.DAL
{
    public abstract class BaseDAL
    {
        public abstract void LoadLocalData();
        public virtual void SaveChange()
        {
            SQLServerDBContext.Instant.SaveChanges();
        }
    }
}
