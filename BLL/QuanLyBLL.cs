using DTO;
using DAL;

namespace BLL
{
    public class QuanLyBLL
    {
        public static QuanLyDTO dangNhapQuanLy(string tk, string mk)
        {   QuanLyDTO kq = QuanLyDAL.dangNhapQuanLy(tk, mk);
            return kq;
        }
    }
}
