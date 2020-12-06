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
            ucCTPKB.PKBAdded += UcCTPKB_PKBAdded;
            InitDataAsync();
            InitCommand();
          //  lvBenhNhan.ItemsSource = ListDonThuoc;
            //grdPhieuKhamBenh.Visibility = Visibility.Collapsed;
        }

        private void UcCTPKB_PKBAdded(object sender, EventArgs e)
        {
            //var pkb = sender as DTO_PhieuKhamBenh;
            //ListPKB.Add(pkb);
            //ListBNWaiting.Remove(BUSManager.BenhNhanBUS.GetBenhNhanById(pkb.MaBenhNhan));
        }

        #region Property
        //public ObservableCollection<DTO_PhieuKhamBenh> ListPKB { get; set; }
        public ObservableCollection<DTO_BenhNhan> ListBNWaiting { get; set; }
        public CollectionView ViewPKB { get; set; }
        public ObservableCollection<DTO_PKDaKhoa> ListDonThuoc { get; set; }
        #endregion
        #region Command
        public ICommand TaoPhieuKhamCommand { get; set; }
        #endregion
        #region
        public event EventHandler WaitingPatientRemoved;
        #endregion
        private async Task InitDataAsync()
        {
            var loadListBNWaiting = BUSManager.BenhNhanBUS.GetListBNAsync(); //load benh nhan duoc yeu cau kham chuyen khoa tu dau do
            var initDataTasks = new List<Task> { loadListBNWaiting };
            while (initDataTasks.Count > 0)
            {
                Task finishedTask = await Task.WhenAny(initDataTasks);
                if (finishedTask == loadListBNWaiting)
                {
                    ListBNWaiting = loadListBNWaiting.Result;
                    lvBenhNhan.ItemsSource = ListBNWaiting;
                }
                //else if (finishedTask == loadListThamSo)
                //{
                //    ListThamSo = loadListThamSo.Result;
                //}
                initDataTasks.Remove(finishedTask);

            }
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
            });
        }

        private bool PhieuKhamBenhFilter(Object item)
        {
            //if (!dpkNgayKham.SelectedDate.HasValue)
            //{
            //    return true;
            //}
            //else
            //{
            //    return ((item as DTO_PhieuKhamBenh).NgayKham.Date.Equals(dpkNgayKham.SelectedDate.Value.Date));
            //}
            return true;
        }
        private void dpkNgayKham_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ViewPKB == null)
            {
                return;
            }
            else
            {
                //ListPKB = new ObservableCollection<DTO_PhieuKhamBenh>(BUSManager.PhieuKhamBenhBUS.GetListPKB());
                ViewPKB.Refresh();
            }
        }

        private void lvDSPKB_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //var item = ((FrameworkElement)e.OriginalSource).DataContext as DTO_PhieuKhamBenh;
            //if (item != null)
            //{
            //    grdPhieuKhamBenh.Visibility = Visibility.Visible;
            //    ucCTPKB.GetPKB(item);
            //}
        }
        public void UpdateWaitingList(object bn)
        {
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
    }
}
