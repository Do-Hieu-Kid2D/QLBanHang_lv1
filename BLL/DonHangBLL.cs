using DAL;
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
        public static DataTable layALLDonHang()
        {
            DataTable kq = new DataTable();
            kq = DonHangDAL.layALLDonHang();
            return kq;
        }
    }
}
