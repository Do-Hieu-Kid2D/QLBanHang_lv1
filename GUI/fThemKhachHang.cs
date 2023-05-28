using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace GUI
{
    public partial class fThemKhachHang : Form
    {
        String maKh = "";
        string tenKH = "";
        Boolean gioiTinh;
        string tenCT = "";
        string diaChi = "";
        string Email = "";
        string sdt = "";
        formQuanLy fQL = new formQuanLy(new Project_CSDLBanHang.formDangNhap(),"");
        public fThemKhachHang()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Boolean ok = checkData();
            if (!ok)
            {
                MessageBox.Show("Bạn chưa nhập đủ thông tin!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // check song chưa nhập đủ thông tin! - là đủ rồi - cùng lắm thêm lỗi trùng mã KH thôi
            try
            {
                KhachHangDTO khCanThem = layThongTinform();
                if (khCanThem == null) return;
                string kq = fQL.them1KhachHang(khCanThem);

                if (kq.EndsWith("thành công!"))
                {
                    fQL.hienThiALLKhachHang("");
                    MessageBox.Show(kq, "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    resetData();
                }
                else
                {
                    if (kq.Contains("CHK_dienThoaikhachHang"))
                        MessageBox.Show("Đảm bảo SĐT chứa đúng 10 chữ số!", "Thông báo!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        MessageBox.Show(kq, "Thông báo!!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo ERR!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void resetData()
        {
            txtMaKH.Text = "";
            txtTenKH.Text = "";
            radNam.Checked = false; radNu.Checked = false;
            txtTenCT.Text = "";
            txtDiaChi.Text = "";
            txtEmail.Text = "";
            txtSDT.Text = "";
        }

        private KhachHangDTO layThongTinform()
        {
            maKh = txtMaKH.Text;
            tenKH = txtTenKH.Text;
            if (radNam.Checked) gioiTinh = true;
            if (radNu.Checked) gioiTinh = false;
            tenCT = txtTenCT.Text;
            diaChi = txtDiaChi.Text;
            Email = txtEmail.Text;
            sdt = txtSDT.Text;
            if (sdt.Length != 10)
            {
                MessageBox.Show("Đảm bảo SĐT chứa đúng 10 chữ số!", "Thông báo!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            return new KhachHangDTO(maKh, tenKH, gioiTinh, tenCT, diaChi, Email, sdt);
        }

        private bool checkData()
        {
            maKh = txtMaKH.Text;
            tenKH = txtTenKH.Text;
            if (radNam.Checked) gioiTinh = true;
            if (radNu.Checked) gioiTinh = false;
            tenCT = txtTenCT.Text;
            diaChi = txtDiaChi.Text;
            Email = txtEmail.Text;
            sdt = txtSDT.Text;
            if (!radNam.Checked && !radNu.Checked) return false;
            return isRong(maKh) && isRong(tenKH) && isRong(tenCT) && isRong(diaChi) && isRong(Email) && isRong(sdt);

        }

        private bool isRong(string txt)
        {
            return txt != "";
        }
    }
}
