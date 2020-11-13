using DAL_Clinic.DAL;
using DTO_Clinic;
using DTO_Clinic.Form;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_Clinic.BUS
{
    public class BUS_PhieuKhamBenh : BaseBUS
    {
        private const string _idPrefix = "PKB";
        public BUS_PhieuKhamBenh()
        {

        }
        public DTO_PKDaKhoa GetPhieuKhamBenh(string maPhieuKhamBenh)
        {
            ObservableCollection<DTO_PKDaKhoa> ListPKB = GetListPKB();
            foreach (DTO_PKDaKhoa item in ListPKB)
            {
                if (item.Id == maPhieuKhamBenh)
                {
                    return item;
                }
            }

            return null;
        }
        public void AddPhieuKhamBenh(DTO_PKDaKhoa phieuKhamBenh)
        {
            //phieuKhamBenh.Id = AutoGenerateID();
            //DALManager.PhieuKhamBenhDAL.AddPhieuKhamBenh(phieuKhamBenh);
        }
        public void LoadNPBenh(DTO_PKDaKhoa phieuKhamBenh)
        {
            //DALManager.PhieuKhamBenhDAL.LoadNPBenh(phieuKhamBenh);
        }
        public void LoadNPBenhNhan(DTO_PKDaKhoa phieuKhamBenh)
        {
           // DALManager.PhieuKhamBenhDAL.LoadNPBenhNhan(phieuKhamBenh);
        }
        public void LoadNPDSCTPhieuKhamBenh(DTO_PKDaKhoa phieuKhamBenh)
        {
           // DALManager.PhieuKhamBenhDAL.LoadNPDSCTPhieuKhamBenh(phieuKhamBenh);
        }
        public override void LoadLocalData()
        {
           // DALManager.PhieuKhamBenhDAL.LoadLocalData();
        }
        public ObservableCollection<DTO_PKDaKhoa> GetListPKB()
        {
            //return DALManager.PhieuKhamBenhDAL.GetListPKB();
            return null;
        }
        public List<string> GetListPKB(string ngayKham)
        {
            //var listpkb = DALManager.PhieuKhamBenhDAL.GetListPKB();
            //var result = from pkb in listpkb
            //             orderby pkb.NgayKham
            //             where pkb.NgayKham.ToString("d") == ngayKham
            //             select pkb.MaBenhNhan;                  
            //return new List<string>(result);
            return null;
        }

        public int DemSoPKB()
        {
            //int re = DALManager.PhieuKhamBenhDAL.GetListPKB().Count;
            //return re;
            return 10;
        }
        public string AutoGenerateID()
        {
            return _idPrefix + (DemSoPKB() + 1).ToString("D5");
        }
    }
}
