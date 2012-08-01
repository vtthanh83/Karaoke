using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Data.Common;
using BKIT.Entities;
using BKIT.Model.IDataService;

namespace BKIT.Model.DataService
{
    public class SettingService : ISetting
    {
        public int insertSetting(BKIT.Entities.Setting objSetting)
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "INSERT INTO Setting(IDSetting,Ngay,TenCT,Phone,Mobile,Diachi,Email,Khuyenmai,Loichao1,Loichao2,TGKetthuc,MayInBep,MayInKho,MayInHoadon) " +
                "VALUES (@idsetting,@ngay,@tenct,@phone,@mobile,@diachi,@email,@khuyenmai,@loichao1,@loichao2,@tgketthuc,@may1,@may2,@may3)";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            try
            {
                int ID = GetNextAVailableID();
                objSetting.IDSetting = ID;
                db.AddInParameter(dbCommand, "idsetting", DbType.Int32, objSetting.IDSetting);
                db.AddInParameter(dbCommand, "ngay", DbType.DateTime, objSetting.Ngay);
                db.AddInParameter(dbCommand, "tenct", DbType.String, objSetting.TenCT);
                db.AddInParameter(dbCommand, "phone", DbType.String, objSetting.Phone);
                db.AddInParameter(dbCommand, "mobile", DbType.String, objSetting.Mobile);
                db.AddInParameter(dbCommand, "diachi", DbType.String, objSetting.Diachi);
                db.AddInParameter(dbCommand, "email", DbType.String, objSetting.Email);
                db.AddInParameter(dbCommand, "khuyenmai", DbType.String, objSetting.Khuyenmai);
                db.AddInParameter(dbCommand, "loichao1", DbType.String, objSetting.Loichao1);
                db.AddInParameter(dbCommand, "loichao2", DbType.String, objSetting.Loichao2);
                db.AddInParameter(dbCommand, "tgketthuc", DbType.Int32, objSetting.TGKetthuc);
                db.AddInParameter(dbCommand, "may1", DbType.String, objSetting.MayInBep);
                db.AddInParameter(dbCommand, "may2", DbType.String, objSetting.MayInKho);
                db.AddInParameter(dbCommand, "may3", DbType.String, objSetting.MayInHoadon);
                db.ExecuteNonQuery(dbCommand);
                dbCommand.Connection.Close();
                return ID;
            }
            catch
            {
                dbCommand.Connection.Close();
                return -1;
            }
        }
        public bool updateSetting(BKIT.Entities.Setting objSetting)
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "UPDATE Setting SET Ngay = @ngay, TenCT = @tenct, Phone = @phone, Mobile = @mobile, Diachi = @diachi, Email = @email, Khuyenmai = @khuyenmai, Loichao1 = @loichao1, Loichao2 = @loichao2, TGKetthuc = @tgketthuc, MayInBep = may1, MayInKho = may2,MayInHoadon = may3" +
                    "WHERE IDSetting = @idsetting";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            try
            {
                db.AddInParameter(dbCommand, "ngay", DbType.DateTime, objSetting.Ngay);
                db.AddInParameter(dbCommand, "tenct", DbType.String, objSetting.TenCT);
                db.AddInParameter(dbCommand, "phone", DbType.String, objSetting.Phone);
                db.AddInParameter(dbCommand, "mobile", DbType.String, objSetting.Mobile);
                db.AddInParameter(dbCommand, "diachi", DbType.String, objSetting.Diachi);
                db.AddInParameter(dbCommand, "email", DbType.String, objSetting.Email);
                db.AddInParameter(dbCommand, "khuyenmai", DbType.String, objSetting.Khuyenmai);
                db.AddInParameter(dbCommand, "loichao1", DbType.String, objSetting.Loichao1);
                db.AddInParameter(dbCommand, "loichao2", DbType.String, objSetting.Loichao2);
                db.AddInParameter(dbCommand, "tgketthuc", DbType.Int32, objSetting.TGKetthuc);
                db.AddInParameter(dbCommand, "may1", DbType.String, objSetting.MayInBep);
                db.AddInParameter(dbCommand, "may2", DbType.String, objSetting.MayInKho);
                db.AddInParameter(dbCommand, "may3", DbType.String, objSetting.MayInHoadon);
                db.AddInParameter(dbCommand, "idsetting", DbType.Int32, objSetting.IDSetting);
                db.ExecuteNonQuery(dbCommand);
                dbCommand.Connection.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool deleteSetting(BKIT.Entities.Setting objSetting)
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "DELETE FROM Setting WHERE IDSetting = @idsetting";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            try
            {
                db.AddInParameter(dbCommand, "idsetting", DbType.Int32, objSetting.IDSetting);
                db.ExecuteNonQuery(dbCommand);
                dbCommand.Connection.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public System.Data.DataSet getAllSetting()
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "SELECT * FROM Setting ORDER BY Setting.Ngay DESC";
            try
            {
                DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
                DataSet ds = db.ExecuteDataSet(dbCommand);
                dbCommand.Connection.Close();
                return ds;
            }
            catch
            {
                return null;
            }
        }
        public bool IsSetting(string dt)
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "SELECT * FROM Setting WHERE Setting.Ngay = #" + dt + "#;";
            try
            {
                DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
                DataSet ds = db.ExecuteDataSet(dbCommand);
                dbCommand.Connection.Close();
                if (ds.Tables[0].Rows.Count > 0)
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }
        public System.Data.DataSet getSettingByDate(string dt)
        {
            string sqlCommand = "";
            if (dt == "") //get record of the last ID setting (the first row)
            {
                 sqlCommand = "SELECT * FROM Setting ORDER BY Ngay DESC;";
            }
            else
            {
                 sqlCommand = "SELECT * FROM Setting WHERE Setting.Ngay = #" + dt + "#;";
            }
            try
            {
                Database db = DatabaseFactory.CreateDatabase();
                DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
                DataSet ds = db.ExecuteDataSet(dbCommand);
                dbCommand.Connection.Close();
                return ds;
            }
            catch
            {
                return null;
            }
        }
        #region Helpers
        internal int GetNextAVailableID()
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "SELECT IDSetting FROM Setting ORDER BY IDSetting";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            int result = 0;
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    if (result != (int)dataReader[0])
                    {
                        dataReader.Close();
                        dbCommand.Connection.Close();
                        return result;
                    }
                    result++;
                }
                dataReader.Close();
                dbCommand.Connection.Close();
                return result;
            }
        }
        #endregion
    }
}
