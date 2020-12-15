using BUS_Clinic.BUS;
using DTO_Clinic;
using DTO_Clinic.Form;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace GUI_Clinic.View.Windows
{
    /// <summary>
    /// Interaction logic for wdDanhSachPhieuKhamChuyenKhoa.xaml
    /// </summary>
    public partial class wdDanhSachPhieuKhamChuyenKhoa : Window
    {
        public DTO_PKDaKhoa PKDaKhoa { get; set; }
        private ObservableCollection<DTO_PKChuyenKhoa> ListPKCK { get; set; }
        public wdDanhSachPhieuKhamChuyenKhoa(DTO_PKDaKhoa pkDaKhoa)
        {
            InitializeComponent();
            this.DataContext = this;
            BUSManager.PKDaKhoaBUS.LoadNPBenhNhan(pkDaKhoa);
            BUSManager.PKDaKhoaBUS.LoadNP_DSPKCK(pkDaKhoa);
            ListPKCK = new ObservableCollection<DTO_PKChuyenKhoa>();
            PKDaKhoa = pkDaKhoa;
            foreach (DTO_PKChuyenKhoa item in pkDaKhoa.DS_PKhamChuyenKhoa)
            {
                if (item.KetQua != "")
                {
                    BUSManager.PKChuyenKhoaBUS.LoadNPBacSi(item);
                    ListPKCK.Add(item);
                }
            }
            lvPKCK.ItemsSource = ListPKCK; 
        }

    }
}
