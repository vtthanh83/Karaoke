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
    public class SanPhamService : ISanPham
    {
        public int insertSanPham(BKIT.Entities.SanPham objSanPham)
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "INSERT INTO SanPham(IDSanPham,TenSanPham,DVT,Tonkho,Ghichu,IDNhomSP) " +
                "VALUES (@idsanpham,@tensanpham,@dvt,@tonkho,@ghichu,@idnhomsp)";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            try
            {
                int ID = GetNextAVailableID();
                objSanPham.IDSanPham = ID;
                db.AddInParameter(dbCommand, "idsanpham", DbType.Int32, objSanPham.IDSanPham);
                db.AddInParameter(dbCommand, "tensanpham", DbType.String, objSanPham.TenSanPham);
                db.AddInParameter(dbCommand, "dvt", DbType.String, objSanPham.DVT);
                db.AddInParameter(dbCommand, "tonkho", DbType.Int32, objSanPham.TonKho);
                db.AddInParameter(dbCommand, "ghichu", DbType.String, objSanPham.Ghichu);
                db.AddInParameter(dbCommand, "idnhomsp", DbType.Int32, objSanPham.IDNhomSP);
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
        public bool updateSanPham(BKIT.Entities.SanPham objSanPham)
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "UPDATE SanPham SET TenSanPham = @tensanpham, DVT = @dvt, Tonkho = @tonkho, Ghichu = @ghichu " +
                    "WHERE IDSanPham = @idsanpham";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            try
            {
                db.AddInParameter(dbCommand, "tensanpham", DbType.String, objSanPham.TenSanPham);
                db.AddInParameter(dbCommand, "dvt", DbType.String, objSanPham.DVT);
                db.AddInParameter(dbCommand, "tonkho", DbType.Int32, objSanPham.TonKho);
                db.AddInParameter(dbCommand, "ghichu", DbType.String, objSanPham.Ghichu);
                //db.AddInParameter(dbCommand, "idnhomsp", DbType.Int32, objSanPham.IDNhomSP);
                db.AddInParameter(dbCommand, "idsanpham", DbType.Int32, objSanPham.IDSanPham);
                db.ExecuteNonQuery(dbCommand);
                dbCommand.Connection.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool deleteSanPham(BKIT.Entities.SanPham objSanPham)
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "DELETE FROM SanPham WHERE IDSanPham = @idsanpham";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            try
            {
                db.AddInParameter(dbCommand, "idsanpham", DbType.Int32, objSanPham.IDSanPham);
                db.ExecuteNonQuery(dbCommand);
                dbCommand.Connection.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public System.Data.DataSet getAllSanPham()
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "SELECT SanPham.IDSanPham, SanPham.TenSanPham, SanPham.TonKho, SanPham.DVT, SanPham.IDNhomSP, SanPham.Ghichu, 1 as [DeleteSanPham] " +
                                "FROM SanPham ";
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
        public System.Data.DataSet getAllSanPhamAndIDGia()
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "SELECT Query4.TenSanPham AS TenSanPham, Query4.IDSanPham as IDSanPham, Query4.DVT as DVT, Query4.IDNhomSP as IDNhomSP, Query4.TenNhomSP as TenNhomSP, GiaXuatSP.IDGiaXuatSP as IDGiaXuatSP, GiaXuatSP.Gia as Gia, 1 AS AddSP " +
                                "FROM GiaXuatSP INNER JOIN (SELECT Last(GiaXuatSP.IDGiaXuatSP) AS LastOfIDGiaXuatSP, GiaXuatSP.IDSanPham, SanPham.TenSanPham, SanPham.DVT, SanPham.IDNhomSP, NhomSP.TenNhomSP " +
                                 "FROM NhomSP INNER JOIN (SanPham INNER JOIN GiaXuatSP ON SanPham.IDSanPham = GiaXuatSP.IDSanPham) ON NhomSP.IDNhomSP = SanPham.IDNhomSP " +
                                "GROUP BY GiaXuatSP.IDSanPham, SanPham.TenSanPham, SanPham.DVT, SanPham.IDNhomSP, NhomSP.TenNhomSP) AS Query4 ON GiaXuatSP.IDGiaXuatSP = Query4.LastOfIDGiaXuatSP;";

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
        public System.Data.DataSet getSanPhamByIDNhomSP(int ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "SELECT SanPham.IDSanPham, SanPham.TenSanPham, SanPham.TonKho, SanPham.DVT, SanPham.IDNhomSP, SanPham.Ghichu, 1 as [DeleteSanPham] " +
                                "FROM SanPham " +
                                "WHERE IDNhomSP = @id";
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
        public System.Data.DataSet getIDSanPhamByTenSP(string TenSanPham)
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "SELECT *" +
                                "FROM SanPham " +
                                "WHERE TenSanPham = @TenSanPham";
            try
            {
                DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
                db.AddInParameter(dbCommand, "TenSanPham", DbType.String, TenSanPham);
                DataSet ds = db.ExecuteDataSet(dbCommand);
                dbCommand.Connection.Close();
                return ds;
            }
            catch
            {
                return null;
            }
        }
		public System.Data.DataSet getSanPhamByTenSP(string ten)
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "SELECT * FROM SanPham WHERE TenSanPham = @ten";
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
        public System.Data.DataSet getSanPhamByIDSanPham(int IDSanPham)
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "SELECT * FROM SanPham WHERE IDSanPham = @id";
            try
            {
                DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
                db.AddInParameter(dbCommand, "id", DbType.Int32, IDSanPham);
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
            string sqlCommand = "SELECT IDSanPham FROM SanPham ORDER BY IDSanPham";
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
