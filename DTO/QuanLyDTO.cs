using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class QuanLyDTO
    {
        public string id { get; set; }
        public string taiKhoan { get; set; }
        public string matKhau { get; set; }
        public string ten { get; set; }
        public DateTime ngaySinh { get; set; }

        public QuanLyDTO(string id, string taiKhoan, string matKhau, string ten, DateTime ngaySinh)
        { 
            this.id = id;
            this.taiKhoan = taiKhoan;
            this.matKhau = matKhau;
            this.ten = ten;
            this.ngaySinh = ngaySinh;
        
        }
    }
}
