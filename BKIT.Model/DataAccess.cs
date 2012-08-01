using System;
using System.Collections.Generic;
using System.Text;
using BKIT.Entities;
using BKIT.Model.DataService;
using System.Data;

namespace BKIT.Model
{
    public class DataAccess:IDataAccess
    {

        public DataSet getDataByQuery(string query)
        {
            return new QueryService().getDataByQuery(query);
        }
        public DataSet getDataByQuery(string query, string query1, string query2)
        {
            return new QueryService().getDataByQuery(query, query1, query2);
        }
        #region NhomSP
        public int insertNhomSP(NhomSP objNhomSP)
        {
            return new NhomSPService().insertNhomSP(objNhomSP);
        }
        public System.Data.DataSet getNhomSPByTenSP(string ten)
        {
            return new NhomSPService().getNhomSPByTenSP(ten);
        }
        public bool updateNhomSP(NhomSP objNhomSP)
        {
            return new NhomSPService().updateNhomSP(objNhomSP);
        }
        public bool deleteNhomSP(NhomSP objNhomSP)
        {
            return new NhomSPService().deleteNhomSP(objNhomSP);
        }
        public System.Data.DataSet getAllNhomSP()
        {
            return new NhomSPService().getAllNhomSP();
        }
        #endregion

        #region SanPham
        public int insertSanPham(SanPham objSanPham)
        {
            return new SanPhamService().insertSanPham(objSanPham);
        }
        public System.Data.DataSet getSanPhamByTenSP(string ten)
        {
            return new SanPhamService().getSanPhamByTenSP(ten);
        }
        public bool updateSanPham(SanPham objSanPham)
        {
            return new SanPhamService().updateSanPham(objSanPham);
        }
        public bool deleteSanPham(SanPham objSanPham)
        {
            return new SanPhamService().deleteSanPham(objSanPham);
        }
        public System.Data.DataSet getAllSanPham()
        {
            return new SanPhamService().getAllSanPham();
        }
        public System.Data.DataSet getSanPhamByIDNhomSP(int ID)
        {
            return new SanPhamService().getSanPhamByIDNhomSP(ID);
        }
        public System.Data.DataSet getAllSanPhamAndIDGia()
        {
            return new SanPhamService().getAllSanPhamAndIDGia();
        }
        public System.Data.DataSet getAllSanPhamAndIDGia(string searchTenSanPhamTemplate)
        {
            return new SanPhamService().getAllSanPhamAndIDGia(searchTenSanPhamTemplate);
        }
        public System.Data.DataSet getIDSanPhamByTenSP(string TenSanPham)
        {
            return new SanPhamService().getIDSanPhamByTenSP(TenSanPham);
        }
        #endregion

        #region GiaXuatSP
        public int insertGiaXuatSP(GiaXuatSP objGiaXuatSP)
        {
            return new GiaXuatSPService().insertGiaXuatSP(objGiaXuatSP);
        }
        public bool updateGiaXuatSP(GiaXuatSP objGiaXuatSP)
        {
            return new GiaXuatSPService().updateGiaXuatSP(objGiaXuatSP);
        }
        public bool deleteGiaXuatSP(GiaXuatSP objGiaXuatSP)
        {
            return new GiaXuatSPService().deleteGiaXuatSP(objGiaXuatSP);
        }
        public System.Data.DataSet getAllGiaXuatSP()
        {
            return new GiaXuatSPService().getAllGiaXuatSP();
        }
        public System.Data.DataSet getGiaXuatSPByIDSanPham(int ID)
        {
            return new GiaXuatSPService().getGiaXuatSPByIDSanPham(ID);
        }
        #endregion

