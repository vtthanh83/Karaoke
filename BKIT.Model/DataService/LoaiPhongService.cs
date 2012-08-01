using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Data.Common;
using BKIT.Entities;
using BKIT.Model.IDataService;

namespace BKIT.Model
{
    public class LoaiPhongService : ILoaiPhong
    {
        public int insertLoaiPhong(BKIT.Entities.LoaiPhong objLoaiPhong)
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "INSERT INTO LoaiPhong(IDLoaiPhong,TenLoaiPhong,Ghichu) " +
                "VALUES (@idloaiphong,@tenloaiphong,@ghichu)";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            try
            {
                int ID = GetNextAVailableID();
                objLoaiPhong.IDLoaiPhong = ID;
                db.AddInParameter(dbCommand, "idloaiphong", DbType.Int32, objLoaiPhong.IDLoaiPhong);
                db.AddInParameter(dbCommand, "tenloaiphong", DbType.String, objLoaiPhong.TenLoaiPhong);
                db.AddInParameter(dbCommand, "ghichu", DbType.String, objLoaiPhong.Ghichu);
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
        public bool updateLoaiPhong(BKIT.Entities.LoaiPhong objLoaiPhong)
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "UPDATE LoaiPhong SET TenLoaiPhong = @tenloaiphong, Ghichu = @ghichu " +
                    "WHERE IDLoaiPhong = @idloaiphong";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            try
            {
                db.AddInParameter(dbCommand, "tenloaiphong", DbType.String, objLoaiPhong.TenLoaiPhong);
                db.AddInParameter(dbCommand, "ghichu", DbType.String, objLoaiPhong.Ghichu);
                db.AddInParameter(dbCommand, "idloaiphong", DbType.Int32, objLoaiPhong.IDLoaiPhong);
                db.ExecuteNonQuery(dbCommand);
                dbCommand.Connection.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool deleteLoaiPhong(BKIT.Entities.LoaiPhong objLoaiPhong)
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "DELETE FROM LoaiPhong WHERE IDLoaiPhong = @idloaiphong";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            try
            {
                db.AddInParameter(dbCommand, "idloaiphong", DbType.Int32, objLoaiPhong.IDLoaiPhong);
                db.ExecuteNonQuery(dbCommand);
                dbCommand.Connection.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public System.Data.DataSet getAllLoaiPhong()
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "SELECT IDLoaiPhong,TenLoaiPhong,Ghichu,1 as [DeleteLoaiPhong] FROM LoaiPhong";
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
        public System.Data.DataSet getLoaiPhongByIDLoaiPhong(int ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "SELECT LoaiPhong.IDLoaiPhong, LoaiPhong.TenLoaiPhong, LoaiPhong.Ghichu, 1 as [DeleteLoaiPhong] " +
                                "FROM LoaiPhong " +
                                "WHERE IDLoaiPhong = @id";

            try
            {
                DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
                db.AddInParameter(dbCommand, "id", DbType.Int32, ID);
                DataSet ds = db.ExecuteDataSet(dbCommand);
                dbCommand.Connection.Close();
                return ds;
            }
            catch
            {
                return null;
            }
        }
        public System.Data.DataSet getLoaiPhongByTenLoaiPhong(string ten)
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "SELECT LoaiPhong.IDLoaiPhong, LoaiPhong.TenLoaiPhong, LoaiPhong.Ghichu, 1 as [DeleteLoaiPhong] " +
                                "FROM LoaiPhong " +
                                "WHERE TenLoaiPhong = @ten";

            try
            {
                DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
                db.AddInParameter(dbCommand, "ten", DbType.String, ten);
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
            string sqlCommand = "SELECT IDLoaiPhong FROM LoaiPhong ORDER BY IDLoaiPhong";
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
