using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class KhachHangBLL
    {
        public static DataTable layALLKhachHang(string dk)
        {
            DataTable kq = new DataTable();
            kq = KhachHangDAL.layALLKhachHang(dk);
            return kq;
        }

        public static string sua1KhachHang(KhachHangDTO khMoi, KhachHangDTO khCu)
        {
            return KhachHangDAL.sua1KhachHang(khMoi, khCu);
        }

        public static string them1KhachHang(KhachHangDTO khCanThem)
        {
            return KhachHangDAL.them1KhachHang(khCanThem);
        }

        public static int xoaKH(string maKHXoa)
        {
            return KhachHangDAL.xoaKH(maKHXoa);
        }
    }
}