        #region LoaiPhong
        public int insertLoaiPhong(LoaiPhong objLoaiPhong)
        {
            return new LoaiPhongService().insertLoaiPhong(objLoaiPhong);
        }
        public System.Data.DataSet getLoaiPhongByTenLoaiPhong(string ten)
        {
            return new LoaiPhongService().getLoaiPhongByTenLoaiPhong(ten);
        }
        public bool updateLoaiPhong(LoaiPhong objLoaiPhong)
        {
            return new LoaiPhongService().updateLoaiPhong(objLoaiPhong);
        }
        public bool deleteLoaiPhong(LoaiPhong objLoaiPhong)
        {
            return new LoaiPhongService().deleteLoaiPhong(objLoaiPhong);
        }
        public System.Data.DataSet getAllLoaiPhong()
        {
            return new LoaiPhongService().getAllLoaiPhong();
        }
        public System.Data.DataSet getLoaiPhongByIDLoaiPhong(int ID)
        {
            return new LoaiPhongService().getLoaiPhongByIDLoaiPhong(ID);
        }
        #endregion
        
        #region Phong
        public int insertPhong(Phong objPhong)
        {
            return new PhongService().insertPhong(objPhong);
        }
        public bool updatePhong(Phong objPhong)
        {
            return new PhongService().updatePhong(objPhong);
        }
        public bool deletePhong(Phong objPhong)
        {
            return new PhongService().deletePhong(objPhong);
        }
        public System.Data.DataSet getAllPhong()
        {
            return new PhongService().getAllPhong();
        }
        public System.Data.DataSet getPhongByIDLoaiPhong(int ID)
        {
            return new PhongService().getPhongByIDLoaiPhong(ID);
        }
        public System.Data.DataSet getPhongByIDPhong(int ID)
        {
            return new PhongService().getPhongByIDPhong(ID);
        }
        public bool IsCongtacExisted(int congtac)
        {
            return new PhongService().IsCongtacExisted(congtac);
        }
        public bool IsCongtacExistedExceptIDPhong(int congtac, int exceptIDPhong)
        {
            return new PhongService().IsCongtacExistedExceptIDPhong(congtac,exceptIDPhong);
        }
        public bool IsTenPhongExistedExceptIDPhong(string TenPhong, int exceptRoomID)
        {
            return new PhongService().IsTenPhongExistedExceptIDPhong(TenPhong, exceptRoomID);
        }
        public System.Data.DataSet getAllPhongAndLoaiPhong()
        {
            return new PhongService().getAllPhongAndLoaiPhong();
        }
        public System.Data.DataSet getAllPhongAndLoaiPhong(int diffID)
        {
            return new PhongService().getAllPhongAndLoaiPhong(diffID);
        }
        public System.Data.DataSet getAllFreePhongAndLoaiPhong(int diffID)
        {
            return new PhongService().getAllFreePhongAndLoaiPhong(diffID);
        }
        public System.Data.DataSet getAllBusyPhongAndLoaiPhong(int diffID)
        {
            return new PhongService().getAllBusyPhongAndLoaiPhong(diffID);
        }
        #endregion
        
        #region GiaLoaiPhong
        public int insertGiaLoaiPhong(GiaLoaiPhong objGiaLoaiPhong)
        {
            return new GiaLoaiPhongService().insertGiaLoaiPhong(objGiaLoaiPhong);
        }
        public bool updateGiaLoaiPhong(GiaLoaiPhong objGiaLoaiPhong)
        {
            return new GiaLoaiPhongService().updateGiaLoaiPhong(objGiaLoaiPhong);
        }
        public bool deleteGiaLoaiPhong(GiaLoaiPhong objGiaLoaiPhong)
        {
            return new GiaLoaiPhongService().deleteGiaLoaiPhong(objGiaLoaiPhong);
        }
        public System.Data.DataSet getAllGiaLoaiPhong()
        {
            return new GiaLoaiPhongService().getAllGiaLoaiPhong();
        }
        public System.Data.DataSet getGiaLoaiPhongByIDGiaLoaiPhong(int ID)
        {
            return new GiaLoaiPhongService().getGiaLoaiPhongByIDGiaLoaiPhong(ID);
        }
        public System.Data.DataSet getGiaLoaiPhongByIDLoaiPhong(int ID)
        {
            return new GiaLoaiPhongService().getGiaLoaiPhongByIDLoaiPhong(ID);
        }
        public System.Data.DataSet getGiaLoaiPhongByIDLoaiPhongAndIDKhunggio(int IDLoaiphong, int IDKhunggio)
        {
            return new GiaLoaiPhongService().getGiaLoaiPhongByIDLoaiPhongAndIDKhunggio(IDLoaiphong, IDKhunggio);
        }
        #endregion
        
