using DAL;
using DTO;
using System;
using System.Data;

namespace BLL
{
    public class MatHangBLL
    {
        public static DataTable layALLMatHang(string dk)
        {
            DataTable kq = MatHangDAL.layALLMatHang(dk);
            return kq;
        }

        public static int xoaMH(string maMHXoa)
        {
            return MatHangDAL.xoaMH(maMHXoa);
        }
    }
}
