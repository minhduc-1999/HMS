namespace DTO_Clinic.Component
{
    public class DTO_Phong : BaseModel
    {
        public string TenPhong 
        {
            get => _tenPhong;
            set
            {
                _tenPhong = value;
                OnPropertyChanged();
            }
        }

        private string _tenPhong;

    }
}
