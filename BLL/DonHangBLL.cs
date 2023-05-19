using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class DonHangBLL
    {
        public static DataTable layALLDonHang(string dk)
        {
            DataTable kq = new DataTable();
            kq = DonHangDAL.layALLDonHang(dk);
            return kq;
        }

        public static string sua1DonHang(DonHangDTO dhMoi, DonHangDTO dhCu)
        {
            return DonHangDAL.sua1DonHang(dhMoi, dhCu);
        }

        public static string them1DonHang(DonHangDTO donhangMoi)
        {
            return DonHangDAL.them1DonHang(donhangMoi);
        }

        public static int xoaDH(string maDHXoa)
        {
            return DonHangDAL.xoaDH(maDHXoa);
        }
    }
}
