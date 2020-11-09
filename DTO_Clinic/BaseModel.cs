using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DTO_Clinic
{
    public class BaseModel : INotifyPropertyChanged
    {
        public string Id { get; set; }
        protected bool _isDeleted;
        public bool IsDeleted { get => _isDeleted; set { _isDeleted = value; OnPropertyChanged(); } }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public BaseModel()
        {
            IsDeleted = false;
        }
    }
}
