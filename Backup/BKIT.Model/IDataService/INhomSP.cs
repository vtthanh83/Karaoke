using System;
using System.Collections.Generic;
using System.Text;
using BKIT.Entities;

namespace BKIT.Model.IDataService
{
    interface INhomSP
    {
        int insertNhomSP(NhomSP objNhomSP);
        bool updateNhomSP(NhomSP objNhomSP);
        bool deleteNhomSP(NhomSP objNhomSP);
        System.Data.DataSet getAllNhomSP();
        System.Data.DataSet getNhomSPByTenSP(string ten);
    }
}
