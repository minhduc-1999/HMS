﻿using DTO_Clinic.Form;
using System.Collections.Generic;

namespace DTO_Clinic.Component
{
    public class DTO_Benh : BaseModel
    {
        public string TenBenh { get => _tenBenh; set { _tenBenh = value; OnPropertyChanged(); }  }
        private string _tenBenh;
        public virtual ICollection<DTO_PKDaKhoa> DS_PKDaKhoa { get; set; }

        public DTO_Benh() : base()
        {
        }
        public override string ToString()
        {
            return TenBenh;
        }
    }
}