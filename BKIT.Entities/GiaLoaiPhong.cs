using System;
using System.Collections.Generic;
using System.Text;

namespace BKIT.Entities
{
    public class GiaLoaiPhong
    {
        private int _IDGiaLoaiPhong;
        public int IDGiaLoaiPhong
        {
            get { return _IDGiaLoaiPhong; }
            set { _IDGiaLoaiPhong = value; }
        }
        private decimal _Gia;
        public decimal Gia
        {
            get { return _Gia; }
            set { _Gia = value; }
        }
        private int _IDLoaiPhong;
        public int IDLoaiPhong
        {
            get { return _IDLoaiPhong; }
            set { _IDLoaiPhong = value; }
        }
        private int _IDKhunggio;
        public int IDKhunggio
        {
            get { return _IDKhunggio; }
            set { _IDKhunggio = value; }
        }
        private DateTime _Ngay;
        public DateTime Ngay
        {
            get { return _Ngay; }
            set { _Ngay = value; }
        }
    }
}
