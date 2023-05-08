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
    public partial class formQuanLy : Form
    {
        formDangNhap fDN;
        public formQuanLy(formDangNhap dangNhap)
        {
            InitializeComponent();
            fDN = dangNhap;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new Size(800, 600);
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn đăng xuất không?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question,MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)
            {
                fDN.Show();
                this.Close();
            }
            
        }
    }
}
