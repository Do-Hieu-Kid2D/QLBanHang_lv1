
namespace DTO
{
    public class MatHangDTO
    {
        public string maHang { get; set; }
        public string tenHang { get; set; }
        public string maNCC { get; set; }
        public string maLoaiHang { get; set; }
        public int soLuong { get; set; }
        public string donViTinh { get; set; }
        public decimal giaNhap { get; set; }
        public decimal giaBan { get; set; }
        public string hinhAnh { get; set; }

        public MatHangDTO(string maHang, string tenHang, string maNCC, string maLoaiHang, int soLuong, string donViTinh, decimal giaNhap, decimal giaBan, string hinhAnh)
        {
            this.maHang = maHang;
            this.tenHang = tenHang;
            this.maNCC = maNCC;
            this.maLoaiHang = maLoaiHang;
            this.soLuong = soLuong;
            this.donViTinh = donViTinh;
            this.giaNhap = giaNhap;
            this.giaBan = giaBan;
            this.hinhAnh = hinhAnh;
        }

        public MatHangDTO()
        {
        }
    }
}
