using System;
using System.Collections.Generic;
using System.Text;

namespace BKIT.Entities
{
    public class ChiTietPhieuDCHDXuat
    {
        private int _IDChiTieDCHDXuat;
        public int IDChiTietDCHDXuat
        {
            get { return _IDChiTieDCHDXuat; }
            set { _IDChiTieDCHDXuat = value; }
        }
        private int _IDPhieuDCHDX;
        public int IDPhieuDCHDX
        {
            get { return _IDPhieuDCHDX; }
            set { _IDPhieuDCHDX = value; }
        }
        private int _IDSanpham;
        public int IDSanpham
        {
            get { return _IDSanpham; }
            set { _IDSanpham = value; }
        }
        private int _IDGiaxuat;
        public int IDGiaxuat
        {
            get { return _IDGiaxuat; }
            set { _IDGiaxuat = value; }
        }
        private int _Soluong;
        public int Soluong
        {
            get { return _Soluong; }
            set { _Soluong = value; }
        }
        private int _Giam;
        public int Giam
        {
            get { return _Giam; }
            set { _Giam = value; }
        }     
    }
}
