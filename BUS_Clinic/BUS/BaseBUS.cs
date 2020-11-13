using DAL_Clinic.DAL;

namespace BUS_Clinic.BUS
{
    public abstract class BaseBUS
    {
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
