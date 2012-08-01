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
    public class HoadonxuatService : IHoadonxuat
    {
        public int insertHoadonxuat(BKIT.Entities.Hoadonxuat objHoadonxuat)
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "INSERT INTO Hoadonxuat(IDHoadonXuat,TenHoadon,Ngayxuat,IDNhanvien,IDNhanvienXuatHD,IDPhong,GioBD,GioKT,Tratruoc,Phuthu,Thue,Giam,Ghichu,IDGiaLoaiphong,Trangthai, Tanggio, IDKhachhang, Nhacnho, Suco) " +
            "VALUES (@idhoadonxuat,@tenhoadon,@ngayxuat,@idnhanvien,@idnhanvienxuathd,@idphong,@giobd,@giokt,@tratruoc,@phuthu,@thue,@giam,@ghichu,@idgialoaiphong,@trangthai,@tanggio,@idkhachhang,@nhacnho,@suco);";
            //string sqlCommand = "INSERT INTO Hoadonxuat(IDHoadonXuat,Ngayxuat,IDNhanvien,IDPhong,GioBD,Phuthu,Thue,Giam,Ghichu,IDGiaLoaiphong) " +
            //    "VALUES (@idhoadonxuat,@ngayxuat,@idnhanvien,@idphong,@giobd,@phuthu,@thue,@giam,@ghichu,@idgialoaiphong)";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            try
            {
                int ID = GetNextAVailableID();
                objHoadonxuat.IDHoadonXuat = ID;
                db.AddInParameter(dbCommand, "idhoadonxuat", DbType.Int32, objHoadonxuat.IDHoadonXuat);
                db.AddInParameter(dbCommand, "tenhoadon", DbType.String, objHoadonxuat.TenHoadon);
                db.AddInParameter(dbCommand, "ngayxuat", DbType.DateTime, objHoadonxuat.Ngayxuat);
                db.AddInParameter(dbCommand, "idnhanvien", DbType.Int32, objHoadonxuat.IDNhanvien);
                db.AddInParameter(dbCommand, "idnhanvienxuathd", DbType.Int32, objHoadonxuat.IDNhanvienXuatHD);
                db.AddInParameter(dbCommand, "idphong", DbType.Int32, objHoadonxuat.IDPhong);
                db.AddInParameter(dbCommand, "giobd", DbType.DateTime, new DateTime(objHoadonxuat.GioBD.Year,objHoadonxuat.GioBD.Month,
                    objHoadonxuat.GioBD.Day,objHoadonxuat.GioBD.Hour,objHoadonxuat.GioBD.Minute,objHoadonxuat.GioBD.Second));
                db.AddInParameter(dbCommand, "giokt", DbType.DateTime, new DateTime(objHoadonxuat.GioKT.Year, objHoadonxuat.GioKT.Month,
                    objHoadonxuat.GioKT.Day, objHoadonxuat.GioKT.Hour, objHoadonxuat.GioKT.Minute, objHoadonxuat.GioKT.Second));
                db.AddInParameter(dbCommand, "tratruoc", DbType.Int32, objHoadonxuat.Tratruoc);
                db.AddInParameter(dbCommand, "phuthu", DbType.Int32, objHoadonxuat.Phuthu);
                db.AddInParameter(dbCommand, "thue", DbType.Int32, objHoadonxuat.Thue);
                db.AddInParameter(dbCommand, "giam", DbType.Int32, objHoadonxuat.Giam);
                db.AddInParameter(dbCommand, "ghichu", DbType.String, objHoadonxuat.Ghichu);
                db.AddInParameter(dbCommand, "idgialoaiphong", DbType.Int32, objHoadonxuat.IDGiaLoaiphong);
                db.AddInParameter(dbCommand, "trangthai", DbType.Int32, objHoadonxuat.Trangthai);
                db.AddInParameter(dbCommand, "tanggio", DbType.Int32, objHoadonxuat.Tanggio);
                db.AddInParameter(dbCommand, "idkhachhang", DbType.Int32, objHoadonxuat.IDKhachhang);
                db.AddInParameter(dbCommand, "nhacnho", DbType.Boolean, objHoadonxuat.Nhacnho);
                db.AddInParameter(dbCommand, "suco", DbType.Int32, objHoadonxuat.Suco);

                
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
        public bool updateHoadonxuat(BKIT.Entities.Hoadonxuat objHoadonxuat)
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "UPDATE Hoadonxuat SET TenHoadon = @tenhoadon, Ngayxuat = @ngayxuat, IDNhanvien = @idnhanvien,IDNhanvienXuatHD = @idnhanvienxuathd, IDPhong = @idphong, GioBD = @giobd, GioKT = @giokt, Tratruoc = @tratruoc, Phuthu = @phuthu, Thue = @thue, Giam = @giam, Ghichu = @ghichu, IDGiaLoaiphong = @idgialoaiphong, Trangthai = @trangthai, Tanggio = @tanggio, IDKhachhang = @idkhachhang, Nhacnho = @nhacnho, Suco = @suco  " +
                "WHERE IDHoadonXuat = @idhoadonxuat";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            try
            {
                db.AddInParameter(dbCommand, "tenhoadon", DbType.String, objHoadonxuat.TenHoadon);
                db.AddInParameter(dbCommand, "ngayxuat", DbType.DateTime, objHoadonxuat.Ngayxuat);
                db.AddInParameter(dbCommand, "idnhanvien", DbType.Int32, objHoadonxuat.IDNhanvien);
                db.AddInParameter(dbCommand, "idnhanvienxuathd", DbType.Int32, objHoadonxuat.IDNhanvienXuatHD);
                db.AddInParameter(dbCommand, "idphong", DbType.Int32, objHoadonxuat.IDPhong);
                db.AddInParameter(dbCommand, "giobd", DbType.DateTime, new DateTime(objHoadonxuat.GioBD.Year, objHoadonxuat.GioBD.Month,
                    objHoadonxuat.GioBD.Day, objHoadonxuat.GioBD.Hour, objHoadonxuat.GioBD.Minute, objHoadonxuat.GioBD.Second));
                db.AddInParameter(dbCommand, "giokt", DbType.DateTime, new DateTime(objHoadonxuat.GioKT.Year, objHoadonxuat.GioKT.Month,
                    objHoadonxuat.GioKT.Day, objHoadonxuat.GioKT.Hour, objHoadonxuat.GioKT.Minute, objHoadonxuat.GioKT.Second));
                db.AddInParameter(dbCommand, "tratruoc", DbType.Int32, objHoadonxuat.Tratruoc);
                db.AddInParameter(dbCommand, "phuthu", DbType.Int32, objHoadonxuat.Phuthu);
                db.AddInParameter(dbCommand, "thue", DbType.Int32, objHoadonxuat.Thue);
                db.AddInParameter(dbCommand, "giam", DbType.Int32, objHoadonxuat.Giam);
                db.AddInParameter(dbCommand, "ghichu", DbType.String, objHoadonxuat.Ghichu);
                
                db.AddInParameter(dbCommand, "idgialoaiphong", DbType.Int32, objHoadonxuat.IDGiaLoaiphong);
                db.AddInParameter(dbCommand, "trangthai", DbType.Int32, objHoadonxuat.Trangthai);
                db.AddInParameter(dbCommand, "tanggio", DbType.Int32, objHoadonxuat.Tanggio);
                db.AddInParameter(dbCommand, "idkhachhang", DbType.Int32, objHoadonxuat.IDKhachhang);
                db.AddInParameter(dbCommand, "nhacnho", DbType.Boolean, objHoadonxuat.Nhacnho);
                db.AddInParameter(dbCommand, "suco", DbType.Int32, objHoadonxuat.Suco);
                db.AddInParameter(dbCommand, "idhoadonxuat", DbType.Int32, objHoadonxuat.IDHoadonXuat);
                db.ExecuteNonQuery(dbCommand);
                dbCommand.Connection.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool deleteHoadonxuat(BKIT.Entities.Hoadonxuat objHoadonxuat)
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "DELETE FROM Hoadonxuat WHERE IDHoadonXuat = @idhoadonxuat";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            try
            {
                db.AddInParameter(dbCommand, "idhoadonxuat", DbType.Int32, objHoadonxuat.IDHoadonXuat);
                db.ExecuteNonQuery(dbCommand);
                dbCommand.Connection.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public System.Data.DataSet getAllHoadonxuat()
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "SELECT * FROM Hoadonxuat";
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
        public System.Data.DataSet getAllHoadonxuatSanpham()
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "SELECT IDHoadonXuat, Ngayxuat, IDNhanvien, GioBD, GioKT, Tratruoc, Phuthu, Thue, IIf([Trangthai]=0,'Mở','Đóng') AS Tinhtrang, IDKhachhang, Suco, 1 AS [DeleteHDXuat] FROM Hoadonxuat WHERE IDPhong<0";
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
        public System.Data.DataSet getAllHoadonxuatPhong()
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "SELECT * FROM Hoadonxuat WHERE IDPhong>=0";
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
        public System.Data.DataSet getLastHoadonxuatByIDPhong(int ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "SELECT * FROM Hoadonxuat WHERE IDPhong = @id "+
                "ORDER BY Ngayxuat AND GioBD DESC";
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
        public System.Data.DataSet getLastHoadonxuatByIDPhongAndDate(int ID, DateTime Date)
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "SELECT * FROM Hoadonxuat WHERE IDPhong = @id AND Ngayxuat = @date " +
                "ORDER BY Ngayxuat AND GioBD DESC";
            try
            {
                DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
                db.AddInParameter(dbCommand, "id", DbType.Int32, ID);
                db.AddInParameter(dbCommand, "date", DbType.DateTime, Date);
                DataSet ds = db.ExecuteDataSet(dbCommand);
                dbCommand.Connection.Close();
                return ds;
            }
            catch
            {
                return null;
            }
        }
        public System.Data.DataSet getHoadonxuatByIDHoadonXuat(int ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "SELECT * FROM Hoadonxuat WHERE IDHoadonXuat = @id ";
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
        public System.Data.DataSet getAllOpenningHoadonxuatWithDeposit()
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "SELECT * FROM Hoadonxuat WHERE Trangthai = 0 AND Nhacnho = true";
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

        public System.Data.DataSet getAllNotClosedHDXOfProductID(int ProductID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "SELECT SUM(Soluong) FROM Hoadonxuat,ChitietHDXuat WHERE TrangThai = 0 "+
                                " AND Hoadonxuat.IDHoadonxuat = ChitietHDXuat.IDHoadonxuat " +
                                " AND IDPhong <> -1 " +
                                " AND IDSanpham = " + ProductID.ToString() + " ";
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
        public System.Data.DataSet getSoLuongSPBanRa()
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "SELECT SUM(Soluong) FROM Hoadonxuat,ChitietHDXuat WHERE IDPhong = -1 " +
                                " AND Hoadonxuat.IDHoadonxuat = ChitietHDXuat.IDHoadonxuat ";                               
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
            string sqlCommand = "SELECT IDHoadonXuat FROM Hoadonxuat ORDER BY IDHoadonXuat";
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
