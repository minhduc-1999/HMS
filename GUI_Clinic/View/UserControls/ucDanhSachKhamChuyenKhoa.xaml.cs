using BUS_Clinic.BUS;
using DTO_Clinic.Person;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace GUI_Clinic.View.UserControls
{
    /// <summary>
    /// Interaction logic for ucDanhSachKhamChuyenKhoa.xaml
    /// </summary>
    public partial class ucDanhSachKhamChuyenKhoa : UserControl
    {
        public ObservableCollection<DTO_BenhNhan> ListBN1 { get; set; }
        public ObservableCollection<DTO_BenhNhan> ListBN2 { get; set; }
        public DTO_BenhNhan selectedBN { get; set; }

        public ucDanhSachKhamChuyenKhoa()
        {
            InitializeComponent();
            this.DataContext = this;

            InitDataAsync();
        }

        private async Task InitDataAsync()
        {
            ListBN1 = await BUSManager.BenhNhanBUS.GetListBNAsync();
            ListBN2 = await BUSManager.BenhNhanBUS.GetListBNAsync();

            lvDanhSachDuocYeuCauKhamCK.ItemsSource = ListBN1;
            lvDanhSachDaDKKhamCK.ItemsSource = ListBN2;

            tblSoBN.Text = ListBN1.Count.ToString();
            tblSoBNDaDK.Text = ListBN2.Count.ToString();

            UpdateSelectedBN(null);
        }

        private void lvDanhSachDuocYeuCauKhamCK_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lvDanhSachDuocYeuCauKhamCK.SelectedIndex != -1)
            {
                lvDanhSachDaDKKhamCK.SelectedIndex = -1;
                UpdateSelectedBN(lvDanhSachDuocYeuCauKhamCK.SelectedItem as DTO_BenhNhan);
                tblTrangThai.Text = "Chưa đăng ký";
                grdBtnDKKham.Visibility = System.Windows.Visibility.Visible;
            }
        }

        private void lvDanhSachDaDKKhamCK_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lvDanhSachDaDKKhamCK.SelectedIndex != -1)
            {
                lvDanhSachDuocYeuCauKhamCK.SelectedIndex = -1;
                UpdateSelectedBN(lvDanhSachDaDKKhamCK.SelectedItem as DTO_BenhNhan);
                tblTrangThai.Text = "Đã đăng ký";
                grdBtnDKKham.Visibility = System.Windows.Visibility.Collapsed;
            }
        }

        private void UpdateSelectedBN(DTO_BenhNhan bn)
        {
            selectedBN = bn;
            if (selectedBN != null)
            {
                grdBNInfo.Visibility = System.Windows.Visibility.Visible;
                tblMaBN.Text = selectedBN.MaBenhNhan;
                tblHoTen.Text = selectedBN.HoTen;
                tblNgaySinh.Text = selectedBN.NgaySinh.ToShortDateString();
                tblGioiTinh.Text = (selectedBN.GioiTinh) ? "Nữ" : "Nam" ;
                tblDiaChi.Text = selectedBN.DiaChi;
                tblSDT.Text = selectedBN.SoDienThoai;
                tblCMND.Text = selectedBN.SoCMND;
                //Yeucau
            }
            else
            {
                grdBNInfo.Visibility = System.Windows.Visibility.Collapsed;
            }
        }
    }
}
