using System;
using System.Collections.Generic;
using System.Text;
using BKIT.Entities;

namespace BKIT.Model
{
    interface IDataAccess
    {
        int insertNhomSP(NhomSP objNhomSP);
        bool updateNhomSP(NhomSP objNhomSP);
        bool deleteNhomSP(NhomSP objNhomSP);
        System.Data.DataSet getAllNhomSP();
        System.Data.DataSet getNhomSPByTenSP(string ten);

        int insertSanPham(SanPham objSanPham);
        bool updateSanPham(SanPham objSanPham);
        bool deleteSanPham(SanPham objSanPham);
        System.Data.DataSet getAllSanPham();
        System.Data.DataSet getSanPhamByIDNhomSP(int ID);
        System.Data.DataSet getAllSanPhamAndIDGia(string searchTenSanPhamTemplate);
        System.Data.DataSet getAllSanPhamAndIDGia();
        System.Data.DataSet getIDSanPhamByTenSP(string TenSanPham);

        System.Data.DataSet getSanPhamByTenSP(string ten);

        int insertGiaXuatSP(GiaXuatSP objGiaXuatSP);
        bool updateGiaXuatSP(GiaXuatSP objGiaXuatSP);
        bool deleteGiaXuatSP(GiaXuatSP objGiaXuatSP);
        System.Data.DataSet getAllGiaXuatSP();
        System.Data.DataSet getGiaXuatSPByIDSanPham(int ID);

        int insertLoaiPhong(LoaiPhong objLoaiPhong);
        bool updateLoaiPhong(LoaiPhong objLoaiPhong);
        bool deleteLoaiPhong(LoaiPhong objLoaiPhong);
        System.Data.DataSet getAllLoaiPhong();
        System.Data.DataSet getLoaiPhongByIDLoaiPhong(int ID);
        System.Data.DataSet getLoaiPhongByTenLoaiPhong(string ten);

        int insertPhong(Phong objPhong);
        bool updatePhong(Phong objPhong);
        bool deletePhong(Phong objPhong);
        System.Data.DataSet getAllPhong();
        System.Data.DataSet getPhongByIDPhong(int ID);
        System.Data.DataSet getPhongByIDLoaiPhong(int ID);
        System.Data.DataSet getAllPhongAndLoaiPhong();
        System.Data.DataSet getAllPhongAndLoaiPhong(int diffID);
        System.Data.DataSet getAllFreePhongAndLoaiPhong(int diffID);
        System.Data.DataSet getAllBusyPhongAndLoaiPhong(int diffID);

        int insertGiaLoaiPhong(GiaLoaiPhong objGiaLoaiPhong);
        bool updateGiaLoaiPhong(GiaLoaiPhong objGiaLoaiPhong);
        bool deleteGiaLoaiPhong(GiaLoaiPhong objGiaLoaiPhong);
        System.Data.DataSet getAllGiaLoaiPhong();
        System.Data.DataSet getGiaLoaiPhongByIDLoaiPhongAndIDKhunggio(int IDLoaiphong, int IDKhunggio);

        int insertKhunggio(Khunggio objKhunggio);
        bool updateKhunggio(Khunggio objKhunggio);
        bool deleteKhunggio(Khunggio objKhunggio);
        System.Data.DataSet getAllKhunggio();


        int insertHoadonxuat(Hoadonxuat objHoadonxuat);
        bool updateHoadonxuat(Hoadonxuat objHoadonxuat);
        bool deleteHoadonxuat(Hoadonxuat objHoadonxuat);
        System.Data.DataSet getAllHoadonxuat();
        System.Data.DataSet getHoadonxuatByIDHoadonXuat(int ID);
        System.Data.DataSet getLastHoadonxuatByIDPhong(int ID);
        System.Data.DataSet getLastHoadonxuatByIDPhongAndDate(int ID, DateTime Date);
        System.Data.DataSet getLastOpeningHoadonxuatByIDPhong(int ID);
		System.Data.DataSet getAllOpenningHoadonxuatWithDeposit();
        System.Data.DataSet getAllWarningOpenningHoadonxuat();
        System.Data.DataSet getAllNotClosedHDXOfProductID(int ProductID);
        System.Data.DataSet getSoLuongSPBanRa();
		System.Data.DataSet getAllHoadonxuatSanpham();
        System.Data.DataSet getAllHoadonxuatPhong();

        int insertNhanvien(Nhanvien objNhanvien);
        bool updateNhanvien(Nhanvien objNhanvien);
        bool deleteNhanvien(Nhanvien objNhanvien);
        System.Data.DataSet getAllNhanvien();
        System.Data.DataSet getAllIDandNameNhanvien();
        Nhanvien getNhanvienByUsername_Password(string username, string password);
        int getIDNVByUsername(string usernameNhanvien);
		Nhanvien getNhanvienbyUserName(string p);

        int insertHoaDonNhap(HoaDonNhap objHoaDonNhap);
        bool updateHoaDonNhap(HoaDonNhap objHoaDonNhap);
        bool deleteHoaDonNhap(HoaDonNhap objHoaDonNhap);
        System.Data.DataSet getAllHoaDonNhap();
        System.Data.DataSet getHoaDonNhap(DateTime dateFrom, DateTime dateTo);

        int insertChiTietHoaDonNhap(ChiTietHoaDonNhap objChiTietHoaDonNhap);
        bool updateChiTietHoaDonNhap(ChiTietHoaDonNhap objChiTietHoaDonNhap);
        bool deleteChiTietHoaDonNhap(ChiTietHoaDonNhap objChiTietHoaDonNhap);
        System.Data.DataSet getAllChiTietHoaDonNhap();
        System.Data.DataSet getAllChiTietHoaDonNhapByIDHoaDonNhap(int IDHoaDonNhap);

