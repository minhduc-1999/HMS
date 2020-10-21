using System;
using System.Collections.Generic;
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
    /// Interaction logic for ucControlBar.xaml
    /// </summary>
    public partial class ucControlBar : UserControl
    {
        public ucControlBar()
        {
            InitializeComponent();
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
    }
}
