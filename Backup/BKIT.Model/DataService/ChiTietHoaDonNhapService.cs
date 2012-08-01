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
    public class ChiTietHoaDonNhapService : IChiTietHoaDonNhap
    {
        public int insertChiTietHoaDonNhap(BKIT.Entities.ChiTietHoaDonNhap objChiTietHoaDonNhap)
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "INSERT INTO ChiTietHoaDonNhap(IDChiTietHoaDonNhap,IDHoaDonNhap,IDSanPham,SoLuong,GiaNhap) " +
                "VALUES (@idchitiethoadonnhap,@idhoadonnhap,@idsanpham,@soluong,@gianhap)";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            try
            {
                int ID = GetNextAVailableID();
                objChiTietHoaDonNhap.IDChiTietHoaDonNhap = ID;
                db.AddInParameter(dbCommand, "idchitiethoadonnhap", DbType.Int32, objChiTietHoaDonNhap.IDChiTietHoaDonNhap);
                db.AddInParameter(dbCommand, "idhoadonnhap", DbType.Int32, objChiTietHoaDonNhap.IDHoaDonNhap);
                db.AddInParameter(dbCommand, "idsanpham", DbType.Int32, objChiTietHoaDonNhap.IDSanPham);
                db.AddInParameter(dbCommand, "soluong", DbType.Int32, objChiTietHoaDonNhap.SoLuong);
                db.AddInParameter(dbCommand, "gianhap", DbType.Decimal, objChiTietHoaDonNhap.GiaNhap);
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
        public bool updateChiTietHoaDonNhap(BKIT.Entities.ChiTietHoaDonNhap objChiTietHoaDonNhap)
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "UPDATE ChiTietHoaDonNhap SET IDHoaDonNhap = @idhoadonnhap, IDSanPham = @idsanpham, SoLuong = @soluong, GiaNhap = @gianhap " +
                    "WHERE IDChiTietHoaDonNhap = @idchitiethoadonnhap";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            try
            {
                db.AddInParameter(dbCommand, "idhoadonnhap", DbType.Int32, objChiTietHoaDonNhap.IDHoaDonNhap);
                db.AddInParameter(dbCommand, "idsanpham", DbType.Int32, objChiTietHoaDonNhap.IDSanPham);
                db.AddInParameter(dbCommand, "soluong", DbType.Int32, objChiTietHoaDonNhap.SoLuong);
                db.AddInParameter(dbCommand, "gianhap", DbType.Decimal, objChiTietHoaDonNhap.GiaNhap);
                db.AddInParameter(dbCommand, "idchitiethoadonnhap", DbType.Int32, objChiTietHoaDonNhap.IDChiTietHoaDonNhap);
                db.ExecuteNonQuery(dbCommand);
                dbCommand.Connection.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool deleteChiTietHoaDonNhap(BKIT.Entities.ChiTietHoaDonNhap objChiTietHoaDonNhap)
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "DELETE FROM ChiTietHoaDonNhap WHERE IDChiTietHoaDonNhap = @idchitiethoadonnhap";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            try
            {
                db.AddInParameter(dbCommand, "idchitiethoadonnhap", DbType.Int32, objChiTietHoaDonNhap.IDChiTietHoaDonNhap);
                db.ExecuteNonQuery(dbCommand);
                dbCommand.Connection.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public System.Data.DataSet getAllChiTietHoaDonNhap()
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "SELECT ChiTietHoaDonNhap.IDChiTietHoaDonNhap, ChiTietHoaDonNhap.IDHoaDonNhap, ChiTietHoaDonNhap.IDSanPham, ChiTietHoaDonNhap.SoLuong, ChiTietHoaDonNhap.GiaNhap, SanPham.TenSanPham, [SoLuong]*[GiaNhap] AS TongTien " +
                                "FROM (HoaDonNhap INNER JOIN ChiTietHoaDonNhap ON HoaDonNhap.IDHoaDonNhap = ChiTietHoaDonNhap.IDHoaDonNhap) INNER JOIN SanPham ON ChiTietHoaDonNhap.IDSanPham = SanPham.IDSanPham ";
                                

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
        public System.Data.DataSet getAllChiTietHoaDonNhapByIDHoaDonNhap(int IDHoaDonNhap)
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "SELECT ChiTietHoaDonNhap.IDChiTietHoaDonNhap, ChiTietHoaDonNhap.IDHoaDonNhap, ChiTietHoaDonNhap.IDSanPham, ChiTietHoaDonNhap.SoLuong, ChiTietHoaDonNhap.GiaNhap, SanPham.TenSanPham, [SoLuong]*[GiaNhap] AS TongTien " +
                                "FROM (HoaDonNhap INNER JOIN ChiTietHoaDonNhap ON HoaDonNhap.IDHoaDonNhap = ChiTietHoaDonNhap.IDHoaDonNhap) INNER JOIN SanPham ON ChiTietHoaDonNhap.IDSanPham = SanPham.IDSanPham " +
                                "WHERE ChiTietHoaDonNhap.IDHoaDonNhap = @idHoaDonNhap";

            try
            {
                DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
                db.AddInParameter(dbCommand, "idHoaDonNhap", DbType.Int32, IDHoaDonNhap);
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
            string sqlCommand = "SELECT IDChiTietHoaDonNhap FROM ChiTietHoaDonNhap ORDER BY IDChiTietHoaDonNhap";
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
