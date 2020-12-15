using BUS_Clinic.BUS;
using DTO_Clinic;
using DTO_Clinic.Form;
using DTO_Clinic.Person;
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
    /// Interaction logic for ucDanhSachPhieuKhamChuyenKhoa.xaml
    /// </summary>
    public partial class ucDanhSachPhieuKhamChuyenKhoa : UserControl
    {
        public ucDanhSachPhieuKhamChuyenKhoa()
        {
            InitializeComponent();
            this.DataContext = this;
            ucCTPKCK.Finish += UcCTPKCK_Finish;
            InitData();
            InitCommand();
            grdPhieuKhamBenh.Visibility = Visibility.Collapsed;
        }

        #region Event
        private void UcCTPKCK_Finish(object sender, EventArgs e)
        {
            DTO_PKChuyenKhoa pkck = sender as DTO_PKChuyenKhoa;
            BUSManager.PKChuyenKhoaBUS.LoadNPPKDaKhoa(pkck);
            SavingPKCK?.Invoke(pkck.PhieuKhamDaKhoa, new EventArgs());
            ListPKCKPending.Remove(pkck);
            if (WaitingPatientRemoved != null)
                WaitingPatientRemoved(pkck, new EventArgs());
            lvDSPKB.ItemsSource = null;
            grdPhieuKhamBenh.Visibility = Visibility.Collapsed;
            dpkNgayKham.SelectedDate = DateTime.Now;
        }
        #endregion
        #region Property
        public ObservableCollection<DTO_PKChuyenKhoa> ListPKCK { get; set; }
        public ObservableCollection<DTO_PKChuyenKhoa> ListPKCKPending { get; set; }
        public CollectionView ViewPKB { get; set; }
        public DTO_NhanVien CurrentNV { get; set; }
        #endregion
        #region Command
        public ICommand TaoPhieuKhamCommand { get; set; }
        #endregion
        #region
        public event EventHandler WaitingPatientRemoved;
        public event EventHandler SavingPKCK;
        #endregion
        public void InitData()
        {
            ListPKCK = new ObservableCollection<DTO_PKChuyenKhoa>();
            ListPKCKPending = new ObservableCollection<DTO_PKChuyenKhoa>();
            foreach(DTO_PKChuyenKhoa item in BUSManager.PKChuyenKhoaBUS.GetListPKCKByDate(DateTime.Now))
            {
                if (item.KetQua == "")
                {
                    BUSManager.PKChuyenKhoaBUS.LoadNPPKDaKhoa(item);
                    BUSManager.PKDaKhoaBUS.LoadNPBenhNhan(item.PhieuKhamDaKhoa);
                    ListPKCKPending.Add(item);
                }
            }
            lvDSPKB.ItemsSource = ListPKCK;
            lvBenhNhan.ItemsSource = ListPKCKPending;
            ViewPKB = (CollectionView)CollectionViewSource.GetDefaultView(ListPKCK);
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
                DTO_PKChuyenKhoa pKChuyenKhoa = lvBenhNhan.SelectedItem as DTO_PKChuyenKhoa;
                BUSManager.PKChuyenKhoaBUS.LoadNPPKDaKhoa(pKChuyenKhoa);
                BUSManager.PKDaKhoaBUS.LoadNPBenhNhan(pKChuyenKhoa.PhieuKhamDaKhoa);
                ucCTPKCK.CurrentNV = this.CurrentNV;
                ucCTPKCK.GetNewPKCK(pKChuyenKhoa);
            });
        }

        private void dpkNgayKham_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dpkNgayKham.SelectedDate.HasValue)
            {
                var curDate = (sender as DatePicker).SelectedDate.Value;
                ListPKCK = BUSManager.PKChuyenKhoaBUS.GetListPKCKByDate(curDate);
                foreach (DTO_PKChuyenKhoa item in ListPKCK)
                {
                    BUSManager.PKChuyenKhoaBUS.LoadNPPKDaKhoa(item);
                    BUSManager.PKDaKhoaBUS.LoadNPBenhNhan(item.PhieuKhamDaKhoa);
                }
                lvDSPKB.ItemsSource = ListPKCK;
            }
        }

        private void lvDSPKB_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            grdPhieuKhamBenh.Visibility = Visibility.Visible;
            var item = ((FrameworkElement)e.OriginalSource).DataContext as DTO_PKChuyenKhoa;
            if (item != null)
            {
                ucCTPKCK.GetPKCK(item);
            }
        }
        public void UpdateWaitingList(object pkChuyenKhoa)
        {
            var pkck = pkChuyenKhoa as DTO_PKChuyenKhoa;
            ListPKCKPending.Add(pkck);
            lvBenhNhan.ItemsSource = ListPKCKPending;
        }
        private void RemoveWaitingPatient(object sender, RoutedEventArgs e)
        {
            if (MsgBox.Show1("Bạn có chắc muốn xoá bệnh nhân khỏi danh sách chờ?", MessageType.Info, MessageButtons.YesNo))
            {
                Button b = sender as Button;
                DTO_PKChuyenKhoa item = b.CommandParameter as DTO_PKChuyenKhoa;
                ListPKCKPending.Remove(item);
                if (WaitingPatientRemoved != null)
                    WaitingPatientRemoved(item, new EventArgs());
            }
        }
    }
}
