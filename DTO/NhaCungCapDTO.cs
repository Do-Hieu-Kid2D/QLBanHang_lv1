using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NhaCungCapDTO
    {
        string ma { get; set; }
        string ten { get; set; }
        string diaChi { get; set; }
        string dienThoai { get; set; }
        string email { get; set; }
        string nguoiDaiDien { get; set; }

        public NhaCungCapDTO(string ma, string ten, string diaChi, string dienThoai, string email, string nguoiDaiDien)
        {
            this.ma = ma;
            this.ten = ten;
            this.diaChi = diaChi;
            this.dienThoai = dienThoai;
            this.email = email;
            this.nguoiDaiDien = nguoiDaiDien;
        }
    }
}