        int insertChitietHDXuat(ChitietHDXuat objChitietHDXuat);
        bool updateChitietHDXuat(ChitietHDXuat objChitietHDXuat);
        bool deleteChitietHDXuat(ChitietHDXuat objChitietHDXuat);
        System.Data.DataSet getAllChitietHDXuat();
        System.Data.DataSet getChitietHDXuatByIDSanphamAndIDHoadon(int IDSanpham, int IDHoadon);
        System.Data.DataSet getChitietHDXuatByID(int ID);
        System.Data.DataSet getSumChitietHDXuatByID(int ID);
        bool deleteChitietHDXuatOfHDXuat(BKIT.Entities.Hoadonxuat objHDXuat);


        int getTonKhoDauKi(int IDSanPham);
        System.Data.DataSet getHoaDonNhap(int IDSanPham);
        System.Data.DataSet getHoaDonXuat(int IDSanPham);
        DateTime getNgayTonKhoDauKi(int IDSanPham);
        int insertTonKho(TonKho objTonKho);

        int insertKhachhang(Khachhang objKhachhang);
        bool updateKhachhang(Khachhang objKhachhang);
        bool deleteKhachhang(Khachhang objKhachhang);
        System.Data.DataSet getAllKhachhang();

        int insertSetting(Setting objSetting);
        bool updateSetting(Setting objSetting);
        bool deleteSetting(Setting objSetting);
        System.Data.DataSet getAllSetting();
        bool IsSetting(string dt);

        int insertQuyenTruycap(QuyenTruycap objQuyenTruycap);
        bool updateQuyenTruycap(QuyenTruycap objQuyenTruycap);
        bool deleteQuyenTruycap(QuyenTruycap objQuyenTruycap);
        System.Data.DataSet getAllQuyenTruycap();
        bool IsSettingQuyenTruycap(string dt, string tenloainhanvien);
        System.Data.DataSet getQuyenTruycapByDate(string dt, string tenloainhanvien);
        QuyenTruycap getQuyenTruycapByID(int p);

        int insertLoaiNhanvien(LoaiNhanvien objLoaiNhanvien);
        bool updateLoaiNhanvien(LoaiNhanvien objLoaiNhanvien);
        bool deleteLoaiNhanvien(LoaiNhanvien objLoaiNhanvien);
        System.Data.DataSet getAllLoaiNhanvien();

        #region PhieuDieuChinhTonKho
        int insertPhieuDieuChinhTonKho(PhieuDieuChinhTonKho objPhieuDieuChinhTonKho);
        bool updatePhieuDieuChinhTonKho(PhieuDieuChinhTonKho objPhieuDieuChinhTonKho);
        bool deletePhieuDieuChinhTonKho(PhieuDieuChinhTonKho objPhieuDieuChinhTonKho);
        System.Data.DataSet getAllPhieuDieuChinhTonKho();
        System.Data.DataSet getPhieuDieuChinhTonKhoByID(int ID);
        System.Data.DataSet getSLSPPhieuDieuChinhTonKhoByIDSanPham(int IDSanPham);  
        #endregion PhieuDieuChinhTonKho
        #region SPPhaChe
        int insertSPPhaChe(SPPhaChe objSPPhaChe);
        bool updateSPPhaChe(SPPhaChe objSPPhaChe);
        bool deleteSPPhaChe(SPPhaChe objSPPhaChe);
        System.Data.DataSet getAllSPPhaChe();
        System.Data.DataSet getAllSPPhaCheByIDSanPham(int IDSanPham);
        System.Data.DataSet getSLSPDaDungByIDSanPham(int IDSanPham);
        #endregion SPPhaChe
		int insertKhuyenmai(Khuyenmai objKhuyenmai);
        bool updateKhuyenmai(Khuyenmai objKhuyenmai);
        bool deleteKhuyenmai(Khuyenmai objKhuyenmai);
        System.Data.DataSet getAllKhuyenmai();
        System.Data.DataSet getKhuyenmaiByIDLoaiSP(int IDLoaiSP, DateTime now);

        int insertLoaiphongSPBandau(LoaiphongSPBandau objLoaiphongSPBandau);
        bool updateLoaiphongSPBandau(LoaiphongSPBandau objLoaiphongSPBandau);
        bool deleteLoaiphongSPBandau(LoaiphongSPBandau objLoaiphongSPBandau);
        System.Data.DataSet getAllLoaiphongSPBandau();

        int insertKhuyenmaiPhong(KhuyenmaiPhong objKhuyenmai);
        bool updateKhuyenmaiPhong(KhuyenmaiPhong objKhuyenmai);
        bool deleteKhuyenmaiPhong(KhuyenmaiPhong objKhuyenmai);
        System.Data.DataSet getAllKhuyenmaiPhong();
        System.Data.DataSet getKhuyenmaiByIDLoaiPhong(int IDLoaiPhong, DateTime now);
        #region VanDe
        int insertVanDe(VanDe objVanDe);
        bool updateVanDe(VanDe objVanDe);
        bool deleteVanDe(VanDe objVanDe);
        System.Data.DataSet getAllVanDe();
        System.Data.DataSet getAllVanDeByIDLoaiVD(int IDLoaiVD);
        #endregion
        #region LoaiVD
        int insertLoaiVD(LoaiVD objLoaiVD);
        bool updateLoaiVD(LoaiVD objLoaiVD);
        bool deleteLoaiVD(LoaiVD objLoaiVD);
        System.Data.DataSet getAllLoaiVD();
        System.Data.DataSet getAllLoaiVDByIDLoaiVD(int IDLoaiVD);
        int getIDLoaiVDByTenLoaiVD(string TenLoaiVD);
        #endregion
    }
}
