using BUS_Clinic.BUS;
using DTO_Clinic;
using DTO_Clinic.Person;
using DTO_Clinic.Form;
using GUI_Clinic.Command;
using GUI_Clinic.CustomControl;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GUI_Clinic.View.UserControls
{
    /// <summary>
    /// Interaction logic for ucDanhSachPhieuKhamBenh.xaml
    /// </summary>
    public partial class ucDanhSachPhieuKhamBenh : UserControl
    {
        public ucDanhSachPhieuKhamBenh()
        {
            InitializeComponent();
            this.DataContext = this;
            ucCTPKB.Finish += UcCTPKB_Finish;
            InitDataAsync();
            InitCommand();
            lvBenhNhan.ItemsSource = ListBNWaiting;
            grdPhieuKhamBenh.Visibility = Visibility.Collapsed;
        }

        private void UcCTPKB_Finish(object sender, EventArgs e)
        {
            DTO_BenhNhan bn = sender as DTO_BenhNhan;
            ListBNWaiting.Remove(bn);
            if (WaitingPatientRemoved != null)
                WaitingPatientRemoved(bn, new EventArgs());
            lvDSPKB.ItemsSource = null;
            grdPhieuKhamBenh.Visibility = Visibility.Collapsed;
            dpkNgayKham.SelectedDate = DateTime.Now;
        }

        #region Property
        public DTO_NhanVien CurrentNV { get; set; }
        public ObservableCollection<DTO_BenhNhan> ListBNWaiting { get; set; }
        public CollectionView ViewPKB { get; set; }
        public ObservableCollection<DTO_PKDaKhoa> ListPKB { get; set; }
        #endregion
        #region Command
        public ICommand TaoPhieuKhamCommand { get; set; }
        #endregion
        #region
        public event EventHandler WaitingPatientRemoved;
        #endregion
        private async Task InitDataAsync()
        {
            ListBNWaiting = new ObservableCollection<DTO_BenhNhan>();
            foreach (DTO_BenhNhan bn in BUSManager.PKDaKhoaBUS.GetListBNByDate(DateTime.Now.Date))
            {
                BUSManager.BenhNhanBUS.LoadNP_DSPKDK(bn);
                DTO_PKDaKhoa pKDaKhoa = bn.DS_PKDaKhoa.Last();
                BUSManager.PKDaKhoaBUS.LoadNPDonThuoc(pKDaKhoa);
                if (pKDaKhoa.DonThuoc == null)
                    ListBNWaiting.Add(bn);
            };
            lvBenhNhan.ItemsSource = ListBNWaiting;
            
        }

        public void setUCDSKCK(ucDanhSachKhamChuyenKhoa uc)
        {
            ucCTPKB.setUCDSKCK(uc);
        }

        public void InitCommand()
        {
            TaoPhieuKhamCommand = new RelayCommand<Window>((p) =>
            {
                if (lvBenhNhan.SelectedIndex == -1)
                    return false;
                return true;
            }, (p) =>
            {
                grdPhieuKhamBenh.Visibility = Visibility.Visible;
                ucCTPKB.GetBenhNhan(lvBenhNhan.SelectedItem as DTO_BenhNhan);
                ucCTPKB.phieuKhamBenh = ListPKB.Last();
                ucCTPKB.CurrentNV = this.CurrentNV;
            });
        }

        private void dpkNgayKham_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
                if (dpkNgayKham.SelectedDate.HasValue)
                {
                    var curDate = (sender as DatePicker).SelectedDate.Value;
                    ListPKB = BUSManager.PKDaKhoaBUS.GetListPKBByDate(curDate);
                foreach (DTO_PKDaKhoa item in ListPKB)
                    BUSManager.PKDaKhoaBUS.LoadNPBenhNhan(item);
                lvDSPKB.ItemsSource = ListPKB;
                }
        }

        private void lvDSPKB_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var item = ((FrameworkElement)e.OriginalSource).DataContext as DTO_PKDaKhoa;
            if (item != null)
            {
                grdPhieuKhamBenh.Visibility = Visibility.Visible;
                ucCTPKB.GetPKB(item);
            }
        }
        public void UpdateWaitingList(object bn)
        {
            lvBenhNhan.ItemsSource = ListBNWaiting;
            var bNhan = bn as DTO_BenhNhan;
            ListBNWaiting.Add(bNhan);
        }
        private void RemoveWaitingPatient(object sender, RoutedEventArgs e)
        {
            if (MsgBox.Show1("Bạn có chắc muốn xoá bệnh nhân khỏi danh sách chờ?", MessageType.Info, MessageButtons.YesNo))
            {
                Button b = sender as Button;
                DTO_BenhNhan item = b.CommandParameter as DTO_BenhNhan;
                ListBNWaiting.Remove(item);
                if (WaitingPatientRemoved != null)
                    WaitingPatientRemoved(item, new EventArgs());
            }            
        }

        private void lvBenhNhan_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lvBenhNhan.SelectedItem != null)
            {
                var bn = lvBenhNhan.SelectedItem as DTO_BenhNhan;
                BUSManager.BenhNhanBUS.LoadNP_DSPKDK(bn);
                ListPKB = new ObservableCollection<DTO_PKDaKhoa>(bn.DS_PKDaKhoa);
                lvDSPKB.ItemsSource = ListPKB;
            }
        }
    }
}