        #region Khunggio
        public int insertKhunggio(Khunggio objKhunggio)
        {
            return new KhunggioService().insertKhunggio(objKhunggio);
        }
        public bool updateKhunggio(Khunggio objKhunggio)
        {
            return new KhunggioService().updateKhunggio(objKhunggio);
        }
        public bool deleteKhunggio(Khunggio objKhunggio)
        {
            return new KhunggioService().deleteKhunggio(objKhunggio);
        }
        public System.Data.DataSet getAllKhunggio()
        {
            return new KhunggioService().getAllKhunggio();
        }
        public int getIDKhunggiofromTenKhunggio(string str)
        {
            return new KhunggioService().getIDKhunggiofromTenKhunggio(str);
        }
        public bool IsGiaLoaiPhongKhungGioExisted(int IDKhungGio, int IDLoaiPhong)
        {
            return new KhunggioService().IsGiaLoaiPhongKhungGioExisted(IDKhungGio, IDLoaiPhong);
        }
        #endregion

        //Global DataAccess
        #region Hoadonxuat
        public int insertHoadonxuat(Hoadonxuat objHoadonxuat)
        {
            return new HoadonxuatService().insertHoadonxuat(objHoadonxuat);
        }
        public bool updateHoadonxuat(Hoadonxuat objHoadonxuat)
        {
            return new HoadonxuatService().updateHoadonxuat(objHoadonxuat);
        }
        public bool deleteHoadonxuat(Hoadonxuat objHoadonxuat)
        {
            return new HoadonxuatService().deleteHoadonxuat(objHoadonxuat);
        }
        public System.Data.DataSet getAllHoadonxuat()
        {
            return new HoadonxuatService().getAllHoadonxuat();
        }
        public System.Data.DataSet getHoadonxuatByIDHoadonXuat(int ID)
        {
            return new HoadonxuatService().getHoadonxuatByIDHoadonXuat(ID);
        }
        public System.Data.DataSet getLastHoadonxuatByIDPhong(int ID)
        {
            return new HoadonxuatService().getLastHoadonxuatByIDPhong(ID);
        }
        public System.Data.DataSet getLastHoadonxuatByIDPhongAndDate(int ID, DateTime Date)
        {
            return new HoadonxuatService().getLastHoadonxuatByIDPhongAndDate(ID, Date);
        }
        public System.Data.DataSet getAllOpenningHoadonxuatWithDeposit()
        {
            return new HoadonxuatService().getAllOpenningHoadonxuatWithDeposit();
        }
        public System.Data.DataSet getAllNotClosedHDXOfProductID(int ProductID)
        {
            return new HoadonxuatService().getAllNotClosedHDXOfProductID(ProductID);
        }
        public System.Data.DataSet getSoLuongSPBanRa()
        {
            return new HoadonxuatService().getSoLuongSPBanRa();
        }
 		public System.Data.DataSet getAllHoadonxuatSanpham()
        {
            return new HoadonxuatService().getAllHoadonxuatSanpham();
        }
        public System.Data.DataSet getAllHoadonxuatPhong()
        {
            return new HoadonxuatService().getAllHoadonxuatPhong();
        }
        #endregion

        #region Nhanvien
        public int insertNhanvien(Nhanvien objNhanvien)
        {
            return new NhanvienService().insertNhanvien(objNhanvien);
        }
        public bool updateNhanvien(Nhanvien objNhanvien)
        {
            return new NhanvienService().updateNhanvien(objNhanvien);
        }
        public bool deleteNhanvien(Nhanvien objNhanvien)
        {
            return new NhanvienService().deleteNhanvien(objNhanvien);
        }
        public System.Data.DataSet getAllNhanvien()
        {
            return new NhanvienService().getAllNhanvien();
        }
        public System.Data.DataSet getAllIDandNameNhanvien()
        {
            return new NhanvienService().getAllIDandNameNhanvien();
        }
        public Nhanvien getNhanvienByUsername_Password(string username, string password)
        {
            return new NhanvienService().getNhanvienByUsername_Password(username, password);
        }
        public int getIDNVByUsername(string usernameNhanvien)
        {
            return new NhanvienService().getIDNVByUsername(usernameNhanvien);
        }
		 public Nhanvien getNhanvienbyUserName(string p)
        {
            return new NhanvienService().getNhanvienByUsername(p);
        }
        #endregion

