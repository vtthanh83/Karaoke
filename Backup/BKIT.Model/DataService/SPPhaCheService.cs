
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
    public class SPPhaCheService : ISPPhaChe
    {
        public int insertSPPhaChe(BKIT.Entities.SPPhaChe objSPPhaChe)
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "INSERT INTO SPPhaChe(IDSPPhaChe,IDSanPham,IDSPCha,ThanhPhan,Ghichu) " +
                "VALUES (@IDSPPhaChe,@IDSanPham,@IDSPCha,@ThanhPhan,@Ghichu)";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            try
            {
                int ID = GetNextAVailableID();
                objSPPhaChe.IDSPPhaChe = ID;
                db.AddInParameter(dbCommand, "IDSPPhaChe", DbType.Int32, objSPPhaChe.IDSPPhaChe);
                db.AddInParameter(dbCommand, "IDSanPham", DbType.Int32, objSPPhaChe.IDSanPham);
                db.AddInParameter(dbCommand, "IDSPCha", DbType.Int32, objSPPhaChe.IDSPCha);
                db.AddInParameter(dbCommand, "ThanhPhan", DbType.Decimal, objSPPhaChe.ThanhPhan);
                db.AddInParameter(dbCommand, "Ghichu", DbType.String, objSPPhaChe.GhiChu);
                
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
        public bool updateSPPhaChe(BKIT.Entities.SPPhaChe objSPPhaChe)
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "UPDATE SPPhaChe SET IDSanPham = @IDSanPham, IDSPCha = @IDSPCha, ThanhPhan = @ThanhPhan, Ghichu = @Ghichu " +
                    "WHERE IDSPPhaChe = @IDSPPhaChe";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            try
            {
                
                db.AddInParameter(dbCommand, "IDSanPham", DbType.Int32, objSPPhaChe.IDSanPham);
                db.AddInParameter(dbCommand, "IDSPCha", DbType.Int32, objSPPhaChe.IDSPCha);
                db.AddInParameter(dbCommand, "ThanhPhan", DbType.Decimal, objSPPhaChe.ThanhPhan);
                db.AddInParameter(dbCommand, "Ghichu", DbType.String, objSPPhaChe.GhiChu);
                db.AddInParameter(dbCommand, "IDSPPhaChe", DbType.Int32, objSPPhaChe.IDSPPhaChe);
                db.ExecuteNonQuery(dbCommand);
                dbCommand.Connection.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool deleteSPPhaChe(BKIT.Entities.SPPhaChe objSPPhaChe)
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "DELETE FROM SPPhaChe WHERE IDSPPhaChe = @idSPPhaChe";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            try
            {
                db.AddInParameter(dbCommand, "idSPPhaChe", DbType.Int32, objSPPhaChe.IDSPPhaChe);
                db.ExecuteNonQuery(dbCommand);
                dbCommand.Connection.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public System.Data.DataSet getAllSPPhaChe()
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "SELECT SPPhaChe.*, 1 as [DeleteSPPhaChe] " +
                                "FROM SPPhaChe ";
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
        public System.Data.DataSet getAllSPPhaCheByIDSanPham(int IDSanPham)
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "SELECT SPPhaChe.*,SanPham.TenSanPham, 1 as [DeleteCTPhaChe] " +
                                "FROM SPPhaChe,SanPham WHERE SPPhaChe.IDSanPham = " + IDSanPham.ToString() + " "  
                                + " AND SPPhaChe.IDSPCha = SanPham.IDSanPham";
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
        public System.Data.DataSet getSLSPDaDungByIDSanPham(int IDSanPham)
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "SELECT SUM(ThanhPhan)/100 " +
                                "FROM SPPhaChe WHERE SPPhaChe.IDSPCha = " + IDSanPham.ToString();
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
            string sqlCommand = "SELECT IDSPPhaChe FROM SPPhaChe ORDER BY IDSPPhaChe";
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
