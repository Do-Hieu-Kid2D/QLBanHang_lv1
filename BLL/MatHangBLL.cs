using DAL;
using DTO;
using System.Data;

namespace BLL
{
    public class MatHangBLL
    {
        public static DataTable layALLMatHang()
        {
            DataTable kq = MatHangDAL.layALLMatHang();
            return kq;
        }
    }
}
