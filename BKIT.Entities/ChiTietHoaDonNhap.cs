using System;
using System.Collections.Generic;
using System.Text;

namespace BKIT.Entities
{
    public class ChiTietHoaDonNhap
    {
        private int _IDChiTietHoaDonNhap;
        public int IDChiTietHoaDonNhap
        {
            get { return _IDChiTietHoaDonNhap; }
            set { _IDChiTietHoaDonNhap = value; }
        }
        private int _IDHoaDonNhap;
        public int IDHoaDonNhap
        {
            get { return _IDHoaDonNhap; }
            set { _IDHoaDonNhap = value; }
        }
        private int _IDSanPham;
        public int IDSanPham
        {
            get { return _IDSanPham; }
            set { _IDSanPham = value; }
        }
        private int _SoLuong;
        public int SoLuong
        {
            get { return _SoLuong; }
            set { _SoLuong = value; }
        }
        private decimal _GiaNhap;
        public decimal GiaNhap
        {
            get { return _GiaNhap; }
            set { _GiaNhap = value; }
        }
    }
}
