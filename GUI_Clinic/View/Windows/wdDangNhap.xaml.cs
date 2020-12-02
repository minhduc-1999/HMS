using BUS_Clinic.BUS;
using DTO_Clinic.Permission;
using DTO_Clinic.Person;
using GUI_Clinic.Command;
using GUI_Clinic.CustomControl;
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
    /// Interaction logic for wdDangNhap.xaml
    /// </summary>
    public partial class wdDangNhap : Window
    {
        public ObservableCollection<DTO_Account> ListAcc { get; set; }
        public ICommand LoginCommand { get; set; }
        public DTO_NhanVien currentUser { get; set; }

        public wdDangNhap()
        {
            InitializeComponent();
            this.DataContext = this;
            InitDataAsync();
            InitCommand();
        }

        public void InitCommand()
        {
            LoginCommand = new RelayCommand<Window>((p) =>
            {
                if (string.IsNullOrEmpty(tbxTenDangNhap.Text) ||
                    string.IsNullOrEmpty(tbxMatKhau.Password))
                    return false;
                return true;
            }, (p) =>
            {
                if (ListAcc != null)
                {
                    foreach (DTO_Account item in ListAcc)
                    {
                        if (item.Username == tbxTenDangNhap.Text
                            && item.Password == tbxMatKhau.Password)
                        {
                            BUSManager.AccountBUS.LoadNPNhanVien(item);
                            if (item.NhanVien != null)
                            {
                                currentUser = item.NhanVien;
                                InitMainWindowAsync(currentUser);
                                return;
                            }
                        }
                    }
                }
                MsgBox.Show("Tài khoản hoặc mật khẩu không hợp lệ");
            });

        }

        private async Task InitMainWindowAsync(DTO_NhanVien nhanVien)
        {
            ObservableCollection<DTO_Group>  ListNhom = await BUSManager.GroupBUS.GetListNhomAsync();
            MainWindow mainWindow = new MainWindow(nhanVien, ListNhom);
            mainWindow.Show();
            this.Close();
        }

        public async Task InitDataAsync()
        {
            ListAcc = await BUSManager.AccountBUS.GetListAccAsync();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (!string.IsNullOrEmpty(tbxTenDangNhap.Text) ||
                    !string.IsNullOrEmpty(tbxMatKhau.Password))
                {
                    if (ListAcc != null)
                    {
                        foreach (DTO_Account item in ListAcc)
                        {
                            if (item.Username == tbxTenDangNhap.Text
                                && item.Password == tbxMatKhau.Password)
                            {
                                BUSManager.AccountBUS.LoadNPNhanVien(item);
                                if (item.NhanVien != null)
                                {
                                    currentUser = item.NhanVien;
                                    InitMainWindowAsync(currentUser);
                                    return;
                                }
                            }
                        }
                    }
                    MsgBox.Show("Tài khoản hoặc mật khẩu không hợp lệ");
                }
            }
        }
    }
}
