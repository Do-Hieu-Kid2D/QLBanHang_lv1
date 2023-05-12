using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

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
    }
}
