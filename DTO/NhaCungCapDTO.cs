using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NhaCungCapDTO
    {
        public string ma { get; set; }
        public string ten { get; set; }
        public string diaChi { get; set; }
        public string dienThoai { get; set; }
        public string email { get; set; }
        public string nguoiDaiDien { get; set; }

        public NhaCungCapDTO(string ma, string ten, string diaChi, string dienThoai, string email, string nguoiDaiDien)
        {
            this.ma = ma;
            this.ten = ten;
            this.diaChi = diaChi;
            this.dienThoai = dienThoai;
            this.email = email;
            this.nguoiDaiDien = nguoiDaiDien;
        }

        public NhaCungCapDTO()
        {
        }
    }
}
