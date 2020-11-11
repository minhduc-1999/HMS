﻿using DTO_Clinic.Component;
using System.Data.Entity.ModelConfiguration;

namespace DAL_Clinic.BuddyClass
{
    public class PhongMap : EntityTypeConfiguration<DTO_Phong>
    {
        public PhongMap()
        {
            ToTable("PHONG");
            HasKey(p => p.Id);
            Property(p => p.Id).HasColumnName("MaPhong");
            Property(p => p.TenPhong).IsRequired();
        }
    }
}
