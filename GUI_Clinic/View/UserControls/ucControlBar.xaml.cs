using DTO_Clinic.Person;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Interaction logic for ucControlBar.xaml
    /// </summary>
    public partial class ucControlBar : UserControl
    {
        public DTO_NhanVien currentNV;
        public ucControlBar()
        {
            InitializeComponent();
            this.DataContext = this;
            if (currentNV == null)
            {
                grdInfo.Visibility = Visibility.Collapsed;
            }
            
        }

        public void SetProfileInfo(DTO_NhanVien nv)
        {
            if (nv != null)
            {
                tblTenNhanVien.Text = nv.HoTen;
                switch (nv.ChucVu)
                {
                    case 0:
                        tblChucVu.Text = "Admin";
                        break;
                    case 1:
                        tblChucVu.Text = "Bác sĩ đa khoa";
                        break;
                    case 2:
                        tblChucVu.Text = "Bác sĩ chuyên khoa";
                        break;
                    case 3:
                        tblChucVu.Text = "Dược sĩ";
                        break;
                    case 4:
                        tblChucVu.Text = "Nhân viên thủ tục";
                        break;
                    default:
                        break;
                }
                currentNV = nv;
            }
            if (currentNV == null)
            {
                grdInfo.Visibility = Visibility.Collapsed;
            }
            else
            {
                grdInfo.Visibility = Visibility.Visible;
            }
        }

        private void btnShutdown_Click(object sender, RoutedEventArgs e)
        {
            FrameworkElement window = GetWindowParent(this);
            var w = window as Window;
            if (w != null)
            {
                w.Close();
            }
        }

        private void btnMaximize_Click(object sender, RoutedEventArgs e)
        {
            FrameworkElement window = GetWindowParent(this);
            var w = window as Window;
            if (w != null)
            {
                if (w.WindowState == WindowState.Maximized)
                {
                    w.WindowState = WindowState.Normal;
                }
                else
                {
                    w.WindowState = WindowState.Maximized;
                }

            }
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            FrameworkElement window = GetWindowParent(this);
            var w = window as Window;
            if (w != null)
            {
                w.WindowState = WindowState.Minimized;
            }
        }

        private void UserControl_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            FrameworkElement window = GetWindowParent(this);
            var w = window as Window;
            if (w != null)
            {
                w.DragMove();
            }
        }

        FrameworkElement GetWindowParent(UserControl p)
        {
            FrameworkElement parent = p;

            while (parent.Parent != null)
            {
                parent = parent.Parent as FrameworkElement;
            }

            return parent;
        }

        public event PropertyChangedEventHandler PropertyChanged;

    }
}
