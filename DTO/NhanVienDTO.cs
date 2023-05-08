using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NhanVienDTO
    {

        public string ma { get; set; }
        public string hoVaTen { get; set; }
        public Boolean gioiTinh { get; set; }
        public DateTime ngaySinh { get; set; }
        public DateTime ngayLamViec { get; set; }
        public string diaChi { get; set; }
        public string dienthoai { get; set; }
        public decimal luong { get; set; }
        public decimal phuCap { get; set; }
        public string taiKhoan { get; set; }
        public string matKhau { get; set; }

        public NhanVienDTO(string ma, string hoVaTen, bool gioiTinh, DateTime ngaySinh, DateTime ngayLamViec,
            string diaChi, string dienthoai, decimal luong, decimal phuCap, string taiKhoan, string matKhau)
        {
            this.ma = ma;
            this.hoVaTen = hoVaTen;
            this.gioiTinh = gioiTinh;
            this.ngaySinh = ngaySinh;
            this.ngayLamViec = ngayLamViec;
            this.diaChi = diaChi;
            this.dienthoai = dienthoai;
            this.luong = luong;
            this.phuCap = phuCap;
            this.taiKhoan = taiKhoan;
            this.matKhau = matKhau;
        }
    }
}
