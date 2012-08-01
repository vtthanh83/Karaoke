using System;
using System.Collections.Generic;
using System.Text;
using BKIT.Entities;

namespace BKIT.Model.IDataService
{
    interface IPhong
    {
        int insertPhong(Phong objPhong);
        bool updatePhong(Phong objPhong);
        bool deletePhong(Phong objPhong);
        System.Data.DataSet getAllPhong();
        System.Data.DataSet getPhongByIDLoaiPhong(int ID);
        System.Data.DataSet getPhongByIDPhong(int ID);
        System.Data.DataSet getAllPhongAndLoaiPhong();
        System.Data.DataSet getAllPhongAndLoaiPhong(int diffID);
        System.Data.DataSet getAllFreePhongAndLoaiPhong(int diffID);
        System.Data.DataSet getAllBusyPhongAndLoaiPhong(int diffID);
    }
}
