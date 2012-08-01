
using System;
using System.Collections.Generic;
using System.Text;
using BKIT.Entities;

namespace BKIT.Model.IDataService
{
    interface IVanDe
    {
        int insertVanDe(VanDe objVanDe);
        bool updateVanDe(VanDe objVanDe);
        bool deleteVanDe(VanDe objVanDe);
        System.Data.DataSet getAllVanDe();
        System.Data.DataSet getAllVanDeByIDLoaiVD(int IDLoaiVD);
        
    }
}
