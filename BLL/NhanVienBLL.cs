using DAL;
using DTO;
using System;


namespace BLL
{
    public class NhanVienBLL
    {
        public static NhanVienDTO dangNhapNhanVien(string tk, string mk)
        {
            NhanVienDTO kq = NhanVienDAL.dangNhapNhanVien(tk, mk);
            return kq;
        }
    }
}