        #region HoaDonNhap
        public int insertHoaDonNhap(HoaDonNhap objHoaDonNhap)
        {
            return new HoaDonNhapService().insertHoaDonNhap(objHoaDonNhap);
        }
        public bool updateHoaDonNhap(HoaDonNhap objHoaDonNhap)
        {
            return new HoaDonNhapService().updateHoaDonNhap(objHoaDonNhap);
        }
        public bool deleteHoaDonNhap(HoaDonNhap objHoaDonNhap)
        {
            return new HoaDonNhapService().deleteHoaDonNhap(objHoaDonNhap);
        }
        public System.Data.DataSet getAllHoaDonNhap()
        {
            return new HoaDonNhapService().getAllHoaDonNhap();
        }
        public System.Data.DataSet getHoaDonNhap(DateTime dateFrom, DateTime dateTo)
        {
            return new HoaDonNhapService().getHoaDonNhap(dateFrom, dateTo);
        }
        #endregion

        #region ChiTietHoaDonNhap
        public int insertChiTietHoaDonNhap(ChiTietHoaDonNhap objChiTietHoaDonNhap)
        {
            return new ChiTietHoaDonNhapService().insertChiTietHoaDonNhap(objChiTietHoaDonNhap);
        }
        public bool updateChiTietHoaDonNhap(ChiTietHoaDonNhap objChiTietHoaDonNhap)
        {
            return new ChiTietHoaDonNhapService().updateChiTietHoaDonNhap(objChiTietHoaDonNhap);
        }
        public bool deleteChiTietHoaDonNhap(ChiTietHoaDonNhap objChiTietHoaDonNhap)
        {
            return new ChiTietHoaDonNhapService().deleteChiTietHoaDonNhap(objChiTietHoaDonNhap);
        }
        public System.Data.DataSet getAllChiTietHoaDonNhap()
        {
            return new ChiTietHoaDonNhapService().getAllChiTietHoaDonNhap();
        }
        public System.Data.DataSet getAllChiTietHoaDonNhapByIDHoaDonNhap(int IDHoaDonNhap)
        {
            return new ChiTietHoaDonNhapService().getAllChiTietHoaDonNhapByIDHoaDonNhap(IDHoaDonNhap);
        }
        #endregion

        #region ChitietHDXuat
        public int insertChitietHDXuat(ChitietHDXuat objChitietHDXuat)
        {
            return new ChitietHDXuatService().insertChitietHDXuat(objChitietHDXuat);
        }
        public bool updateChitietHDXuat(ChitietHDXuat objChitietHDXuat)
        {
            return new ChitietHDXuatService().updateChitietHDXuat(objChitietHDXuat);
        }
        public bool deleteChitietHDXuat(ChitietHDXuat objChitietHDXuat)
        {
            return new ChitietHDXuatService().deleteChitietHDXuat(objChitietHDXuat);
        }
        public System.Data.DataSet getAllChitietHDXuat()
        {
            return new ChitietHDXuatService().getAllChitietHDXuat();
        }
        public System.Data.DataSet getChitietHDXuatByID(int ID)
        {
            return new ChitietHDXuatService().getChitietHDXuatByID(ID);
        }
        public System.Data.DataSet getChitietHDXuatByIDSanphamAndIDHoadon(int IDSanpham,int IDHoadon)
        {
            return new ChitietHDXuatService().getChitietHDXuatByIDSanphamAndIDHoadon(IDSanpham,IDHoadon);
        }
        public bool deleteChitietHDXuatOfHDXuat(BKIT.Entities.Hoadonxuat objHDXuat)
        {
            return new ChitietHDXuatService().deleteChitietHDXuatOfHDXuat(objHDXuat);
        }
        #endregion
        //Global DataAccess
        #region Khachhang
        public int insertKhachhang(Khachhang objKhachhang)
        {
            return new KhachhangService().insertKhachhang(objKhachhang);
        }
        public bool updateKhachhang(Khachhang objKhachhang)
        {
            return new KhachhangService().updateKhachhang(objKhachhang);
        }
        public bool deleteKhachhang(Khachhang objKhachhang)
        {
            return new KhachhangService().deleteKhachhang(objKhachhang);
        }
        public System.Data.DataSet getAllKhachhang()
        {
            return new KhachhangService().getAllKhachhang();
        }
        #endregion


