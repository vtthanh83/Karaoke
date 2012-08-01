
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
    public class LoaiVDService : ILoaiVD
    {
        public int insertLoaiVD(BKIT.Entities.LoaiVD objLoaiVD)
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "INSERT INTO LoaiVD(IDLoaiVD,TenVD,Ghichu) " +
                "VALUES (@IDLoaiVD,@TenVD,@Ghichu)";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            try
            {
                int ID = GetNextAVailableID();
                objLoaiVD.IDLoaiVD = ID;
                db.AddInParameter(dbCommand, "IDLoaiVD", DbType.Int32, objLoaiVD.IDLoaiVD);
                db.AddInParameter(dbCommand, "TenVD", DbType.String, objLoaiVD.TenVD);                
                db.AddInParameter(dbCommand, "Ghichu", DbType.String, objLoaiVD.GhiChu);

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
        public bool updateLoaiVD(BKIT.Entities.LoaiVD objLoaiVD)
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "UPDATE LoaiVD SET TenVD = @TenVD, Ghichu = @Ghichu " +
                    "WHERE IDLoaiVD = @IDLoaiVD";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            try
            {                
                db.AddInParameter(dbCommand, "TenVD", DbType.String, objLoaiVD.TenVD);
                db.AddInParameter(dbCommand, "Ghichu", DbType.String, objLoaiVD.GhiChu);
                db.AddInParameter(dbCommand, "IDLoaiVD", DbType.Int32, objLoaiVD.IDLoaiVD);
                db.ExecuteNonQuery(dbCommand);
                dbCommand.Connection.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool deleteLoaiVD(BKIT.Entities.LoaiVD objLoaiVD)
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "DELETE FROM LoaiVD WHERE IDLoaiVD = @idLoaiVD";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            try
            {
                db.AddInParameter(dbCommand, "idLoaiVD", DbType.Int32, objLoaiVD.IDLoaiVD);
                db.ExecuteNonQuery(dbCommand);
                dbCommand.Connection.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public System.Data.DataSet getAllLoaiVD()
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "SELECT LoaiVD.*, 1 as [DeleteLoaiVD] " +
                                "FROM LoaiVD ";
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
        public System.Data.DataSet getAllLoaiVDByIDLoaiVD(int IDLoaiVD)
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "SELECT LoaiVD.*, 1 as [DeleteLoaiVD] " +
                                "FROM LoaiVD WHERE LoaiVD.IDLoaiVD = " + IDLoaiVD.ToString() + " ";

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
        public int getIDLoaiVDByTenLoaiVD(string TenLoaiVD)
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "SELECT IDLoaiVD " +
                "FROM LoaiVD where TenVD='" + TenLoaiVD + "';";
            try
            {
                DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
                DataSet ds = db.ExecuteDataSet(dbCommand);
                dbCommand.Connection.Close();
                return Convert.ToInt32(ds.Tables[0].Rows[0]["IDLoaiVD"]);
            }
            catch
            {
                return -1;
            }
        }
        #region Helpers
        internal int GetNextAVailableID()
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "SELECT IDLoaiVD FROM LoaiVD ORDER BY IDLoaiVD";
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
