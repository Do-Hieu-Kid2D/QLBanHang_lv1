using System;
using System.Windows.Forms;
using BLL;
using DTO;
using BotBanHang;
using GUI;
using Telegram.Bot;

namespace Project_CSDLBanHang
{
    public partial class formDangNhap : Form
    {

        public BotBanHang.formBot formBot;

        public formDangNhap()
        {
            InitializeComponent();
            formBot = new BotBanHang.formBot();
           
        }

        private void send(string header, string txt)
        {
            string timenow = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
            formBot.botClient.SendTextMessageAsync(
                chatId: formBot.chatId,
                text: header + timenow + "\n"+txt,
                parseMode: Telegram.Bot.Types.Enums.ParseMode.Markdown
                );
        }

        private void btnQuanLy_Click(object sender, EventArgs e)
        {
            if (checkInput())
            {
                string taiKhoan = txtTaiKhoan.Text;
                string matKhau = txtMatKhau.Text;
                QuanLyDTO quanLy = QuanLyBLL.dangNhapQuanLy(taiKhoan, matKhau);
                if (quanLy != null)
                {
                    formQuanLy formQuanLy = new formQuanLy(this, taiKhoan);
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
                    formNhanVien formNhanVien = new formNhanVien(this, taiKhoan);
                    this.txtMatKhau.Text = "";
                    this.txtTaiKhoan.Text = "";
                    this.Hide();
                    formNhanVien.Show();
                    send("✅ ", $"Tài khoản: {taiKhoan} đã đăng nhập với tư cách là nhân viên.");
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

        private void formDangNhap_Load(object sender, EventArgs e)
        {
            send("🛑 ", "Ứng dụng bán hàng vừa được khởi động!");
        }
    }
}