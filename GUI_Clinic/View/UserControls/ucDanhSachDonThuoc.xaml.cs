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
using System.Windows.Navigation;
using System.Windows.Shapes;
using DTO_Clinic.Component;
using DTO_Clinic.Form;
using BUS_Clinic.BUS;
using GUI_Clinic.CustomControl;
using System.Text.RegularExpressions;
using GUI_Clinic.Command;
using GUI_Clinic.View.Windows;

namespace GUI_Clinic.View.UserControls
{
    /// <summary>
    /// Interaction logic for ucDanhSachDonThuoc.xaml
    /// </summary>
    public partial class ucDanhSachDonThuoc : UserControl
    {
        public ucDanhSachDonThuoc()
        {
            InitializeComponent();
            DataContext = this;
            InitData();
            InitCommand();
        }

        #region Property
        public ObservableCollection<DTO_Thuoc> ListThuoc { get; set; }
        public ObservableCollection<DTO_CachDung> ListCD { get; set; }
        public ObservableCollection<DTO_PKDaKhoa> ListPKB { get; set; }
        public ObservableCollection<DTO_CTHDThuoc> List { get; set; }
        public DTO_PKDaKhoa phieuKhamBenh { get; set; }
        public List<string> ListDonViGroupWithThuoc { get; set; }
        public int SoLuong { get; set; }
        public double DonGia { get; set; }
        public string maNhanvien;
        public double TongTien { get; set; }
        #endregion

        #region Command
        public ICommand ThemThuocCommand { get; set; }
        public ICommand ThanhToanCommand { get; set; }
        #endregion

        private async void InitData()
        {
            //ListThuoc = BUSManager.ThuocBUS.GetListThuoc();
            ListCD = await BUSManager.CachDungBUS.GetListCDAsync();
            List = new ObservableCollection<DTO_CTHDThuoc>();
            lvDSPKB.ItemsSource = BUSManager.PKDaKhoaBUS.GetListPKBByDate(DateTime.Now); 
            cbxThuoc.ItemsSource = ListThuoc;
        }

        private void InitCommand()
        {
            ThemThuocCommand = new RelayCommand<Window>((p) =>
            {
                if (cbxThuoc.SelectedIndex == -1 || cbxDonVi.SelectedIndex == -1 || tbxSoLuong.Text == "0" ||
                    string.IsNullOrEmpty(tbxSoLuong.Text))
                {
                    return false;
                }

                return true;
            }, (p) =>
            {
                if (!BUSManager.CTHDThuocBUS.CheckIfThuocNhapTrung(List, (DTO_Thuoc)cbxThuoc.SelectedItem))
                {
                    if (BUSManager.ThuocBUS.CheckIfSoLuongThuocDu((DTO_Thuoc)cbxThuoc.SelectedItem, SoLuong))
                    {
                        DTO_CTHDThuoc thuocSuDung = new DTO_CTHDThuoc();
                        thuocSuDung.MaThuoc = (cbxThuoc.SelectedItem as DTO_Thuoc).MaThuoc;
                        thuocSuDung.Thuoc = (DTO_Thuoc)cbxThuoc.SelectedItem;
                        thuocSuDung.SoLuong = SoLuong;
                        thuocSuDung.DonGia = (cbxThuoc.SelectedItem as DTO_Thuoc).DonGia;

                        List.Add(thuocSuDung);

                        lvThuoc.ItemsSource = List;

                        cbxThuoc.SelectedIndex = -1;
                        cbxDonVi.SelectedIndex = -1;
                    }
                    else
                    {
                        MsgBox.Show("Số lượng thuốc trong kho không đủ");
                    }
                }
                else
                {
                    MsgBox.Show("Loại thuốc này đã được thêm vào đơn thuốc");

                    cbxThuoc.SelectedIndex = -1;
                    cbxDonVi.SelectedIndex = -1;
                }
                
                tbxSoLuong.Text = "0";
            });

            ThanhToanCommand = new RelayCommand<Window>((p) =>
            {
                if (List == null || List.Count == 0)
                    return false;
                return true;
            }, (p) =>
            {

                foreach (var item in List)
                {
                    if (!BUSManager.BCSuDungThuocBUS.CheckIfBCSDTTonTai(item.MaThuoc, DateTime.Now))
                    {
                        var BCSDThuoc = new DTO_BCSudungThuoc(item.MaThuoc, item.SoLuong, DateTime.Now);
                        BUSManager.BCSuDungThuocBUS.AddBCSuDungThuoc(BCSDThuoc);
                    }
                    else
                    {
                        BUSManager.BCSuDungThuocBUS.CapNhatBCSDThuoc(item.MaThuoc, DateTime.Now, item.SoLuong);
                    }
                    BUSManager.ThuocBUS.SuDungThuoc(item.MaThuoc, item.SoLuong, item.Thuoc);
                }
                wdHoaDonThuoc wDHoaDonThuoc = new wdHoaDonThuoc(List);
                wDHoaDonThuoc.ShowDialog();

            List = null;
                lvThuoc.ItemsSource = List;
                ListPKB = null;
                lvDSPKB.ItemsSource = ListPKB;
                lvCTDonThuoc.ItemsSource = null;
                dpkNgayKham.SelectedDate = null;
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
                GetDonThuoc(item);
            }
        }
        public void GetDonThuoc(DTO_PKDaKhoa pkb)
        {
            phieuKhamBenh = pkb;
            BUSManager.PKDaKhoaBUS.LoadNPDonThuoc(pkb);
            BUSManager.DonThuocBUS.LoadNP_DSCTDonThuoc(pkb.DonThuoc);
            if (pkb.DonThuoc != null)
            {
                foreach (DTO_CTDonThuoc item in pkb.DonThuoc.DS_CTDonThuoc)
                {
                    BUSManager.CTDonThuocBUS.LoadNPThuoc(item);
                    BUSManager.CTDonThuocBUS.LoadNPCachDung(item);
                }
            }
            if (pkb.DonThuoc != null)
            {
                lvCTDonThuoc.ItemsSource = pkb.DonThuoc.DS_CTDonThuoc;
            }
        }

        private void RemoveCategory(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            DTO_CTHDThuoc item = b.CommandParameter as DTO_CTHDThuoc;
            List.Remove(item);
        }

        private void tbxSoLuong_Pasting(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(typeof(String)))
            {
                String text = (String)e.DataObject.GetData(typeof(String));
                if (!IsTextAllowed(text))
                {
                    e.CancelCommand();
                }
            }
            else
            {
                e.CancelCommand();
            }
        }

        private void tbxSoLuong_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
        }

        private static readonly Regex _regex = new Regex(@"([^0-9]+)|\s+", RegexOptions.Singleline);

        private static bool IsTextAllowed(string text)
        {
            return !_regex.IsMatch(text);
        }

        private void cbxThuoc_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbxThuoc.SelectedItem != null)
            {
                ListDonViGroupWithThuoc = BUSManager.ThuocBUS.GetDonViByTenThuoc(cbxThuoc.SelectedItem.ToString());
                cbxDonVi.ItemsSource = ListDonViGroupWithThuoc;
            }
        }

        private void cbxDonVi_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (cbxThuoc.SelectedIndex == -1)
            {
                MsgBox.Show("Vui lòng chọn thuốc trước");
            }
        }
    }
}
