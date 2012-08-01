using System;
using System.Collections.Generic;
using System.Text;

namespace BKIT.Entities
{
    public class GiaXuatSP
    {
        private int _IDGiaXuatSP;
        public int IDGiaXuatSP
        {
            get { return _IDGiaXuatSP; }
            set { _IDGiaXuatSP = value; }
        }
        private decimal _Gia;
        public decimal Gia
        {
            get { return _Gia; }
            set { _Gia = value; }
        }
        private DateTime _NgayXuatSP;
        public DateTime NgayXuatSP
        {
            get { return _NgayXuatSP; }
            set { _NgayXuatSP = value; }
        }
        private int _IDSanPham;
        public int IDSanPham
        {
            get { return _IDSanPham; }
            set { _IDSanPham = value; }
        }
        private string _Ghichu;
        public string Ghichu
        {
            get { return _Ghichu; }
            set { _Ghichu = value; }
        }
    }
}
