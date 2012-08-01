using System;
using System.Collections.Generic;
using System.Text;
using BKIT.Entities;

namespace BKIT.Model.DataService
{
    interface IGiaXuatSP
    {
        int insertGiaXuatSP(GiaXuatSP objGiaXuatSP);
        bool updateGiaXuatSP(GiaXuatSP objGiaXuatSP);
        bool deleteGiaXuatSP(GiaXuatSP objGiaXuatSP);
        System.Data.DataSet getAllGiaXuatSP();
        System.Data.DataSet getGiaXuatSPByIDSanPham(int ID);
    }
}
