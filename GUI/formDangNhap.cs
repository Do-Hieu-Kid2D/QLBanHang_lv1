using System;

using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_CSDLBanHang
{
    public partial class formDangNhap : Form
    {
        public formDangNhap()
        {
            InitializeComponent();
        }
        string strCon = @"Data Source=DKID\SEVERTEN;Initial Catalog=lv22;Integrated Security=True";

        private void btnQuanLy_Click(object sender, EventArgs e)
        {
            string taiKhoan = txtTaiKhoan.Text;
            string matKhau = txtMatKhau.Text;
            string query = "select * from Quanly where taiKhoan = '" + taiKhoan + "' and matKhau ='" + matKhau + "';";
            SqlConnection sqlCon = new SqlConnection(strCon);
            sqlCon.Open();
            SqlCommand cmd = sqlCon.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = query;
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                // Nếu nó đọc đc -> trả về data -> ở bài này mk băm nhỏ ra hiện vào từng txt
                string id = reader.GetString(0);
                string ten = reader.GetString(3);
                MessageBox.Show(id + "   " + ten);
                //string ngaySinh = reader.GetString(4);

            }
            // đóng đầu đọc
            reader.Close();
            cmd.Dispose();
            sqlCon.Close();
            sqlCon.Dispose();
        }

        private void formDangNhap_Load(object sender, EventArgs e)
        {

        }
    }
}
