namespace DAL_Clinic.DAL
{
    public static class DALManager
    {
        private static DAL_BenhNhan _benhNhanDAL;
        private static DAL_NhanVien _nhanVienDAL;
        private static DAL_CachDung _cachDungDAL;
        private static DAL_Benh _benhDAL;
        private static DAL_Thuoc _thuocDAL;
        private static DAL_PhieuNhapThuoc _phieuNhapThuocDAL;
        private static DAL_CTPhieuNhapThuoc _cTPhieuNhapThuocDAL;
        private static DAL_BCSuDungThuoc _bcSuDungThuocDAL;
        private static DAL_BCDoanhThu _bcDoanhThuDAL;
        private static DAL_CTBaoCaoDoanhThu _cTBaoCaoDoanhThuDAL;
        private static DAL_HoaDon _hoaDonDAL;
        private static DAL_ThamSo _thamSoDAL;

        public static DAL_BenhNhan BenhNhanDAL 
        { 
            get
            {
                if (_benhNhanDAL == null)
                    _benhNhanDAL = new DAL_BenhNhan();
                return _benhNhanDAL;
            }
        }

        public static DAL_NhanVien NhanVienDAL
        {
            get
            {
                if (_nhanVienDAL == null)
                    _nhanVienDAL = new DAL_NhanVien();
            }
                return _nhanVienDAL;
        }
        public static DAL_CachDung CachDungDAL
        {
            get
            {
                if (_cachDungDAL == null)
                    _cachDungDAL = new DAL_CachDung();
                return _cachDungDAL;
            }
        }

        public static DAL_Benh BenhDAL
        {
            get
            {
                if (_benhDAL == null)
                    _benhDAL = new DAL_Benh();
                return _benhDAL;
            }
        }

        public static DAL_Thuoc ThuocDAL
        {
            get
            {
                if (_thuocDAL == null)
                    _thuocDAL = new DAL_Thuoc();
                return _thuocDAL;
            }
        }

        public static DAL_PhieuNhapThuoc PhieuNhapThuocDAL
        {
            get
            {
                if (_phieuNhapThuocDAL == null)
                    _phieuNhapThuocDAL = new DAL_PhieuNhapThuoc();
                return _phieuNhapThuocDAL;
            }
        }

        public static DAL_CTPhieuNhapThuoc CTPhieuNhapThuocDAL
        {
            get
            {
                if (_cTPhieuNhapThuocDAL == null)
                    _cTPhieuNhapThuocDAL = new DAL_CTPhieuNhapThuoc();
                return _cTPhieuNhapThuocDAL;
            }
        }
        public static DAL_BCSuDungThuoc BCSuDungThuocDAL
        {
            get
            {
                if (_bcSuDungThuocDAL == null)
                    _bcSuDungThuocDAL = new DAL_BCSuDungThuoc();
                return _bcSuDungThuocDAL;
            }
        }

        public static DAL_BCDoanhThu BCDoanhThuDAL 
        {
            get
            {
                if (_bcDoanhThuDAL == null)
                    _bcDoanhThuDAL = new DAL_BCDoanhThu();
                return _bcDoanhThuDAL;
            }
        }

        public static DAL_CTBaoCaoDoanhThu CTBaoCaoDoanhThuDAL
        {
            get
            {
                if (_cTBaoCaoDoanhThuDAL == null)
                    _cTBaoCaoDoanhThuDAL = new DAL_CTBaoCaoDoanhThu();
                return _cTBaoCaoDoanhThuDAL;
            }
        }
        public static DAL_HoaDon HoaDonDAL
        {
            get
            {
                if (_hoaDonDAL == null)
                    _hoaDonDAL = new DAL_HoaDon();
                return _hoaDonDAL;
            }
        }

        public static DAL_ThamSo ThamSoDAL 
        { 
            get
            {
                if (_thamSoDAL == null)
                    _thamSoDAL = new DAL_ThamSo();
                return _thamSoDAL;
            }
        }
    }
}
