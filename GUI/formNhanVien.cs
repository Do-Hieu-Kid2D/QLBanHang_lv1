using DTO;
using Project_CSDLBanHang;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class formNhanVien : Form
    {
        formDangNhap fDN;
        string tenDN ;
        public formNhanVien(formDangNhap dangNhap, string  tebDNnv)
        {
            InitializeComponent();
            fDN = dangNhap;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new Size(800, 600);
            labChucNang.Text = "--- > Cửa hàng Dkid < ---";
            this.tenDN = tebDNnv;

        }
        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn đăng xuất không?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)
            {
                fDN.Show();
                this.Close();
            }
        }
        // Biến kiểm soát
        private Form formConHienTai = null;

        private void moFormCon(Form formCon)
        {
            // chuyển 1 form khác - cứ hủy thằng đang tồn tại đi đã
            if(formConHienTai != null)
            {
                formConHienTai.Close();
            }
            // thằng kiểm soát là Form được truyền vào nè!
            formConHienTai = formCon;

            // cài đặt này giúp vẫn có thể thao tác trên form cha
            formCon.TopLevel = false;
            formCon.FormBorderStyle = FormBorderStyle.None; // bỏ .. của form
            formCon.Dock = DockStyle.Fill;
            panBody.Controls.Add(formCon);
            panBody.Tag = formCon;  // tag này mk gắn kiểu data j cũng dc ?><?
            formCon.BringToFront();
            formCon.Show();      
        }

        private void btnTaoHoaDon_Click(object sender, EventArgs e)
        {
            labChucNang.Text = "--- > LẬP HÓA ĐƠN < ---";
            this.labChucNang.BackColor = System.Drawing.Color.SpringGreen;
            moFormCon(new fLapHoaDon(tenDN));

        }
        private void btnThemKhachHang_Click(object sender, EventArgs e)
        {
            labChucNang.Text = "--- > THÊM KHÁCH HÀNG < ---";
            this.labChucNang.BackColor = System.Drawing.Color.Khaki;
            moFormCon(new fThemKhachHang());
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (formConHienTai != null)
            {
                formConHienTai.Close();
            }
            labChucNang.Text = "--- > Cửa hàng Dkid < ---";
            this.labChucNang.BackColor = System.Drawing.Color.BurlyWood;
        }

    }
}
