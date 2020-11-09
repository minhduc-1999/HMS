using System.Collections.Generic;

namespace DTO_Clinic.Person
{
    public class DTO_BenhNhan : Person
    {
        public virtual ICollection<DTO_PhieuKhamBenh> DSPhieuKhamBenh { get; set; }
        public override string ToString()
        {
            return Id + " - " + HoTen;
        }
    }
}
