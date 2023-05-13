using DAL;
using DTO;
using System;
using System.Data;

namespace BLL
{
    public class NhanVienBLL
    {
        public static NhanVienDTO dangNhapNhanVien(string tk, string mk)
        {
            NhanVienDTO kq = NhanVienDAL.dangNhapNhanVien(tk, mk);
            return kq;
        }

        public static DataTable layAllNhanVien()
        {
            return NhanVienDAL.layAllNhanVien();
        }

        public static int xoaNV(string maNVXoa)
        {
            return NhanVienDAL.xoaNV(maNVXoa);
        }
    }
}
