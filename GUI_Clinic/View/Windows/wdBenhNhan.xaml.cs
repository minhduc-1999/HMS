using BUS_Clinic.BUS;
using DTO_Clinic.Person;
using GUI_Clinic.Command;
using GUI_Clinic.CustomControl;
using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace GUI_Clinic.View.Windows
{
    /// <summary>
    /// Interaction logic for wdBenhNhan.xaml
    /// </summary>
    public partial class wdBenhNhan : Window
    {
        public enum Action { Add, Watch }
        private Action action;
        public wdBenhNhan()
        {
            InitializeComponent();
        }
        public wdBenhNhan(DTO_BenhNhan bn, Action action)
        {
            InitializeComponent();
            this.DataContext = this;
            BenhNhan = bn;
            this.action = action;
            InitCommand();
            InitData();
        }
        #region Command
        public ICommand UpdateCommand { get; set; }
        public ICommand AddCommand { get; set; }
        public ICommand CancelCommand { get; set; }
        #endregion
        #region
        public DTO_BenhNhan BenhNhan { get; set; }
        #endregion
        private void InitData()
        {
            if (BenhNhan != null)
                if (BenhNhan.GioiTinh)
                    cbxGioiTinh.SelectedIndex = 1;
                else
                    cbxGioiTinh.SelectedIndex = 0;
        }
        private bool IsHasDifference()
        {
            bool rel = BenhNhan.HoTen == tbxHoTen.Text && BenhNhan.GioiTinh == (cbxGioiTinh.SelectedIndex == 0 ? false : true) 
                && tbxDiaChi.Text == BenhNhan.DiaChi && tbxCMND.Text == BenhNhan.SoCMND
                && tbxSDT.Text == BenhNhan.SoDienThoai && dpkNgaySinh.SelectedDate.Value.ToString("d") == BenhNhan.NgaySinh.ToString("d");
            return !rel;
        }
        private void InitCommand()
        {
            AddCommand = new RelayCommand<Window>((p) =>
            {
                if (action != Action.Add)
                    return false;
                if (string.IsNullOrEmpty(tbxHoTen.Text) ||
                    string.IsNullOrEmpty(tbxCMND.Text) ||
                    string.IsNullOrEmpty(tbxDiaChi.Text) ||
                    string.IsNullOrEmpty(tbxSDT.Text) ||
                    cbxGioiTinh.SelectedIndex == -1 ||
                    !dpkNgaySinh.SelectedDate.HasValue ||
                    tbxSDT.Text.Length > tbxSDT.MaxLength)
                    return false;
                return true;
            }, async (p) =>
            {
                bool gt;
                if (cbxGioiTinh.SelectedIndex == 0)
                    gt = false;
                else
                    gt = true;
                DTO_BenhNhan benhNhan = new DTO_BenhNhan()
                {
                    HoTen = tbxHoTen.Text,
                    NgaySinh = dpkNgaySinh.SelectedDate.Value,
                    DiaChi = tbxDiaChi.Text,
                    SoDienThoai = tbxSDT.Text,
                    GioiTinh = gt,
                    SoCMND = tbxCMND.Text,
                    Email = tbxEmail.Text,
                };
                try
                {
                    var maBN = await BUSManager.BenhNhanBUS.AddBenhNhanAsync(benhNhan);
                    benhNhan.MaBenhNhan = maBN;
                    BenhNhan = benhNhan;
                    MsgBox.Show("Thêm bệnh nhân thành công", MessageType.Info);
                    this.Close();
                }
                catch (Exception e)
                {
                    MsgBox.Show(e.Message, MessageType.Error);
                    tbxCMND.Clear();
                }                
            });

            UpdateCommand = new RelayCommand<Window>((p) =>
                {
                    if (action != Action.Watch)
                        return false;
                    if (string.IsNullOrEmpty(tbxHoTen.Text) ||
                       string.IsNullOrEmpty(tbxDiaChi.Text) ||
                       string.IsNullOrEmpty(tbxCMND.Text) ||
                       string.IsNullOrEmpty(tbxSDT.Text) ||
                       cbxGioiTinh.SelectedIndex == -1 ||
                       !dpkNgaySinh.SelectedDate.HasValue ||
                       tbxSDT.Text.Length != tbxSDT.MaxLength)
                        return false;
                    if (!IsHasDifference())
                        return false;
                    return true;
                }, (p) =>
                {
                    if (BUSManager.BenhNhanBUS.UpdateInfoBN(BenhNhan, tbxHoTen.Text, tbxDiaChi.Text, Convert.ToBoolean(cbxGioiTinh.SelectedIndex), tbxSDT.Text, dpkNgaySinh.SelectedDate.Value))
                    {
                        MsgBox.Show("Cập nhật thay đổi thành công", MessageType.Info);
                        this.Close();
                    }
                    else
                        MsgBox.Show("Thông tin bệnh nhân này đã tồn tại", MessageType.Error);
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
        private void tbxSDT_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
        }
        private static readonly Regex _regex = new Regex(@"([^0-9]+)|\s+", RegexOptions.Singleline); //regex that matches disallowed text
        private static bool IsTextAllowed(string text)
        {
            return !_regex.IsMatch(text);
        }
        private void tbxSDT_Pasting(object sender, DataObjectPastingEventArgs e)
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
