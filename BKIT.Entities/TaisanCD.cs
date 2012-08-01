using System;
using System.Collections.Generic;
using System.Text;

namespace BKIT.Entities
{
    public class TaisanCD
    {
        private int _IDTaiSanCD;
        public int IDTaiSanCD
        {
            get { return _IDTaiSanCD; }
            set { _IDTaiSanCD = value; }
        }
        private int _IDLoaiTaiSan;
        public int IDLoaiTaiSan
        {
            get { return _IDLoaiTaiSan; }
            set { _IDLoaiTaiSan = value; }
        }
        private string _TenTaiSan;
        public string TenTaiSan
        {
            get { return _TenTaiSan; }
            set { _TenTaiSan = value; }
        }
        private DateTime _NgayNhap;
        public DateTime NgayNhap
        {
            get { return _NgayNhap; }
            set { _NgayNhap = value; }
        }
        private string _XuatSu;
        public string XuatSu
        {
            get { return _XuatSu; }
            set { _XuatSu = value; }
        }
        private int _HSD;
        public int HSD
        {
            get { return _HSD; }
            set { _HSD = value; }
        }
        private int _TinhTrang;
        public int TinhTrang
        {
            get { return _TinhTrang; }
            set { _TinhTrang = value; }
        }
        private int _IDPhong;
        public int IDPhong
        {
            get { return _IDPhong; }
            set { _IDPhong = value; }
        }
        private string _GhiChu;
        public string   GhiChu
        {
            get { return _GhiChu; }
            set { _GhiChu = value; }
        }
    }
}
