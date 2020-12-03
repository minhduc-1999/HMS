using DTO_Clinic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Clinic.DAL
{
    public class DAL_ThamSo : BaseDAL
    {
       
        public async Task<ObservableCollection<DTO_ThamSo>> GetListAsync()
        {
            using (var context = new SQLServerDBContext())
            {
                try
                {
                    await context.ThamSo.LoadAsync();
                    return new ObservableCollection<DTO_ThamSo>(context.ThamSo.Local);
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message);
                    throw e;
                }
                
            }
        }
        public void UpdateThamSo(int TienKham, int SoBNToiDa)
        {
            
        }
    }
}
