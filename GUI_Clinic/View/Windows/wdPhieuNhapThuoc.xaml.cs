using BUS_Clinic.BUS;
using DTO_Clinic;
using DTO_Clinic.Component;
using DTO_Clinic.Form;
using GUI_Clinic.Command;
using GUI_Clinic.CustomControl;
using GUI_Clinic.View.UserControls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for wdPhieuNhapThuoc.xaml
    /// </summary>
    public partial class wdPhieuNhapThuoc : Window
    {
        public wdPhieuNhapThuoc()
        {
            InitializeComponent();
            this.DataContext = this;
            InitData();
            InitCommand();
        }

        #region Property
        public int SoLuong { get; set; }
        public double DonGia { get; set; }
        //public List<int> ListSTT { get; set; }
        //public string TenThuocMoi { get; set; }
        //public string CongDungThuocMoi { get; set; }
        public DateTime NgayNhapThuoc { get; set; }
        public ObservableCollection<DTO_Thuoc> ListThuoc { get; set; }
        public ObservableCollection<DTO_DonVi> ListDonVi { get; set; }
        public ObservableCollection<DTO_Thuoc> List { get; set; }
        #endregion

        #region Command
        public ICommand ThemThuocCommand { get; set; }
        #endregion

        private void InitData()
        {
            NgayNhapThuoc = DateTime.Now;

            ListThuoc = BUSManager.ThuocBUS.GetListThuoc();
            ListDonVi = BUSManager.DonViBUS.GetListDV();

            foreach (DTO_Thuoc item in ListThuoc)
            {
                BUSManager.ThuocBUS.LoadNPDonVi(item);
            }

            //ListSTT = new List<int>();
            //lvSTT.ItemsSource = ListSTT;

            List = new ObservableCollection<DTO_Thuoc>();
            lvDanhSachThuocNhap.ItemsSource = List;

            ckbThuocMoi.IsChecked = false;
        }

        private void InitCommand()
        {
            ThemThuocCommand = new RelayCommand<Window>((p) =>
            {
                if (ckbThuocMoi.IsChecked == false)
                {
                    if (cbxTenThuoc.SelectedIndex == -1 || cbxDonVi.SelectedIndex == -1 ||
                        tbxDonGia.Text == "0" || tbxSoLuong.Text == "0" ||
                        string.IsNullOrEmpty(tbxSoLuong.Text) || string.IsNullOrEmpty(tbxDonGia.Text))
                    {
                        return false;
                    }
                    return true;
                }
                else
                {
                    if (string.IsNullOrEmpty(tbxTenThuocMoi.Text) || cbxDonVi.SelectedIndex == -1 ||
                        tbxDonGia.Text == "0" || tbxSoLuong.Text == "0" ||
                        string.IsNullOrEmpty(tbxSoLuong.Text) || string.IsNullOrEmpty(tbxDonGia.Text) ||
                        string.IsNullOrEmpty(tbxCongDungThuocMoi.Text))
                    {
                        return false;
                    }
                    return true;
                }
            }, (p) =>
            {
                if (ckbThuocMoi.IsChecked == false)
                {
                    DTO_Thuoc themThuoc = new DTO_Thuoc();

                    themThuoc.Id = (cbxTenThuoc.SelectedItem as DTO_Thuoc).Id;
                    themThuoc.TenThuoc = (cbxTenThuoc.SelectedItem as DTO_Thuoc).TenThuoc;
                    themThuoc.MaDonVi = (cbxDonVi.SelectedItem as DTO_DonVi).Id;
                    themThuoc.DonVi = BUSManager.DonViBUS.GetDonViById(themThuoc.MaDonVi);
                    themThuoc.SoLuong = SoLuong;
                    themThuoc.DonGia = DonGia;

                    if (BUSManager.ThuocBUS.CheckIfThuocDaTonTai(themThuoc))
                    {
                        List.Add(themThuoc);
                    }
                    else
                    {
                        MsgBox.Show("Thuốc bạn chọn chưa có loại đơn vị này");
                    }

                    cbxTenThuoc.SelectedIndex = -1;
                    cbxDonVi.SelectedIndex = -1;
                    tbxDonGia.Text = "0";
                    tbxSoLuong.Text = "0";
                }
                else
                {
                    DTO_Thuoc thuocMoi = new DTO_Thuoc();
                    thuocMoi.TenThuoc = tbxTenThuocMoi.Text;
                    thuocMoi.MaDonVi = (cbxDonVi.SelectedItem as DTO_DonVi).Id;
                    thuocMoi.DonVi = BUSManager.DonViBUS.GetDonViById(thuocMoi.MaDonVi);
                    thuocMoi.CongDung = tbxCongDungThuocMoi.Text;
                    thuocMoi.SoLuong = SoLuong;
                    thuocMoi.DonGia = DonGia;

                    if (!BUSManager.ThuocBUS.CheckIfThuocDaTonTai(thuocMoi))
                    {
                        List.Add(thuocMoi);
                    }
                    else
                    {
                        MsgBox.Show("Thuốc với đơn vị bạn nhập đã tồn tại trong cơ sở dữ liệu");
                    }

                    tbxTenThuocMoi.Clear();
                    cbxDonVi.SelectedIndex = -1;
                    tbxDonGia.Text = "0";
                    tbxSoLuong.Text = "0";
                    tbxCongDungThuocMoi.Clear();
                }
            });
        }

        private void btnNhapThuoc_Click(object sender, RoutedEventArgs e)
        {
            if (List.Count != 0)
            {
                DTO_PhieuNhapThuoc phieuNhapThuoc = new DTO_PhieuNhapThuoc(NgayNhapThuoc, 0);
                BUSManager.PhieuNhapThuocBUS.AddPhieuNhapThuoc(phieuNhapThuoc);
                string tempID = phieuNhapThuoc.Id;

                foreach (DTO_Thuoc item in List)
                {
                    if (!BUSManager.ThuocBUS.CheckIfThuocDaTonTai(item))
                    {
                        BUSManager.ThuocBUS.AddThuoc(item);
                    }
                    else
                    {
                        BUSManager.ThuocBUS.CapNhatThuocVuaNhap(item);
                    }    

                    DTO_CTPhieuNhapThuoc cTPhieuNhapThuoc = new DTO_CTPhieuNhapThuoc(tempID, item.Id, item.SoLuong, item.DonGia);
                    BUSManager.CTPhieuNhapThuocBUS.AddCTPhieuNhapThuoc(cTPhieuNhapThuoc);
                }

                BUSManager.PhieuNhapThuocBUS.TinhTongTien(phieuNhapThuoc);

                //BUSManager.PhieuNhapThuocBUS.SaveChange();

                this.Close();
            }
            else
            {
                MsgBox.Show("Bạn chưa nhập thuốc");
            }
        }

        private void ckbThuocMoi_Checked(object sender, RoutedEventArgs e)
        {
            cbxTenThuoc.Visibility = Visibility.Hidden;
            tbxTenThuocMoi.Visibility = Visibility.Visible;
            tbxCongDungThuocMoi.Visibility = Visibility.Visible;
        }

        private void ckbThuocMoi_Unchecked(object sender, RoutedEventArgs e)
        {
            cbxTenThuoc.Visibility = Visibility.Visible;
            tbxTenThuocMoi.Visibility = Visibility.Hidden;
            tbxCongDungThuocMoi.Visibility = Visibility.Collapsed;
        }

        private void RemoveCategory(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            DTO_Thuoc item = b.CommandParameter as DTO_Thuoc;
            List.Remove(item);
        }

        private void tbxDonGia_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
        }
        private static readonly Regex _regex = new Regex(@"([^0-9]+)|\s+", RegexOptions.Singleline); //regex that matches disallowed text
        private static bool IsTextAllowed(string text)
        {
            return !_regex.IsMatch(text);
        }
        private void tbxDonGia_Pasting(object sender, DataObjectPastingEventArgs e)
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

        
        //private void btnThemThuoc_Click(object sender, RoutedEventArgs e)
        //{
        //    DTO_Thuoc themThuoc = new DTO_Thuoc((cbxTenThuoc.SelectedItem as DTO_Thuoc).TenThuoc, (cbxDonVi.SelectedItem as DTO_DonVi).Id, DonGia, SoLuong, "");
        //    //themThuoc.Id = STTBatDau + 1;
        //    //themThuoc.TenThuoc = (cbxTenThuoc.SelectedItem as DTO_Thuoc).TenThuoc;
        //    //themThuoc.MaDonVi = (cbxDonVi.SelectedItem as DTO_DonVi).Id;
        //    //themThuoc.SoLuong = SoLuong;
        //    //themThuoc.DonGia = DonGia;

        //    List = new ObservableCollection<DTO_Thuoc>();
        //    List.Add(themThuoc);

        //    CollectionViewSource.GetDefaultView(lvDanhSachThuocNhap.ItemsSource).Refresh();
        //}
    }
}
