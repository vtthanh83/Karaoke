using System;
using System.Collections.Generic;
using System.Text;

namespace BKIT.Entities
{
    public class TonKho
    {
        private int _IDTonKho;

        public int IDTonKho
        {
            get { return _IDTonKho; }
            set { _IDTonKho = value; }
        }
        private DateTime _Ngay;

        public DateTime Ngay
        {
            get { return _Ngay; }
            set { _Ngay = value; }
        }
        

        private int _IDSanPham;

        public int IDSanPham
        {
            get { return _IDSanPham; }
            set { _IDSanPham = value; }
        }
        private int _IDHoaDonNhap;

        public int IDHoaDonNhap
        {
            get { return _IDHoaDonNhap; }
            set { _IDHoaDonNhap = value; }
        }
        private int _IDHoaDonXuat;

        public int IDHoaDonXuat
        {
            get { return _IDHoaDonXuat; }
            set { _IDHoaDonXuat = value; }
        }
        private string _DanhMuc;

        public string DanhMuc
        {
            get { return _DanhMuc; }
            set { _DanhMuc = value; }
        }
        private int _SoLuong;

        public int SoLuong
        {
            get { return _SoLuong; }
            set { _SoLuong = value; }
        }
    }
}
