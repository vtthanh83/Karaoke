using System;
using System.Collections.Generic;
using System.Text;

namespace BKIT.Entities
{
    public class PhieuDieuChinhHDX
    {
        private int _IDPhieuDC;
        public int IDPhieuDC
        {
            get { return _IDPhieuDC; }
            set { _IDPhieuDC = value; }
        }
        private int _IDHoaDonXuat;
        public int IDHoaDonXuat
        {
            get { return _IDHoaDonXuat; }
            set { _IDHoaDonXuat = value; }
        }
        private TimeSpan _GioPhutRoi;
        public TimeSpan GioPhutRoi
        {
            get { return _GioPhutRoi; }
            set { _GioPhutRoi = value; }
        }
        private TimeSpan _GioPhutTru;
        public TimeSpan GioPhutTru
        {
            get { return _GioPhutTru; }
            set { _GioPhutTru = value; }
        }
    }
}
