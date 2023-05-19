using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DonHangDTO
    {

        public string soHD { get; set; }
        public string maKH { get; set; }
        public string maNv { get; set; }
        public DateTime datHang { get; set; }
        public DateTime giaoHang { get; set; }
        public string diaChiGiaoHang { get; set; }
        public string maHTTT { get; set; }

        public DonHangDTO(string soHD, string maKH, string maNv, DateTime datHang, DateTime giaoHang,
            string diaChiGiaoHang, string maHTTT)
        {
            this.soHD = soHD;
            this.maKH = maKH;
            this.maNv = maNv;
            this.datHang = datHang;
            this.giaoHang = giaoHang;
            this.diaChiGiaoHang = diaChiGiaoHang;
            this.maHTTT = maHTTT;
        }

        public DonHangDTO()
        {
        }
    }
}
