using System;
using System.Collections.Generic;
using System.Text;

namespace BKIT.Entities
{
    public class LoaiphongSPBandau
{
	private int _IDLPSP;
	public int IDLPSP
	{
		get { return _IDLPSP; }
		set { _IDLPSP = value; }
	}
	private int _IDSanPham;
	public int IDSanPham
	{
		get { return _IDSanPham; }
		set { _IDSanPham = value; }
	}
	private int _IDLoaiPhong;
	public int IDLoaiPhong
	{
		get { return _IDLoaiPhong; }
		set { _IDLoaiPhong = value; }
	}
	private int _Soluong;
	public int Soluong
	{
		get { return _Soluong; }
		set { _Soluong = value; }
	}
    private string _Ghichu;
    public string Ghichu
    {
        get { return _Ghichu; }
        set { _Ghichu = value; }
    }
}
}
