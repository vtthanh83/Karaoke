using System;
using System.Collections.Generic;
using System.Text;

namespace BKIT.Entities
{
    public class SanPham
    {
        private int _IDSanPham;
        public int IDSanPham
        {
            get { return _IDSanPham; }
            set { _IDSanPham = value; }
        }
        private string _Noixuat;
        public string Noixuat
        {
            get { return _Noixuat; }
            set { _Noixuat = value; }
        }
        private string _Tukhoa;
        public string Tukhoa
        {
            get { return _Tukhoa; }
            set { _Tukhoa = value; }
        }
        private int _SLCanhbao;
        public int SLCanhbao
        {
            get { return _SLCanhbao; }
            set { _SLCanhbao = value; }
        }
        private string _TenSanPham;
        public string TenSanPham
        {
            get { return _TenSanPham; }
            set { _TenSanPham = value; }
        }
        private string _DVT;
        public string DVT
        {
            get { return _DVT; }
            set { _DVT = value; }
        }
        private int _Tonkho;
        public int TonKho
        {
            get { return _Tonkho; }
            set { _Tonkho = value; }
        }
        private string _Ghichu;
        public string Ghichu
        {
            get { return _Ghichu; }
            set { _Ghichu = value; }
        }
        private int _IDNhomSP;
        public int IDNhomSP
        {
            get { return _IDNhomSP; }
            set { _IDNhomSP = value; }
        }

        public SanPham()
        {
            IDSanPham = -1;
            TenSanPham = "";
            DVT = "";
            TonKho = 0;
            Ghichu = "";
            IDNhomSP = -1;
        }
        public SanPham(int id, string tenSP)
        {
            IDSanPham = id;
            TenSanPham = tenSP;
            DVT = "";
            TonKho = 0;
            Ghichu = "";
            IDNhomSP = -1;
        }
    }
}
