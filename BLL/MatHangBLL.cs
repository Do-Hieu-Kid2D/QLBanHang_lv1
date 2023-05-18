using DAL;
using DTO;
using System;
using System.Data;

namespace BLL
{
    public class MatHangBLL
    {
        public static string capNhat1MatHang(MatHangDTO mh, string maHangCu)
        {
            return MatHangDAL.capNhat1MatHang(mh, maHangCu);
        }

        public static DataTable layALLMatHang(string dk)
        {
            DataTable kq = MatHangDAL.layALLMatHang(dk);
            return kq;
        }

        public static string them1MatHang(MatHangDTO matHang)
        {
            return MatHangDAL.them1MatHang(matHang);

        }

        public static int xoaMH(string maMHXoa)
        {
            return MatHangDAL.xoaMH(maMHXoa);
        }
    }
}
