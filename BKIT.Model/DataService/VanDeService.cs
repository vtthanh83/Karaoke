
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
    public class VanDeService : IVanDe
    {
        public int insertVanDe(BKIT.Entities.VanDe objVanDe)
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "INSERT INTO VanDe(IDVanDe,Ten,IDLoaiVD,Tien,UserID,Ghichu,NgayCapNhat) " +
                "VALUES (@IDVanDe,@Ten,@IDLoaiVD,@Tien,@UserID,@Ghichu,@NgayCapNhat)";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            try
            {
                int ID = GetNextAVailableID();
                objVanDe.IDVanDe = ID;
                db.AddInParameter(dbCommand, "IDVanDe", DbType.Int32, objVanDe.IDVanDe);
                db.AddInParameter(dbCommand, "Ten", DbType.String, objVanDe.Ten);
                db.AddInParameter(dbCommand, "IDLoaiVD", DbType.Int32, objVanDe.IDLoaiVD);
                db.AddInParameter(dbCommand, "Tien", DbType.Decimal, objVanDe.Tien);
                db.AddInParameter(dbCommand, "UserID", DbType.Int32, objVanDe.UserID);
                db.AddInParameter(dbCommand, "Ghichu", DbType.String, objVanDe.GhiChu);
                db.AddInParameter(dbCommand, "NgayCapNhat", DbType.DateTime, objVanDe.NgayCapNhat);

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
        public bool updateVanDe(BKIT.Entities.VanDe objVanDe)
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "UPDATE VanDe SET Ten = @Ten, IDLoaiVD = @IDLoaiVD, Tien = @Tien,UserID = @UserID, Ghichu = @Ghichu, NgayCapNhat = @NgayCapNhat " +
                    "WHERE IDVanDe = @IDVanDe";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            try
            {

                
                db.AddInParameter(dbCommand, "Ten", DbType.String, objVanDe.Ten);
                db.AddInParameter(dbCommand, "IDLoaiVD", DbType.Int32, objVanDe.IDLoaiVD);
                db.AddInParameter(dbCommand, "Tien", DbType.Decimal, objVanDe.Tien);
                db.AddInParameter(dbCommand, "UserID", DbType.Int32, objVanDe.UserID);
                db.AddInParameter(dbCommand, "Ghichu", DbType.String, objVanDe.GhiChu);
                db.AddInParameter(dbCommand, "NgayCapNhat", DbType.DateTime, objVanDe.NgayCapNhat);

                db.AddInParameter(dbCommand, "IDVanDe", DbType.Int32, objVanDe.IDVanDe);
                db.ExecuteNonQuery(dbCommand);
                dbCommand.Connection.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool deleteVanDe(BKIT.Entities.VanDe objVanDe)
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "DELETE FROM VanDe WHERE IDVanDe = @idVanDe";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            try
            {
                db.AddInParameter(dbCommand, "idVanDe", DbType.Int32, objVanDe.IDVanDe);
                db.ExecuteNonQuery(dbCommand);
                dbCommand.Connection.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public System.Data.DataSet getAllVanDe()
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "SELECT VanDe.*, 1 as [DeleteVanDe] " +
                                "FROM VanDe ";
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
        public System.Data.DataSet getAllVanDeByIDLoaiVD(int IDLoaiVD)
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "SELECT Vande.*, 1 as [DeleteVanDe] " +
                                "FROM VanDe WHERE VanDe.IDLoaiVD = " + IDLoaiVD.ToString() + " ";
                                
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
            string sqlCommand = "SELECT IDVanDe FROM VanDe ORDER BY IDVanDe";
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
