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
    public class GiaXuatSPService : IGiaXuatSP
    {
        public int insertGiaXuatSP(BKIT.Entities.GiaXuatSP objGiaXuatSP)
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "INSERT INTO GiaXuatSP(IDGiaXuatSP,Gia,NgayXuatSP,IDSanPham,Ghichu) " +
                "VALUES (@idgiaxuatsp,@gia,@ngayxuatsp,@idsanpham,@ghichu)";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            try
            {
                int ID = GetNextAVailableID();
                objGiaXuatSP.IDGiaXuatSP = ID;
                db.AddInParameter(dbCommand, "idgiaxuatsp", DbType.Int32, objGiaXuatSP.IDGiaXuatSP);
                db.AddInParameter(dbCommand, "gia", DbType.Decimal, objGiaXuatSP.Gia);
                db.AddInParameter(dbCommand, "ngayxuatsp", DbType.DateTime, objGiaXuatSP.NgayXuatSP);
                db.AddInParameter(dbCommand, "idsanpham", DbType.Int32, objGiaXuatSP.IDSanPham);
                db.AddInParameter(dbCommand, "ghichu", DbType.String, objGiaXuatSP.Ghichu);
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
        public bool updateGiaXuatSP(BKIT.Entities.GiaXuatSP objGiaXuatSP)
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "UPDATE GiaXuatSP SET Gia = @gia, NgayXuatSP = @ngayxuatsp, IDSanPham = @idsanpham, Ghichu = @ghichu " +
                    "WHERE IDGiaXuatSP = @idgiaxuatsp";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            try
            {
                db.AddInParameter(dbCommand, "gia", DbType.Decimal, objGiaXuatSP.Gia);
                db.AddInParameter(dbCommand, "ngayxuatsp", DbType.DateTime, objGiaXuatSP.NgayXuatSP);
                db.AddInParameter(dbCommand, "idsanpham", DbType.Int32, objGiaXuatSP.IDSanPham);
                db.AddInParameter(dbCommand, "ghichu", DbType.String, objGiaXuatSP.Ghichu);
                db.AddInParameter(dbCommand, "idgiaxuatsp", DbType.Int32, objGiaXuatSP.IDGiaXuatSP);
                db.ExecuteNonQuery(dbCommand);
                dbCommand.Connection.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool deleteGiaXuatSP(BKIT.Entities.GiaXuatSP objGiaXuatSP)
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "DELETE FROM GiaXuatSP WHERE IDGiaXuatSP = @idgiaxuatsp";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            try
            {
                db.AddInParameter(dbCommand, "idgiaxuatsp", DbType.Int32, objGiaXuatSP.IDGiaXuatSP);
                db.ExecuteNonQuery(dbCommand);
                dbCommand.Connection.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public System.Data.DataSet getAllGiaXuatSP()
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "SELECT * FROM GiaXuatSP";
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
        public System.Data.DataSet getGiaXuatSPByIDSanPham(int ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "SELECT GiaXuatSP.IDGiaXuatSP, GiaXuatSP.Gia, GiaXuatSP.NgayXuatSP, GiaXuatSP.IDSanPham, GiaXuatSP.Ghichu, 1 as [DeleteGiaXuatSP] " +
                                "FROM GiaXuatSP " +
                                "WHERE IDSanPham = @id ORDER BY GiaXuatSP.NgayXuatSP DESC ";

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
        #region Helpers
        internal int GetNextAVailableID()
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "SELECT IDGiaXuatSP FROM GiaXuatSP ORDER BY IDGiaXuatSP";
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
