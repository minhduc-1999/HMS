using DAL_Clinic.DAL;

namespace BUS_Clinic.BUS
{
    public abstract class BaseBUS
    {
        public const int SUCCESS_CODE = -9999;
        protected readonly IDataAccess _dataAccess;
        public BaseBUS()
        {
        }
        public BaseBUS(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }
    }
}
