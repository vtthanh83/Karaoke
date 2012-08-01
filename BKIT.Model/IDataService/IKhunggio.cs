using System;
using System.Collections.Generic;
using System.Text;
using BKIT.Entities;

namespace BKIT.Model.IDataService
{
    interface IKhunggio
    {
        int insertKhunggio(Khunggio objKhunggio);
        bool updateKhunggio(Khunggio objKhunggio);
        bool deleteKhunggio(Khunggio objKhunggio);
        System.Data.DataSet getAllKhunggio();
    }
}
