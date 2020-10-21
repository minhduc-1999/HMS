using DTO_Clinic;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Clinic.Initializer
{
    internal class MyInitializer : CreateDatabaseIfNotExists<SQLServerDBContext>
    {
        protected override void Seed(SQLServerDBContext context)
        {
            context.ThamSo.AddRange(new[]
            {
                new DTO_ThamSo{ TenThamSo = "Số bệnh nhân tối đa 1 ngày", GiaTri = 40},
                new DTO_ThamSo{ TenThamSo = "Tiền khám", GiaTri = 30000}
            });
            context.SaveChanges();
        }
    }
}
