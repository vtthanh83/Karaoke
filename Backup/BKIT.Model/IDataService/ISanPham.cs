using System;
using System.Collections.Generic;
using System.Text;
using BKIT.Entities;

namespace BKIT.Model.IDataService
{
    interface ISanPham
    {
        int insertSanPham(SanPham objSanPham);
        bool updateSanPham(SanPham objSanPham);
        bool deleteSanPham(SanPham objSanPham);
        System.Data.DataSet getAllSanPham();
        System.Data.DataSet getSanPhamByIDNhomSP(int ID);
        System.Data.DataSet getAllSanPhamAndIDGia();
        System.Data.DataSet getIDSanPhamByTenSP(string TenSanPham);
		System.Data.DataSet getSanPhamByTenSP(string ten);
        System.Data.DataSet getSanPhamByIDSanPham(int IDSanPham);
    }
}