        public int getTonKhoDauKi(int IDSanPham)
        {
            return new TonKhoService().getTonKhoDauKi(IDSanPham);
        }
        public System.Data.DataSet getHoaDonNhap(int IDSanPham)
        {
            return new TonKhoService().getHoaDonNhap(IDSanPham);
        }
        public System.Data.DataSet getHoaDonXuat(int IDSanPham)
        {
            return new TonKhoService().getHoaDonXuat(IDSanPham);
        }
        public DateTime getNgayTonKhoDauKi(int IDSanPham)
        {
            return new TonKhoService().getNgayTonKhoDauKi(IDSanPham);
        }
        public int insertTonKho(TonKho objTonKho)
        {
            return new TonKhoService().insertTonKho(objTonKho);
        }

        //Global DataAccess
        #region Setting
        public int insertSetting(Setting objSetting)
        {
            return new SettingService().insertSetting(objSetting);
        }
        public bool updateSetting(Setting objSetting)
        {
            return new SettingService().updateSetting(objSetting);
        }
        public bool deleteSetting(Setting objSetting)
        {
            return new SettingService().deleteSetting(objSetting);
        }
        public System.Data.DataSet getAllSetting()
        {
            return new SettingService().getAllSetting();
        }
        public bool IsSetting(string dt)
        {
            return new SettingService().IsSetting(dt);
        }
        public System.Data.DataSet getSettingByDate(string dt)
        {
            return new SettingService().getSettingByDate(dt);
        }
        #endregion
        //Global DataAccess
        #region QuyenTruycap
        public int insertQuyenTruycap(QuyenTruycap objQuyenTruycap)
        {
            return new QuyenTruycapService().insertQuyenTruycap(objQuyenTruycap);
        }
        public bool updateQuyenTruycap(QuyenTruycap objQuyenTruycap)
        {
            return new QuyenTruycapService().updateQuyenTruycap(objQuyenTruycap);
        }
        public bool deleteQuyenTruycap(QuyenTruycap objQuyenTruycap)
        {
            return new QuyenTruycapService().deleteQuyenTruycap(objQuyenTruycap);
        }
        public System.Data.DataSet getAllQuyenTruycap()
        {
            return new QuyenTruycapService().getAllQuyenTruycap();
        }
        public bool IsSettingQuyenTruycap(string dt, string tenloainhanvien)
        {
            return new QuyenTruycapService().IsSettingQuyenTruycap(dt, tenloainhanvien);
        }
        public System.Data.DataSet getQuyenTruycapByDate(string dt, string tenloainhanvien)
        {
            return new QuyenTruycapService().getQuyenTruycapByDate(dt, tenloainhanvien);
        }
        public QuyenTruycap getQuyenTruycapByID(int p)
        {
            return new QuyenTruycapService().getQuyenTruycapByID(p);
        }
        #endregion
        //Global DataAccess
        #region LoaiNhanvien
        public int insertLoaiNhanvien(LoaiNhanvien objLoaiNhanvien)
        {
            return new LoaiNhanvienService().insertLoaiNhanvien(objLoaiNhanvien);
        }
        public bool updateLoaiNhanvien(LoaiNhanvien objLoaiNhanvien)
        {
            return new LoaiNhanvienService().updateLoaiNhanvien(objLoaiNhanvien);
        }
        public bool deleteLoaiNhanvien(LoaiNhanvien objLoaiNhanvien)
        {
            return new LoaiNhanvienService().deleteLoaiNhanvien(objLoaiNhanvien);
        }
        public System.Data.DataSet getAllLoaiNhanvien()
        {
            return new LoaiNhanvienService().getAllLoaiNhanvien();
        }
        #endregion

