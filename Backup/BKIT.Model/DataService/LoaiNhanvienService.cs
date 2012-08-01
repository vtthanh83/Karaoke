using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
using BKIT.Model.IDataService;

namespace BKIT.Model.DataService
{
    public class LoaiNhanvienService : ILoaiNhanvien
    {
        public int insertLoaiNhanvien(BKIT.Entities.LoaiNhanvien objLoaiNhanvien)
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "INSERT INTO LoaiNhanvien(IDLoaiNhanvien,TenLoaiNV) " +
                "VALUES (@idloainhanvien,@tenloainv)";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            try
            {
                int ID = GetNextAVailableID();
                objLoaiNhanvien.IDLoaiNhanvien = ID;
                db.AddInParameter(dbCommand, "idloainhanvien", DbType.Int32, objLoaiNhanvien.IDLoaiNhanvien);
                db.AddInParameter(dbCommand, "tenloainv", DbType.String, objLoaiNhanvien.TenLoaiNV);
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
        public bool updateLoaiNhanvien(BKIT.Entities.LoaiNhanvien objLoaiNhanvien)
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "UPDATE LoaiNhanvien SET TenLoaiNV = @tenloainv " +
                    "WHERE IDLoaiNhanvien = @idloainhanvien";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            try
            {
                db.AddInParameter(dbCommand, "tenloainv", DbType.String, objLoaiNhanvien.TenLoaiNV);
                db.AddInParameter(dbCommand, "idloainhanvien", DbType.Int32, objLoaiNhanvien.IDLoaiNhanvien);
                db.ExecuteNonQuery(dbCommand);
                dbCommand.Connection.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool deleteLoaiNhanvien(BKIT.Entities.LoaiNhanvien objLoaiNhanvien)
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "DELETE FROM LoaiNhanvien WHERE IDLoaiNhanvien = @idloainhanvien";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            try
            {
                db.AddInParameter(dbCommand, "idloainhanvien", DbType.Int32, objLoaiNhanvien.IDLoaiNhanvien);
                db.ExecuteNonQuery(dbCommand);
                dbCommand.Connection.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public System.Data.DataSet getAllLoaiNhanvien()
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "SELECT * FROM LoaiNhanvien";
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
        #region Helpers
        internal int GetNextAVailableID()
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "SELECT IDLoaiNhanvien FROM LoaiNhanvien ORDER BY IDLoaiNhanvien";
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
