using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class KhachHangDTO
    {
        public String maKh { get; set; }
        public string tenKH { get; set; }
        public Boolean gioiTinh { get; set; }
        public string tenCT { get; set; }
        public string diaChi { get; set; }
        public string Email { get; set; }
        public string sdt { get; set; }

        public KhachHangDTO(string maKh, string tenKH, bool gioiTinh, string tenCT, string diaChi, string Email, string sdt)
        {
            this.maKh = maKh;
            this.tenKH = tenKH;
            this.gioiTinh = gioiTinh;
            this.tenCT = tenCT;
            this.diaChi = diaChi;
            this.Email = Email;
            this.sdt = sdt;
        }

        public KhachHangDTO()
        {
        }
    }
}
