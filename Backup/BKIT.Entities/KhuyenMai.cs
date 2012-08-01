using System;
using System.Collections.Generic;
using System.Text;

namespace BKIT.Entities
{
    public class Khuyenmai
{
	private int _IDKhuyenmai;
	public int IDKhuyenmai
	{
		get { return _IDKhuyenmai; }
		set { _IDKhuyenmai = value; }
	}
	private string _LoaiKM;
	public string LoaiKM
	{
		get { return _LoaiKM; }
		set { _LoaiKM = value; }
	}
	private int _IDNhomSP;
	public int IDNhomSP
	{
		get { return _IDNhomSP; }
		set { _IDNhomSP = value; }
	}
	private DateTime _NgayBD;
	public DateTime NgayBD
	{
		get { return _NgayBD; }
		set { _NgayBD = value; }
	}
	private DateTime _NgayKT;
	public DateTime NgayKT
	{
		get { return _NgayKT; }
		set { _NgayKT = value; }
	}
	private int _Giam;
	public int Giam
	{
		get { return _Giam; }
		set { _Giam = value; }
	}
	private string _Ghichu;
	public string Ghichu
	{
		get { return _Ghichu; }
		set { _Ghichu = value; }
	}
}
}
