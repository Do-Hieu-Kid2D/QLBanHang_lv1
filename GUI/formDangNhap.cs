using System;
using System.Windows.Forms;
using BLL;
using DTO;
using GUI;

namespace Project_CSDLBanHang
{

    public partial class formDangNhap : Form
    {
        public formDangNhap()
        {
            InitializeComponent();
        }


        private void btnQuanLy_Click(object sender, EventArgs e)
        {
            if (checkInput())
            {
                string taiKhoan= txtTaiKhoan.Text;
                string matKhau = txtMatKhau.Text;
                QuanLyDTO quanLy = QuanLyBLL.dangNhapQuanLy(taiKhoan,matKhau);
                if(quanLy!=null)
                {
                    formQuanLy formQuanLy = new formQuanLy(this);
                    this.txtMatKhau.Text = "";
                    this.txtTaiKhoan.Text = "";
                    this.Hide();
                    formQuanLy.Show();
                    
                }
                else
                {
                    MessageBox.Show("Tài khoản đăng nhập hoặc mật khẩu không chính xác!\n\r Vui vòng đăng nhập lại.", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Bạn phải nhập đủ tài khoản và mật khẩu!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
}

        public Boolean checkInput()
        {
            if (txtMatKhau.Text == "" || txtTaiKhoan.Text == "")
            {
                return false;
            }
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkInput())
            {
                string taiKhoan = txtTaiKhoan.Text;
                string matKhau = txtMatKhau.Text;
                NhanVienDTO nhanVien = NhanVienBLL.dangNhapNhanVien(taiKhoan, matKhau);
                if (nhanVien != null)
                {
                    formNhanVien formNhanVien = new formNhanVien(this);
                    this.txtMatKhau.Text = "";
                    this.txtTaiKhoan.Text = "";
                    this.Hide();
                    formNhanVien.Show();

                }
                else
                {
                    MessageBox.Show("Tài khoản đăng nhập hoặc mật khẩu không chính xác!\n\r Vui vòng đăng nhập lại.", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Bạn phải nhập đủ tài khoản và mật khẩu!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát ứng dụng không?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}