        #region PhieuDieuChinhTonKho
        public int insertPhieuDieuChinhTonKho(PhieuDieuChinhTonKho objPhieuDieuChinhTonKho)
        {
            return new PhieuDieuChinhTonKhoService().insertPhieuDieuChinhTonKho(objPhieuDieuChinhTonKho);
        }
        public bool updatePhieuDieuChinhTonKho(PhieuDieuChinhTonKho objPhieuDieuChinhTonKho)
        {
            return new PhieuDieuChinhTonKhoService().updatePhieuDieuChinhTonKho(objPhieuDieuChinhTonKho);
        }
        public bool deletePhieuDieuChinhTonKho(PhieuDieuChinhTonKho objPhieuDieuChinhTonKho)
        {
            return new PhieuDieuChinhTonKhoService().deletePhieuDieuChinhTonKho(objPhieuDieuChinhTonKho);
        }
        public System.Data.DataSet getAllPhieuDieuChinhTonKho()
        {
            return new PhieuDieuChinhTonKhoService().getAllPhieuDieuChinhTonKho();
        }
        public System.Data.DataSet getPhieuDieuChinhTonKhoByID(int ID)
        {
            return new PhieuDieuChinhTonKhoService().getPhieuDieuChinhTonKhoByID(ID);
        }
        public System.Data.DataSet getSLSPPhieuDieuChinhTonKhoByIDSanPham(int IDSanPham)
        {
            return new PhieuDieuChinhTonKhoService().getSLSPPhieuDieuChinhTonKhoByIDSanPham(IDSanPham);
        }
        #endregion PhieuDieuChinhTonKho
        #region SPPhaChe
        public int insertSPPhaChe(SPPhaChe objSPPhaChe)
        {
            return new SPPhaCheService().insertSPPhaChe(objSPPhaChe);
        }
        public bool updateSPPhaChe(SPPhaChe objSPPhaChe)
        {
            return new SPPhaCheService().updateSPPhaChe(objSPPhaChe);
        }
        public bool deleteSPPhaChe(SPPhaChe objSPPhaChe)
        {
            return new SPPhaCheService().deleteSPPhaChe(objSPPhaChe);
        }
        public System.Data.DataSet getAllSPPhaChe()
        {
            return new SPPhaCheService().getAllSPPhaChe();
        }
        public System.Data.DataSet getAllSPPhaCheByIDSanPham(int IDSanPham)
        {
            return new SPPhaCheService().getAllSPPhaCheByIDSanPham(IDSanPham);
        }
        public System.Data.DataSet getSLSPDaDungByIDSanPham(int IDSanPham)
        {
            return new SPPhaCheService().getSLSPDaDungByIDSanPham(IDSanPham);
        }
        #endregion SPPhaChe
	    #region Khuyenmai
            public int insertKhuyenmai(Khuyenmai objKhuyenmai)
            {
	            return new KhuyenmaiService().insertKhuyenmai(objKhuyenmai);
            }
            public bool updateKhuyenmai(Khuyenmai objKhuyenmai)
            {
	            return new KhuyenmaiService().updateKhuyenmai(objKhuyenmai);
            }
            public bool deleteKhuyenmai(Khuyenmai objKhuyenmai)
            {
	            return new KhuyenmaiService().deleteKhuyenmai(objKhuyenmai);
            }
            public System.Data.DataSet getAllKhuyenmai()
            {
	            return new KhuyenmaiService().getAllKhuyenmai();
            }
            public System.Data.DataSet getKhuyenmaiByIDLoaiSP(int IDLoaiSP, DateTime now)
            {
                return new KhuyenmaiService().getKhuyenmaiByIDLoaiSP(IDLoaiSP, now);
            }
    #endregion
        #region LoaiphongSPBandau
        public int insertLoaiphongSPBandau(LoaiphongSPBandau objLoaiphongSPBandau)
        {
	        return new LoaiphongSPBandauService().insertLoaiphongSPBandau(objLoaiphongSPBandau);
        }
        public bool updateLoaiphongSPBandau(LoaiphongSPBandau objLoaiphongSPBandau)
        {
	        return new LoaiphongSPBandauService().updateLoaiphongSPBandau(objLoaiphongSPBandau);
        }
        public bool deleteLoaiphongSPBandau(LoaiphongSPBandau objLoaiphongSPBandau)
        {
	        return new LoaiphongSPBandauService().deleteLoaiphongSPBandau(objLoaiphongSPBandau);
        }
        public System.Data.DataSet getAllLoaiphongSPBandau()
        {
	        return new LoaiphongSPBandauService().getAllLoaiphongSPBandau();
        }
        public System.Data.DataSet getAllSPBandauIDLoaiPhong(int IDLoaiPhong)
        {
                return new LoaiphongSPBandauService().getAllSPBandauIDLoaiPhong(IDLoaiPhong);
        }
        #endregion
        #region KhuyenmaiPhong
        public int insertKhuyenmaiPhong(KhuyenmaiPhong objKhuyenmai)
        {
            return new KhuyenmaiPhongService().insertKhuyenmaiPhong(objKhuyenmai);
        }
        public bool updateKhuyenmaiPhong(KhuyenmaiPhong objKhuyenmai)
        {
            return new KhuyenmaiPhongService().updateKhuyenmaiPhong(objKhuyenmai);
        }
        public bool deleteKhuyenmaiPhong(KhuyenmaiPhong objKhuyenmai)
        {
            return new KhuyenmaiPhongService().deleteKhuyenmaiPhong(objKhuyenmai);
        }
        public System.Data.DataSet getAllKhuyenmaiPhong()
        {
            return new KhuyenmaiPhongService().getAllKhuyenmaiPhong();
        }
        public System.Data.DataSet getKhuyenmaiByIDLoaiPhong(int IDLoaiPhong, DateTime now)
        {
            return new KhuyenmaiPhongService().getKhuyenmaiByIDLoaiPhong(IDLoaiPhong, now);
        }
        
