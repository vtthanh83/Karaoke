using System;
using System.Collections.Generic;
using System.Text;
using BKIT.Entities;

namespace BKIT.Model.IDataService
{
    interface ISetting
    {
        int insertSetting(Setting objSetting);
        bool updateSetting(Setting objSetting);
        bool deleteSetting(Setting objSetting);
        System.Data.DataSet getAllSetting();
        System.Data.DataSet getSettingByDate(string dt);
    }
}
