using System;
using System.Collections.Generic;
using System.Text;

namespace BKIT.Entities
{
    public class PhieuDieuChinhTonKho
    {
        private int _ID;
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
      
        private int _IDSanpham;
        public int IDSanpham
        {
            get { return _IDSanpham; }
            set { _IDSanpham = value; }
        }
        
        private int _SoluongDC;
        public int SoluongDC
        {
            get { return _SoluongDC; }
            set { _SoluongDC = value; }
        }

        private DateTime _NgayDieuChinh;
        public DateTime NgayDieuChinh
        {
            get { return _NgayDieuChinh; }
            set { _NgayDieuChinh = value; }
        }

        private string _GhiChu;
        public string GhiChu
        {
            get { return _GhiChu; }
            set { _GhiChu = value; }
        }
        public PhieuDieuChinhTonKho()
        {
            ID = -1;
            IDSanpham = -1;
            SoluongDC = 0;
            NgayDieuChinh = DateTime.Now.Date;
            GhiChu = "";
        }
    }
}
