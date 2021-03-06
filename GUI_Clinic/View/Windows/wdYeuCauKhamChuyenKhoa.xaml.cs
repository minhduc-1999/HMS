﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using DTO_Clinic.Person;
using DTO_Clinic.Form;
using DTO_Clinic.Component;
using System.Collections.ObjectModel;

namespace GUI_Clinic.View.Windows
{
    /// <summary>
    /// Interaction logic for wdYeuCauKhamChuyenKhoa.xaml
    /// </summary>
    public partial class wdYeuCauKhamChuyenKhoa : Window
    {
        #region Property
        public DTO_BenhNhan benhNhan;
        public DTO_YeuCau yeuCau;
        #endregion
        public wdYeuCauKhamChuyenKhoa()
        {
            InitializeComponent();
        }

        private void btnGuiYeuCau_Click(object sender, RoutedEventArgs e)
        {
            if (tbxYeuCauKhamChuyenKhoa.Text != "")
            {
                yeuCau = new DTO_YeuCau(benhNhan.MaBenhNhan, benhNhan.HoTen, tbxYeuCauKhamChuyenKhoa.Text);
                tblWarning.Visibility = Visibility.Collapsed;
                this.Close();
            }
            else
            {
                tblWarning.Visibility = Visibility.Visible;
            }
        }

        private void btnHuy_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
