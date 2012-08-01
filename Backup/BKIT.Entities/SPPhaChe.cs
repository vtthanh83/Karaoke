using System;
using System.Collections.Generic;
using System.Text;


namespace BKIT.Entities
{
    public class SPPhaChe
    {
        private int _IDSPPhaChe;
        public int IDSPPhaChe
        {
            get { return _IDSPPhaChe; }
            set { _IDSPPhaChe = value; }
        }
        private int _IDSanPham;
        public int IDSanPham
        {
            get { return _IDSanPham; }
            set { _IDSanPham = value; }
        }
        private int _IDSPCha;
        public int IDSPCha
        {
            get { return _IDSPCha; }
            set { _IDSPCha = value; }
        }
        private int _ThanhPhan;
        public int ThanhPhan
        {
            get { return _ThanhPhan; }
            set { _ThanhPhan = value; }
        }
        private string _GhiChu;
        public string   GhiChu
        {
            get { return _GhiChu; }
            set { _GhiChu = value; }
        }
    }
}
