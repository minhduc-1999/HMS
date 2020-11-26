using DAL_Clinic.DAL;
using DTO_Clinic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BUS_Clinic.BUS
{
    public static class BUSManager
    {
        private static BUS_BenhNhan _benhNhanBUS;
        private static BUS_NhanVien _nhanVienBUS;
        private static BUS_CachDung _cachDungBUS;
        private static BUS_Benh _benhBUS;
        private static BUS_Thuoc _thuocBUS;
        private static BUS_PhieuNhapThuoc _phieuNhapThuocBUS;
        private static BUS_CTPhieuNhapThuoc _cTPhieuNhapThuocBUS;
        private static BUS_BCSuDungThuoc _bcSuDungThuocBUS;
        private static BUS_BCDoanhThu _bcDoanhThuBUS;
        private static BUS_CTBaoCaoDoanhThu _cTBaoCaoDoanhThuBUS;
        private static BUS_HoaDon _hoaDonBUS;
        private static BUS_ThamSo _thamSoBUS;
        private static BUS_Account _accountBUS;

        public static BUS_BenhNhan BenhNhanBUS
        {
            get
            {
                if (_benhNhanBUS == null)
                    _benhNhanBUS = new BUS_BenhNhan(DALManager.BenhNhanDAL);
                return _benhNhanBUS;
            }
        }

        public static BUS_NhanVien NhanVienBUS
        {
            get
            {
                if (_nhanVienBUS == null)
                    _nhanVienBUS = new BUS_NhanVien(DALManager.NhanVienDAL);
                return _nhanVienBUS;
            }
        }
        public static BUS_CachDung CachDungBUS
        {
            get
            {
                if (_cachDungBUS == null)
                    _cachDungBUS = new BUS_CachDung();
                return _cachDungBUS;
            }
        }

        public static BUS_Benh BenhBUS
        {
            get
            {
                if (_benhBUS == null)
                    _benhBUS = new BUS_Benh();
                return _benhBUS;
            }
        }

        public static BUS_Thuoc ThuocBUS
        {
            get
            {
                if (_thuocBUS == null)
                    _thuocBUS = new BUS_Thuoc();
                return _thuocBUS;
            }
        }

        public static BUS_PhieuNhapThuoc PhieuNhapThuocBUS
        {
            get
            {
                if (_phieuNhapThuocBUS == null)
                    _phieuNhapThuocBUS = new BUS_PhieuNhapThuoc();
                return _phieuNhapThuocBUS;
            }
        }

        public static BUS_CTPhieuNhapThuoc CTPhieuNhapThuocBUS
        {
            get
            {
                if (_cTPhieuNhapThuocBUS == null)
                    _cTPhieuNhapThuocBUS = new BUS_CTPhieuNhapThuoc();
                return _cTPhieuNhapThuocBUS;
            }
        }
        public static BUS_BCSuDungThuoc BCSuDungThuocBUS
        {
            get
            {
                if (_bcSuDungThuocBUS == null)
                    _bcSuDungThuocBUS = new BUS_BCSuDungThuoc();
                return _bcSuDungThuocBUS;
            }
        }

        public static BUS_BCDoanhThu BCDoanhThuBUS
        {
            get
            {
                if (_bcDoanhThuBUS == null)
                    _bcDoanhThuBUS = new BUS_BCDoanhThu();
                return _bcDoanhThuBUS;
            }
        }

        public static BUS_CTBaoCaoDoanhThu CTBaoCaoDoanhThuBUS
        {
            get
            {
                if (_cTBaoCaoDoanhThuBUS == null)
                    _cTBaoCaoDoanhThuBUS = new BUS_CTBaoCaoDoanhThu();
                return _cTBaoCaoDoanhThuBUS;
            }
        }

        public static BUS_HoaDon HoaDonBUS
        {
            get
            {
                if (_hoaDonBUS == null)
                    _hoaDonBUS = new BUS_HoaDon();
                return _hoaDonBUS;
            }
        }

        public static BUS_ThamSo ThamSoBUS
        {
            get
            {
                if (_thamSoBUS == null)
                    _thamSoBUS = new BUS_ThamSo();
                return _thamSoBUS;
            }
        }

        public static BUS_Account AccountBUS
        {
            get
            {
                if (_accountBUS == null)
                    _accountBUS = new BUS_Account(DALManager.AccountDAL);
                return _accountBUS;
            }
        }
    }
}
