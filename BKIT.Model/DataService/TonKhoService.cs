using System;
using System.Collections.Generic;
using System.Text;
using BKIT.Model.IDataService;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
using BKIT.Entities;

namespace BKIT.Model.DataService
{
    public class TonKhoService:ITonKho
    {
        public int insertTonKho(TonKho objTonKho)
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "INSERT INTO TonKho(IDTonKho,IDSanPham,Ngay,SoLuong) " +
                "VALUES (@idtonkho,@idsanpham,@ngay,@soluong)";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            try
            {
                int ID = GetNextAVailableID();
                objTonKho.IDTonKho = ID;

                db.AddInParameter(dbCommand, "idtonkho", DbType.Int32, objTonKho.IDTonKho);

                db.AddInParameter(dbCommand, "idsanpham", DbType.Int32, objTonKho.IDSanPham);
                db.AddInParameter(dbCommand, "ngay", DbType.DateTime, objTonKho.Ngay);
                db.AddInParameter(dbCommand, "soluong", DbType.Int32, objTonKho.SoLuong);
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
        public DateTime getNgayTonKhoDauKi(int IDSanPham)
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "SELECT max(Ngay) as NgayTonKho FROM TonKho WHERE IDSanPham = @id";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            try
            {
                db.AddInParameter(dbCommand, "id", DbType.Int32, IDSanPham);
                DataSet ds = db.ExecuteDataSet(dbCommand);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DateTime ngaytonkho = Convert.ToDateTime(ds.Tables[0].Rows[0]["NgayTonKho"]);
                    return ngaytonkho;
                }
                else
                {
                    return new DateTime(1900,1,1);
                }
            }
            catch
            {
                dbCommand.Connection.Close();
                return new DateTime(1900, 1, 1);
            }
        }
        public int getTonKhoDauKi(int IDSanPham)
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "SELECT SoLuong FROM TonKho WHERE IDSanPham = @id AND Ngay = (Select max(Ngay) from TonKho)";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            try
            {
                db.AddInParameter(dbCommand, "id", DbType.Int32, IDSanPham);
                DataSet ds = db.ExecuteDataSet(dbCommand);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    int Soluong = Convert.ToInt32(ds.Tables[0].Rows[0]["SoLuong"]);
                    return Soluong;
                }
                else
                {
                    sqlCommand = "SELECT TonKho FROM SanPham WHERE IDSanPham = @id";
                    dbCommand = db.GetSqlStringCommand(sqlCommand);
                    db.AddInParameter(dbCommand, "id", DbType.Int32, IDSanPham);
                    DataSet ds1 = db.ExecuteDataSet(dbCommand);
                    int Soluong = Convert.ToInt32(ds1.Tables[0].Rows[0]["TonKho"]);
                    return Soluong;
                }
            }
            catch
            {
                dbCommand.Connection.Close();
                return -1;
            }
        }
        public DataSet getHoaDonNhap(int IDSanPham)
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "SELECT SoLuong, Ngay FROM TonKho WHERE IDSanPham = @id AND Ngay = (Select max(Ngay) from TonKho)";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            try
            {
                db.AddInParameter(dbCommand, "id", DbType.Int32, IDSanPham);
                DataSet ds = db.ExecuteDataSet(dbCommand);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    //get HoaDonNhap by Ngay
                    DateTime Ngay = Convert.ToDateTime(ds.Tables[0].Rows[0]["Ngay"]);
                    sqlCommand = "SELECT ChiTietHoaDonNhap.IDHoaDonNhap, ChiTietHoaDonNhap.IDSanPham, ChiTietHoaDonNhap.SoLuong, HoaDonNhap.Ngay, SanPham.TenSanPham " +
                                 "FROM SanPham INNER JOIN (HoaDonNhap INNER JOIN ChiTietHoaDonNhap ON HoaDonNhap.IDHoaDonNhap = ChiTietHoaDonNhap.IDHoaDonNhap) ON SanPham.IDSanPham = ChiTietHoaDonNhap.IDSanPham " +
                                 "WHERE HoaDonNhap.Ngay > @ngay AND ChiTietHoaDonNhap.IDSanPham = @idsanpham";
                    dbCommand = db.GetSqlStringCommand(sqlCommand);
                    db.AddInParameter(dbCommand, "ngay", DbType.DateTime, Ngay);
                    db.AddInParameter(dbCommand, "idsanpham", DbType.Int32, IDSanPham);
                    DataSet ds1 = db.ExecuteDataSet(dbCommand);
                    dbCommand.Connection.Close();
                    return ds1;
                }
                else
                {
                    //get all HoaDonNhap
                    
                    sqlCommand = "SELECT ChiTietHoaDonNhap.IDHoaDonNhap, ChiTietHoaDonNhap.IDSanPham, ChiTietHoaDonNhap.SoLuong, HoaDonNhap.Ngay, SanPham.TenSanPham " +
                                 "FROM SanPham INNER JOIN (HoaDonNhap INNER JOIN ChiTietHoaDonNhap ON HoaDonNhap.IDHoaDonNhap = ChiTietHoaDonNhap.IDHoaDonNhap) ON SanPham.IDSanPham = ChiTietHoaDonNhap.IDSanPham " +
                                 "WHERE ChiTietHoaDonNhap.IDSanPham = @idsanpham";
                    dbCommand = db.GetSqlStringCommand(sqlCommand);
                    db.AddInParameter(dbCommand, "idsanpham", DbType.Int32, IDSanPham);
                    DataSet ds1 = db.ExecuteDataSet(dbCommand);
                    dbCommand.Connection.Close();
                    return ds1;
                }
            }
            catch
            {
                dbCommand.Connection.Close();
                return null;
            }
        }
        public DataSet getHoaDonXuat(int IDSanPham)
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "SELECT SoLuong, Ngay FROM TonKho WHERE IDSanPham = @id AND Ngay = (Select max(Ngay) from TonKho)";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            try
            {
                db.AddInParameter(dbCommand, "id", DbType.Int32, IDSanPham);
                DataSet ds = db.ExecuteDataSet(dbCommand);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    //get HoaDonXuat by Ngay
                    DateTime Ngay = Convert.ToDateTime(ds.Tables[0].Rows[0]["Ngay"]);
                    sqlCommand = "SELECT Hoadonxuat.IDHoadonXuat, ChitietHDXuat.IDSanpham, Hoadonxuat.Ngayxuat, ChitietHDXuat.Soluong, SanPham.TenSanPham " +
                                 "FROM SanPham INNER JOIN (Hoadonxuat INNER JOIN ChitietHDXuat ON Hoadonxuat.IDHoadonXuat = ChitietHDXuat.IDHoadonXuat) ON SanPham.IDSanPham = ChitietHDXuat.IDSanpham " +
                                 "WHERE Hoadonxuat.Ngayxuat > @ngay AND ChitietHDXuat.IDSanPham = @idsanpham";
                    dbCommand = db.GetSqlStringCommand(sqlCommand);
                    db.AddInParameter(dbCommand, "ngay", DbType.DateTime, Ngay);
                    db.AddInParameter(dbCommand, "idsanpham", DbType.Int32, IDSanPham);
                    DataSet ds1 = db.ExecuteDataSet(dbCommand);
                    dbCommand.Connection.Close();
                    return ds1;
                }
                else
                {
                    //get all HoaDonNhap

                    sqlCommand = "SELECT Hoadonxuat.IDHoadonXuat, ChitietHDXuat.IDSanpham, Hoadonxuat.Ngayxuat, ChitietHDXuat.Soluong, SanPham.TenSanPham " +
                                 "FROM SanPham INNER JOIN (Hoadonxuat INNER JOIN ChitietHDXuat ON Hoadonxuat.IDHoadonXuat = ChitietHDXuat.IDHoadonXuat) ON SanPham.IDSanPham = ChitietHDXuat.IDSanpham " +
                                 "WHERE ChitietHDXuat.IDSanPham = @idsanpham";
                    dbCommand = db.GetSqlStringCommand(sqlCommand);
                    db.AddInParameter(dbCommand, "idsanpham", DbType.Int32, IDSanPham);
                    DataSet ds1 = db.ExecuteDataSet(dbCommand);
                    dbCommand.Connection.Close();
                    return ds1;
                }
            }
            catch
            {
                dbCommand.Connection.Close();
                return null;
            }
        }
        #region Helpers
        internal int GetNextAVailableID()
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "SELECT IDTonKho FROM TonKho ORDER BY IDTonKho";
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
