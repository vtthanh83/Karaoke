using System;
using System.Collections.Generic;
using System.Text;
using BKIT.Entities;

namespace BKIT.Model.IDataService
{
    interface ILoaiVD
    {
        int insertLoaiVD(LoaiVD objLoaiVD);
        bool updateLoaiVD(LoaiVD objLoaiVD);
        bool deleteLoaiVD(LoaiVD objLoaiVD);
        System.Data.DataSet getAllLoaiVD();
        System.Data.DataSet getAllLoaiVDByIDLoaiVD(int IDLoaiVD);
        int getIDLoaiVDByTenLoaiVD(string TenLoaiVD);
    }
}
