
using System;
using System.Collections.Generic;
using System.Text;
using BKIT.Entities;

namespace BKIT.Model.IDataService
{
    interface ISPPhaChe
    {
        int insertSPPhaChe(SPPhaChe objSPPhaChe);
        bool updateSPPhaChe(SPPhaChe objSPPhaChe);
        bool deleteSPPhaChe(SPPhaChe objSPPhaChe);
        System.Data.DataSet getAllSPPhaChe();
        System.Data.DataSet getAllSPPhaCheByIDSanPham(int IDSanPham); 
        System.Data.DataSet getSLSPDaDungByIDSanPham(int IDSanPham);
    }
}
