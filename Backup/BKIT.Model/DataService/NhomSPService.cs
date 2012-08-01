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
    public class NhomSPService : INhomSP
    {
        public int insertNhomSP(BKIT.Entities.NhomSP objNhomSP)
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "INSERT INTO NhomSP(IDNhomSP,TenNhomSP,Ghichu) " +
                "VALUES (@idnhomsp,@tennhomsp,@ghichu)";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            try
            {
                int ID = GetNextAVailableID();
                objNhomSP.IDNhomSP = ID;
                db.AddInParameter(dbCommand, "idnhomsp", DbType.Int32, objNhomSP.IDNhomSP);
                db.AddInParameter(dbCommand, "tennhomsp", DbType.String, objNhomSP.TenNhomSP);
                db.AddInParameter(dbCommand, "ghichu", DbType.String, objNhomSP.Ghichu);
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
        public bool updateNhomSP(BKIT.Entities.NhomSP objNhomSP)
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "UPDATE NhomSP SET TenNhomSP = @tennhomsp, Ghichu = @ghichu " +
                    "WHERE IDNhomSP = @idnhomsp";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            try
            {
                db.AddInParameter(dbCommand, "tennhomsp", DbType.String, objNhomSP.TenNhomSP);
                db.AddInParameter(dbCommand, "ghichu", DbType.String, objNhomSP.Ghichu);
                db.AddInParameter(dbCommand, "idnhomsp", DbType.Int32, objNhomSP.IDNhomSP);
                db.ExecuteNonQuery(dbCommand);
                dbCommand.Connection.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool deleteNhomSP(BKIT.Entities.NhomSP objNhomSP)
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "DELETE FROM NhomSP WHERE IDNhomSP = @idnhomsp";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            try
            {
                db.AddInParameter(dbCommand, "idnhomsp", DbType.Int32, objNhomSP.IDNhomSP);
                db.ExecuteNonQuery(dbCommand);
                dbCommand.Connection.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public System.Data.DataSet getAllNhomSP()
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "SELECT IDNhomSP,TenNhomSP,Ghichu ,1 as [DeleteNhomSP]  FROM NhomSP ORDER BY NhomSP.IDNhomSP DESC";
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
        public System.Data.DataSet getNhomSPByTenSP(string ten)
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "SELECT *  FROM NhomSP WHERE TenNhomSP=@ten";
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
            string sqlCommand = "SELECT IDNhomSP FROM NhomSP ORDER BY IDNhomSP";
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
