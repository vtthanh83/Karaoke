using System;
using System.Collections.Generic;
using System.Text;


namespace BKIT.Entities
{
    public class HoaDonXuatSP
    {
        private int _IDHoaDonXuatSP;
        public int IDHoaDonXuatSP
        {
            get { return _IDHoaDonXuatSP; }
            set { _IDHoaDonXuatSP = value; }
        }
        private DateTime _NgayXuat;
        public DateTime NgayXuat
        {
            get { return _NgayXuat; }
            set { _NgayXuat = value; }
        }
        private int _IDNhanVien;
        public int IDNhanVien
        {
            get { return _IDNhanVien; }
            set { _IDNhanVien = value; }
        }
        private int _Thue;
        public int Thue
        {
            get { return _Thue; }
            set { _Thue = value; }
        }
        private string _GhiChu;
        public string GhiChu
        {
            get { return _GhiChu; }
            set { _GhiChu = value; }
        }
        private int _TrangThai;
        public int TrangThai
        {
            get { return _TrangThai; }
            set { _TrangThai = value; }
        }       
    }
}
