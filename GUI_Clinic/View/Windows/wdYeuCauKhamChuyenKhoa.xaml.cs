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
using System.Windows.Shapes;
using DTO_Clinic.Person;
using DTO_Clinic.Form;
using DTO_Clinic.Component;
using System.Collections.ObjectModel;

namespace GUI_Clinic.View.Windows
{
    /// <summary>
    /// Interaction logic for wdYeuCauKhamChuyenKhoa.xaml
    /// </summary>
    public partial class wdYeuCauKhamChuyenKhoa : Window
    {
        #region Property
        public DTO_BenhNhan benhNhan = new DTO_BenhNhan();
        public DTO_YeuCau yeuCau;
        public ObservableCollection<DTO_YeuCau> ListBNYC { get; set; }
        #endregion
        public wdYeuCauKhamChuyenKhoa()
        {
            InitializeComponent();
        }

        private void btnGuiYeuCau_Click(object sender, RoutedEventArgs e)
        {
            yeuCau = new DTO_YeuCau(benhNhan.MaBenhNhan, benhNhan.HoTen, tbxYeuCauKhamChuyenKhoa.Text);
            this.ListBNYC.Add(yeuCau);
        }

        private void btnHuy_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
