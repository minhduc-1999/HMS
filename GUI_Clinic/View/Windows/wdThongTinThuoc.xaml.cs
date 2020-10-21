using BUS_Clinic.BUS;
using DTO_Clinic;
using GUI_Clinic.Command;
using GUI_Clinic.CustomControl;
using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Interaction logic for wdThongTinThuoc.xaml
    /// </summary>
    public partial class wdThongTinThuoc : Window
    {
        public wdThongTinThuoc()
        {
            InitializeComponent();
        }
        public wdThongTinThuoc(DTO_Thuoc thuoc)
        {
            InitializeComponent();
            this.DataContext = this;
            InitCommand();
            Thuoc = thuoc;
            InitData();
        }
        #region Command
        public ICommand UpdateCommand { get; set; }
        public ICommand CancelCommand { get; set; }
        #endregion
        #region
        public DTO_Thuoc Thuoc { get; set; }
        #endregion
        private void InitData()
        {
            BUSManager.ThuocBUS.LoadNPDonVi(Thuoc);
        }
        private bool IsHasDifference()
        {
            bool rel = Thuoc.TenThuoc == tbxTenThuoc.Text && tbxCongDung.Text == Thuoc.CongDung
                && Convert.ToDouble(tbxDonGia.Text) == Thuoc.DonGia;
            return !rel;
        }
        private void InitCommand()
        {
            UpdateCommand = new RelayCommand<Window>((p) =>
            {
                if (string.IsNullOrEmpty(tbxTenThuoc.Text) ||
                   string.IsNullOrEmpty(tbxCongDung.Text) ||
                   string.IsNullOrEmpty(tbxDonGia.Text))
                    return false;
                if (!IsHasDifference())
                    return false;
                return true;
            }, (p) =>
            {
                if (BUSManager.ThuocBUS.UpdateInfoThuoc(Thuoc, tbxTenThuoc.Text, tbxCongDung.Text, Convert.ToDouble(tbxDonGia.Text)))
                {
                    MsgBox.Show("Cập nhật thay đổi thành công", MessageType.Info);
                    this.Close();
                }
                else
                    MsgBox.Show("Tên thuốc này đã tồn tại", MessageType.Error);
            });
            CancelCommand = new RelayCommand<Window>((p) =>
            {
                return true;
            }, (p) =>
            {
                this.Close();
            });
        }
        private void btnShutdown_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        private void tbx_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
        }
        private static readonly Regex _regex = new Regex(@"([^0-9]+)|\s+", RegexOptions.Singleline); //regex that matches disallowed text
        private static bool IsTextAllowed(string text)
        {
            return !_regex.IsMatch(text);
        }
        private void tbx_Pasting(object sender, DataObjectPastingEventArgs e)
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
    }
}
