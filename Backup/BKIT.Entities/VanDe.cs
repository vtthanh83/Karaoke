using System;
using System.Collections.Generic;
using System.Text;

namespace BKIT.Entities
{
    public class VanDe
    {
        private int _IDVanDe;
        public int IDVanDe
        {
            get { return _IDVanDe; }
            set { _IDVanDe = value; }
        }
        private string _Ten;
        public string Ten
        {
            get { return _Ten; }
            set { _Ten = value; }
        }
        private int _IDLoaiVD;
        public int IDLoaiVD
        {
            get { return _IDLoaiVD; }
            set { _IDLoaiVD = value; }
        }
        private int _Tien;
        public int Tien
        {
            get { return _Tien; }
            set { _Tien = value; }
        }
        private int _UserID;
        public int UserID
        {
            get { return _UserID; }
            set { _UserID = value; }
        }
       
        private string _GhiChu;
        public string   GhiChu
        {
            get { return _GhiChu; }
            set { _GhiChu = value; }
        }

        private DateTime _NgayCapNhat;
        public DateTime NgayCapNhat
        {
            get { return _NgayCapNhat; }
            set { _NgayCapNhat = value; }
        }
    }
}
