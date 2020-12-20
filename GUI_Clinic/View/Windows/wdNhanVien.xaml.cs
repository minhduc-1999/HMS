using BUS_Clinic.BUS;
using DTO_Clinic.Component;
using DTO_Clinic.Permission;
using DTO_Clinic.Person;
using GUI_Clinic.Command;
using GUI_Clinic.CustomControl;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for wdNhanVien.xaml
    /// </summary>
    public partial class wdNhanVien : Window
    {
        #region Command
        public ICommand OpenAccountInfoCommand { get; set; }
        public ICommand UpdateCommand { get; set; }
        public ICommand CancelCommand { get; set; }
        #endregion
        #region
        public DTO_NhanVien currentNV { get; set; }
        public DTO_Account currentAcc { get; set; }
        public ObservableCollection<DTO_Phong> ListPhong { get; set; }
        #endregion

        public wdNhanVien(DTO_NhanVien nv)
        {
            InitializeComponent();
            this.DataContext = this;
            currentNV = nv;
            InitDataAsync();
            InitCommand();
        }
        public wdNhanVien(DTO_Account acc, ObservableCollection<DTO_NhanVien> listNV)
        {
            InitializeComponent();
            currentNV = new DTO_NhanVien();
            currentNV.Account = acc;
            this.DataContext = this;
            InitDataAsyncForNewNV();
            InitCreateNewNVCommand(listNV);
        }

        private async Task InitDataAsyncForNewNV()
        {
            ListPhong = await BUSManager.PhongBUS.GetListPhongAsync();
            cbxPhong.ItemsSource = ListPhong;

            dpkNgaySinh.SelectedDate = DateTime.Now;
            grdAcc.Visibility = Visibility.Collapsed;
        }

        private async Task InitDataAsync()
        {
            ListPhong = await BUSManager.PhongBUS.GetListPhongAsync();
            cbxPhong.ItemsSource = ListPhong;

            foreach (DTO_Phong item in ListPhong)
            {
                if (currentNV.MaPhong == item.MaPhong)
                {
                    cbxPhong.SelectedItem = item;
                }
            }

            if (currentNV.GioiTinh == false)
            {
                cbxGioiTinh.SelectedIndex = 0;
            }
            else
            {
                cbxGioiTinh.SelectedIndex = 1;
            }

            //BUSManager.NhanVienBUS.LoadNPGroup(currentNV);
            if (currentNV.MaNhom == "NH00001")
            {
                cbxChucVu.SelectedIndex = 0;
            }
            else if (currentNV.MaNhom == "NH00002")
            {
                cbxChucVu.SelectedIndex = 1;
            }
            else if (currentNV.MaNhom == "NH00003")
            {
                cbxChucVu.SelectedIndex = 2;
            }
            else if (currentNV.MaNhom == "NH00004")
            {
                cbxChucVu.SelectedIndex = 3;
            }
            else
            {
                cbxChucVu.SelectedIndex = 4;
            }
        }

        private bool IsHasDifference()
        {
            int tempChucVuIndex;
            if (currentNV.MaNhom == "NH00001")
            {
                tempChucVuIndex = 0;
            }
            else if (currentNV.MaNhom == "NH00002")
            {
                tempChucVuIndex = 1;
            }
            else if (currentNV.MaNhom == "NH00003")
            {
                tempChucVuIndex = 2;
            }
            else if (currentNV.MaNhom == "NH00004")
            {
                tempChucVuIndex = 3;
            }
            else
            {
                tempChucVuIndex = 4;
            }

            bool rel = currentNV.HoTen == tbxHoTen.Text
                && dpkNgaySinh.SelectedDate.Value.ToString("d") == currentNV.NgaySinh.ToString("d")
                && currentNV.GioiTinh == (cbxGioiTinh.SelectedIndex == 0 ? false : true)
                && tbxEmail.Text == currentNV.Email 
                && tbxDiaChi.Text == currentNV.DiaChi
                && tbxSDT.Text == currentNV.SoDienThoai
                && tbxCMND.Text == currentNV.SoCMND
                && tempChucVuIndex == cbxChucVu.SelectedIndex
                && (cbxPhong.SelectedItem as DTO_Phong).MaPhong == currentNV.Phong.MaPhong;
            return !rel;
        }

        private void ResetInfo()
        {
            tbxHoTen.Text = currentNV.HoTen;
            dpkNgaySinh.SelectedDate = currentNV.NgaySinh;
            InitDataAsync();
            tbxEmail.Text = currentNV.Email;
            tbxDiaChi.Text = currentNV.DiaChi;
            tbxSDT.Text = currentNV.SoDienThoai;
            tbxCMND.Text = currentNV.SoCMND;
        }

        public void InitCreateNewNVCommand(ObservableCollection<DTO_NhanVien> listNV)
        {
            UpdateCommand = new RelayCommand<Window>((p) =>
            {
                if (string.IsNullOrEmpty(tbxHoTen.Text) ||
                   !dpkNgaySinh.SelectedDate.HasValue ||
                   cbxGioiTinh.SelectedIndex == -1 ||
                   string.IsNullOrEmpty(tbxEmail.Text) ||
                   string.IsNullOrEmpty(tbxDiaChi.Text) ||
                   string.IsNullOrEmpty(tbxSDT.Text) ||
                   //tbxSDT.Text.Length != tbxSDT.MaxLength ||
                   string.IsNullOrEmpty(tbxCMND.Text) ||
                   //tbxCMND.Text.Length != tbxCMND.MaxLength ||
                   cbxChucVu.SelectedIndex == -1)
                    return false;
                return true;
            }, async (p) =>
            {
                DTO_NhanVien newNV = new DTO_NhanVien()
                {
                    HoTen = tbxHoTen.Text,
                    NgaySinh = dpkNgaySinh.SelectedDate.Value,
                    GioiTinh = (cbxGioiTinh.SelectedIndex == 0 ? false : true),
                    Email = tbxEmail.Text,
                    DiaChi = tbxDiaChi.Text,
                    SoDienThoai = tbxSDT.Text,
                    SoCMND = tbxCMND.Text,
                    MaNhom = "NH0000" + (cbxChucVu.SelectedIndex + 1).ToString(),
                    //MaNhom = (cbxChucVu.SelectedItem as DTO_Group).MaNhom,
                    MaPhong = (cbxPhong.SelectedItem as DTO_Phong).MaPhong
                };
                try
                {
                    var maNV = await BUSManager.NhanVienBUS.AddNhanVienAsync(newNV);
                    newNV.MaNhanVien = maNV;
                    BUSManager.NhanVienBUS.LoadNPGroup(newNV);
                    BUSManager.NhanVienBUS.LoadNPPhong(newNV);
                    DTO_Account newAcc = new DTO_Account()
                    {
                        MaNhanVien = maNV,
                        NhanVien = newNV,
                        Username = currentNV.Account.Username,
                        Password = currentNV.Account.Password
                    };
                    BUSManager.AccountBUS.AddAccAsync(newAcc);
                    currentNV = newNV;
                    MsgBox.Show("Thêm nhân viên thành công", MessageType.Info);
                    listNV.Add(currentNV);
                    this.Close();
                }
                catch (Exception e)
                {
                    MsgBox.Show(e.Message, MessageType.Error);
                    tbxCMND.Clear();
                }
            });
            CancelCommand = new RelayCommand<Window>((p) =>
            {
                return true;
            }, (p) =>
            {
                this.Close();
            });
        }
        public void InitCommand()
        {
            OpenAccountInfoCommand = new RelayCommand<Window>((p) =>
            {
                return true;
            }, (p) =>
            {
                if (IsHasDifference())
                {
                    if (MsgBox.Show1("Các thay đổi chưa được lưu lại\nĐể tiếp tục, các thay đổi sẽ bị hủy bỏ", MessageType.Info, MessageButtons.OkCancel))
                    {
                        ResetInfo();
                        BUSManager.NhanVienBUS.LoadNPAccount(currentNV);
                        wdTaiKhoan taiKhoan = new wdTaiKhoan(currentNV.Account);
                        taiKhoan.ShowDialog();
                    }
                }
                else
                {
                    BUSManager.NhanVienBUS.LoadNPAccount(currentNV);
                    wdTaiKhoan taiKhoan = new wdTaiKhoan(currentNV.Account);
                    taiKhoan.ShowDialog();
                }
            });
            UpdateCommand = new RelayCommand<Window>((p) =>
            {
                if (string.IsNullOrEmpty(tbxHoTen.Text) ||
                   !dpkNgaySinh.SelectedDate.HasValue ||
                   cbxGioiTinh.SelectedIndex == -1 ||
                   string.IsNullOrEmpty(tbxEmail.Text) ||
                   string.IsNullOrEmpty(tbxDiaChi.Text) ||
                   string.IsNullOrEmpty(tbxSDT.Text) ||
                   tbxSDT.Text.Length != tbxSDT.MaxLength ||
                   string.IsNullOrEmpty(tbxCMND.Text) ||
                   tbxCMND.Text.Length != tbxCMND.MaxLength ||
                   cbxChucVu.SelectedIndex == -1)
                    return false;
                if (!IsHasDifference())
                    return false;
                return true;
            }, (p) =>
            {
                if (BUSManager.NhanVienBUS.UpdateInfoNV(currentNV, tbxHoTen.Text, dpkNgaySinh.SelectedDate.Value, Convert.ToBoolean(cbxGioiTinh.SelectedIndex), tbxEmail.Text, tbxDiaChi.Text, tbxSDT.Text, tbxCMND.Text, "NH0000" + (cbxChucVu.SelectedIndex + 1).ToString(), (cbxPhong.SelectedItem as DTO_Phong).MaPhong))
                {
                    MsgBox.Show("Cập nhật thay đổi thành công", MessageType.Info);
                    this.Close();
                }
                else
                {
                    MsgBox.Show("Cập nhật thay đổi không thành công", MessageType.Error);
                }
            });
            CancelCommand = new RelayCommand<Window>((p) =>
            {
                return true;
            }, (p) =>
            {
                this.Close();
            });
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void btnShutdown_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void tbxNumber_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
        }
        private static readonly Regex _regex = new Regex(@"([^0-9]+)|\s+", RegexOptions.Singleline); //regex that matches disallowed text
        private static bool IsTextAllowed(string text)
        {
            return !_regex.IsMatch(text);
        }
        private void tbxNumber_Pasting(object sender, DataObjectPastingEventArgs e)
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
