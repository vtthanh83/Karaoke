using System;
using System.Collections.Generic;
using System.Text;

namespace BKIT.Entities
{
    public class HoaDonNhap
    {
        private int _IDHoaDonNhap;
        public int IDHoaDonNhap
        {
            get { return _IDHoaDonNhap; }
            set { _IDHoaDonNhap = value; }
        }
        private DateTime _Ngay;
        public DateTime Ngay
        {
            get { return _Ngay; }
            set { _Ngay = value; }
        }
        private string _Ghichu;
        public string Ghichu
        {
            get { return _Ghichu; }
            set { _Ghichu = value; }
        }
        private int _IDNhanvien;
        public int IDNhanvien
        {
            get { return _IDNhanvien; }
            set { _IDNhanvien = value; }
        }
    }
}
