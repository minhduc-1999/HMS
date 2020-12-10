﻿using DTO_Clinic.Form;
using DTO_Clinic.Person;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;


namespace DAL_Clinic.DAL
{
    public class DAL_DonThuoc : BaseDAL
    {
        public DAL_DonThuoc()
        {
        }
        public void AddDonThuoc(DTO_DonThuoc donThuoc)
        {
                using (var context = new SQLServerDBContext())
                {
                    context.DonThuoc.Add(donThuoc);
                    context.SaveChanges();
                }
        }
       
        public bool LoadNPPKDaKhoa(DTO_DonThuoc donThuoc)
        {
            try
            {
                using (var context = new SQLServerDBContext())
                {
                    context.DonThuoc.Attach(donThuoc);
                    var entry = context.Entry(donThuoc);
                    if (!entry.Reference(p => p.PKDaKhoa).IsLoaded)
                        entry.Reference(p => p.PKDaKhoa).Load();
                    return true;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine($"[ERRROR DAL DonThuoc] {e.Message}");
                return false;
            }
        }
        public bool LoadNP_CTDonThuoc(DTO_DonThuoc donThuoc)
        {
            try
            {
                using (var context = new SQLServerDBContext())
                {
                    context.DonThuoc.Attach(donThuoc);
                    var entry = context.Entry(donThuoc);
                    if (!entry.Collection(p => p.DS_CTDonThuoc).IsLoaded)
                        entry.Collection(p => p.DS_CTDonThuoc).Load();
                    return true;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine($"[ERRROR DAL DonThuoc] {e.Message}");
                return false;
            }
        }


    }
}
