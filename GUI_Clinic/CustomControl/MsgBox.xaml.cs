using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GUI_Clinic.CustomControl
{
    /// <summary>
    /// Interaction logic for MsgBox.xaml
    /// </summary>
    public partial class MsgBox : Window
    {
        private static MsgBox msgBox;
        public static void Show(string message, MessageType type, MessageButtons buttons)
        {
            msgBox = new MsgBox(message, type, buttons);
            msgBox.ShowDialog();
        }
        public static bool Show1(string message, MessageType type, MessageButtons buttons)
        {
            msgBox = new MsgBox(message, type, buttons);
            var rel = msgBox.ShowDialog();
            if (rel.HasValue)
                return rel.Value;
            return false;
        }
        public static void Show(string message, MessageType type)
        {
            MessageButtons buttons = MessageButtons.Ok;
            msgBox = new MsgBox(message, type, buttons);
            msgBox.ShowDialog();
        }
        public static void Show(string message)
        {
            MessageType type = MessageType.Info;
            MessageButtons buttons = MessageButtons.Ok;
            msgBox = new MsgBox(message, type, buttons);
            msgBox.ShowDialog();
        }
        public MsgBox(string Message, MessageType Type, MessageButtons Buttons)
        {
            InitializeComponent();
            txtMessage.Text = Message;
            switch (Type)
            {

                case MessageType.Info:
                    txtTitle.Text = "Thông báo";
                    icon.Kind = MaterialDesignThemes.Wpf.PackIconKind.Information;
                    icon.Foreground = new SolidColorBrush(Color.FromRgb(0, 120, 215));
                    break;
                case MessageType.Warning:
                    txtTitle.Text = "Cảnh báo";
                    icon.Kind = MaterialDesignThemes.Wpf.PackIconKind.Warning;
                    icon.Foreground = new SolidColorBrush(Colors.Yellow);
                    break;
                case MessageType.Error:
                    txtTitle.Text = "Lỗi";
                    icon.Kind = MaterialDesignThemes.Wpf.PackIconKind.Error;
                    icon.Foreground = new SolidColorBrush(Colors.Red);
                    break;
            }
            switch (Buttons)
            {
                case MessageButtons.OkCancel:
                    btnYes.Visibility = Visibility.Collapsed; btnNo.Visibility = Visibility.Collapsed;
                    break;
                case MessageButtons.YesNo:
                    btnOk.Visibility = Visibility.Collapsed; btnCancel.Visibility = Visibility.Collapsed;
                    break;
                case MessageButtons.Ok:
                    btnOk.Visibility = Visibility.Visible;
                    btnCancel.Visibility = Visibility.Collapsed;
                    btnYes.Visibility = Visibility.Collapsed; btnNo.Visibility = Visibility.Collapsed;
                    break;
            }
        }

        private void btnYes_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }

        private void btnNo_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        private void cardHeader_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            FrameworkElement window = GetWindowParent(cardHeader);
            var w = window as Window;
            if (w != null)
            {
                w.DragMove();
            }
        }
        private FrameworkElement GetWindowParent(Grid p)
        {
            FrameworkElement parent = p;

            while (parent.Parent != null)
            {
                parent = parent.Parent as FrameworkElement;
            }

            return parent;
        }
    }    
    public enum MessageType
    {
        Info,
        Warning,
        Error,
    }
    public enum MessageButtons
    {
        OkCancel,
        YesNo,
        Ok,
    }
}
