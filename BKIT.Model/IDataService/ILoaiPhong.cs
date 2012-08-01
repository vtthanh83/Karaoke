using System;
using System.Collections.Generic;
using System.Text;
using BKIT.Entities;

namespace BKIT.Model.IDataService
{
    interface ILoaiPhong
    {
        int insertLoaiPhong(LoaiPhong objLoaiPhong);
        bool updateLoaiPhong(LoaiPhong objLoaiPhong);
        bool deleteLoaiPhong(LoaiPhong objLoaiPhong);
        System.Data.DataSet getAllLoaiPhong();
        System.Data.DataSet getLoaiPhongByTenLoaiPhong(string ten);
       // System.Data.DataSet getLoaiPhongByIDLoaiPhong(int ID);
    }
}
