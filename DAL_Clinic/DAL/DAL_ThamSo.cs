using DTO_Clinic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Clinic.DAL
{
    public class DAL_ThamSo : BaseDAL
    {
       
        public ObservableCollection<DTO_ThamSo> GetListThamSo()
        {
            return null;
        }
        public void UpdateThamSo(int TienKham, int SoBNToiDa)
        {
            
        }
    }
}