        #endregion
        #region VanDe
        public int insertVanDe(VanDe objVanDe)
        {
            return new VanDeService().insertVanDe(objVanDe);
        }
        public bool updateVanDe(VanDe objVanDe)
        {
            return new VanDeService().updateVanDe(objVanDe);
        }
        public bool deleteVanDe(VanDe objVanDe)
        {
            return new VanDeService().deleteVanDe(objVanDe);
        }
        public System.Data.DataSet getAllVanDe()
        {
            return new VanDeService().getAllVanDe();
        }
        public System.Data.DataSet getAllVanDeByIDLoaiVD(int IDLoaiVD)
        {
            return new VanDeService().getAllVanDeByIDLoaiVD(IDLoaiVD);
        }
           
        #endregion
        #region
        public int insertLoaiVD(LoaiVD objLoaiVD)
        {
            return new LoaiVDService().insertLoaiVD(objLoaiVD);
        }
        public bool updateLoaiVD(LoaiVD objLoaiVD)
        {
            return new LoaiVDService().updateLoaiVD(objLoaiVD);
        }
        public bool deleteLoaiVD(LoaiVD objLoaiVD)
        {
            return new LoaiVDService().deleteLoaiVD(objLoaiVD);
        }
        public System.Data.DataSet getAllLoaiVD()
        {
            return new LoaiVDService().getAllLoaiVD();
        }
        public System.Data.DataSet getAllLoaiVDByIDLoaiVD(int IDLoaiVD)
        {
            return new LoaiVDService().getAllLoaiVDByIDLoaiVD(IDLoaiVD);
        }
        public int getIDLoaiVDByTenLoaiVD(string TenLoaiVD)
        {
            return new LoaiVDService().getIDLoaiVDByTenLoaiVD(TenLoaiVD);
        }
        #endregion
    }
}
