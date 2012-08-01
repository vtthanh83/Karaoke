
using System;
using System.Collections.Generic;
using System.Text;

using BKIT.Entities;

namespace BKIT.Model.IDataService
{
    interface IPhieuDieuChinhTonKho
    {
        int insertPhieuDieuChinhTonKho(PhieuDieuChinhTonKho objPhieuDieuChinhTonKho);
        bool updatePhieuDieuChinhTonKho(PhieuDieuChinhTonKho objPhieuDieuChinhTonKho);
        bool deletePhieuDieuChinhTonKho(PhieuDieuChinhTonKho objPhieuDieuChinhTonKho);
        System.Data.DataSet getAllPhieuDieuChinhTonKho();
        System.Data.DataSet getPhieuDieuChinhTonKhoByID(int ID);
        System.Data.DataSet getSLSPPhieuDieuChinhTonKhoByIDSanPham(int IDSanPham);  
    }
}
