using BLL;
using Project_CSDLBanHang;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Security.Cryptography;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GUI
{
    public partial class formQuanLy : Form
    {
        string strCon = Properties.Settings.Default.strCon;
        formDangNhap fDN;
        public formQuanLy(formDangNhap dangNhap)
        {
            InitializeComponent();
            fDN = dangNhap;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new Size(1010, 600);
            txtTimMatHang.ForeColor = Color.Gray; // Màu xám
            txtTimKhachHang.ForeColor = Color.Gray; // Màu xám
            txtTimNhanVien.ForeColor = Color.Gray; // Màu xám
            txtTimDonHang.ForeColor = Color.Gray; // Màu xám
            txtTimNCC.ForeColor = Color.Gray; // Màu xám
            this.dgvDataMH.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;

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

        private void txtTimKiem_MouseClick(object sender, MouseEventArgs e)
        {
            txtTimMatHang.Text = "";
            txtTimMatHang.ForeColor = Color.Black; // Đen
        }

        private void formQuanLy_Load(object sender, EventArgs e)
        {
            //hienThiALLMatHang();
            //hienThiALLKhachHang();
            //hienThiAllDonHang();
            //hienThiAllNhanVien();
        }

        public void settingDgvMH()
        {
            try
            {
                // Bỏ cột mặc định dataGridView
                dgvDataMH.RowHeadersVisible = false;

                dgvDataMH.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                dgvDataMH.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgvDataMH.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 12, FontStyle.Bold);
                dgvDataMH.Columns[0].HeaderText = "Mã hàng";
                dgvDataMH.Columns[1].HeaderText = "                Tên hàng              ";
                dgvDataMH.Columns[2].HeaderText = "Mã NCC";
                dgvDataMH.Columns[3].HeaderText = "Mã LH";
                dgvDataMH.Columns[4].HeaderText = "Số lượng";
                dgvDataMH.Columns[5].HeaderText = "ĐV tính";
                dgvDataMH.Columns[6].HeaderText = "Giá nhập";
                dgvDataMH.Columns[7].HeaderText = "Giá bán";
                dgvDataMH.Columns[8].HeaderText = "Hình ảnh";

                dgvDataMH.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvDataMH.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvDataMH.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvDataMH.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvDataMH.Columns[6].DefaultCellStyle.Format = "N0";
                dgvDataMH.Columns[7].DefaultCellStyle.Format = "N0";

                foreach (DataGridViewColumn col in dgvDataMH.Columns)
                {
                    col.SortMode = DataGridViewColumnSortMode.NotSortable;
                }

                dgvDataMH.Columns[1].Width = 110;
                dgvDataMH.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                //splitContainer8.FixedPanel = FixedPanel.Panel1; // Khóa Panel1 cố định kích thước
                //splitContainer8.FixedPanel = FixedPanel.Panel2; // Khóa Panel2 cố định kích thước


            }
            catch { }

        }

        public void hienThiALLMatHang()
        {
            DataTable data = MatHangBLL.layALLMatHang();
            //dgvDataMH.Rows.Clear();
            dgvDataMH.DataSource = data;
            settingDgvMH();
        }

        private void btnALlHang_Click(object sender, EventArgs e)
        {
            hienThiALLMatHang();
        }

        private void btnAllKhachHang_Click(object sender, EventArgs e)
        {
            hienThiALLKhachHang();
        }

        public void hienThiALLKhachHang()
        {
            DataTable data = KhachHangBLL.layALLKhachHang();
            //dgvDataMH.Rows.Clear();
            dgvDataKH.DataSource = data;
            settingDgvKH();
        }

        public void settingDgvKH()
        {
            // Bỏ cột mặc định dataGridView
            dgvDataKH.RowHeadersVisible = false;
            dgvDataKH.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 12, FontStyle.Bold);
            dgvDataKH.Columns[0].HeaderText = " Mã KH  ";
            dgvDataKH.Columns[1].HeaderText = "Tên KH";
            dgvDataKH.Columns[2].HeaderText = "Giới tính";
            dgvDataKH.Columns[3].HeaderText = "Tên CT";
            dgvDataKH.Columns[4].HeaderText = "Địa chỉ";
            dgvDataKH.Columns[5].HeaderText = "Email";
            dgvDataKH.Columns[6].HeaderText = "Điện thoại";

            foreach (DataGridViewColumn col in dgvDataKH.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }


        }

        private void btnDonHang_Click(object sender, EventArgs e)
        {
            hienThiAllDonHang();
        }

        public void hienThiAllDonHang()
        {
            DataTable data = DonHangBLL.layALLDonHang();
            //dgvDataMH.Rows.Clear();
            dgvDataDH.DataSource = data;
            settingDgvDH();
        }

        public void settingDgvDH()
        {
            // Bỏ cột mặc định dataGridView
            dgvDataDH.RowHeadersVisible = false;
            // Thiết lập font đậm cho dòng header của DataGridView
            dgvDataDH.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 12, FontStyle.Bold);

            dgvDataDH.Columns[0].HeaderText = " Số HĐ  ";
            dgvDataDH.Columns[1].HeaderText = "    Mã KH    ";
            dgvDataDH.Columns[2].HeaderText = "    Mã NV    ";
            dgvDataDH.Columns[3].HeaderText = " Ngày ĐH";
            dgvDataDH.Columns[4].HeaderText = " Ngày GH";
            dgvDataDH.Columns[5].HeaderText = "Thanh Toán";
            dgvDataDH.Columns[6].HeaderText = " Địa chỉ giao hàng ";
            dgvDataDH.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            foreach (DataGridViewColumn col in dgvDataDH.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void txtTimNhanVien_TextChanged(object sender, EventArgs e)
        {
            txtTimNhanVien.Text = "";
            txtTimNhanVien.ForeColor = Color.Black; // Đen
        }

        private void txtTimNhanVien_MouseClick(object sender, MouseEventArgs e)
        {
            txtTimNhanVien.Text = "";
            txtTimNhanVien.ForeColor = Color.Black; // Đen
        }

        private void txtTimDonHang_MouseClick(object sender, MouseEventArgs e)
        {
            txtTimDonHang.Text = "";
            txtTimDonHang.ForeColor = Color.Black; // Đen
        }

        private void txtTimKhachHang_MouseClick(object sender, MouseEventArgs e)
        {
            txtTimKhachHang.Text = "";
            txtTimKhachHang.ForeColor = Color.Black; // Đen
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            hienThiAllNhanVien();
        }

        public void hienThiAllNhanVien()
        {
            DataTable data = NhanVienBLL.layAllNhanVien();
            //dgvDataMH.Rows.Clear();
            dgvDataNV.DataSource = data;
            settingDgvNV();

        }

        public void settingDgvNV()
        {
            // Bỏ cột mặc định dataGridView
            dgvDataNV.RowHeadersVisible = false;
            // Thiết lập font đậm cho dòng header của DataGridView
            dgvDataNV.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 12, FontStyle.Bold);

            dgvDataNV.Columns[0].HeaderText = " Mã NV  ";
            dgvDataNV.Columns[1].HeaderText = "Họ tên";
            dgvDataNV.Columns[2].HeaderText = "Giới tính";
            dgvDataNV.Columns[3].HeaderText = "Ngày sinh";
            dgvDataNV.Columns[4].HeaderText = "Ngày nhận việc";
            dgvDataNV.Columns[5].HeaderText = "Điện thoại";
            dgvDataNV.Columns[6].HeaderText = "Lương";
            dgvDataNV.Columns[7].HeaderText = "Phụ cấp";
            dgvDataNV.Columns[8].HeaderText = "Địa chỉ";
            dgvDataNV.Columns[9].HeaderText = "Tài khoản";
            dgvDataNV.Columns[10].HeaderText = "Mật khẩu";

            dgvDataNV.Columns[6].DefaultCellStyle.Format = "N0";
            dgvDataNV.Columns[7].DefaultCellStyle.Format = "N0";

            foreach (DataGridViewColumn col in dgvDataNV.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            //dgvDataDH.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void btnNCC_Click(object sender, EventArgs e)
        {
            hienThiAllNhaCC();
        }
        public void hienThiAllNhaCC()
        {
            DataTable data = NhaCungCapBLL.layAllNhaCC();
            //dgvDataMH.Rows.Clear();
            dgvDataNCC.DataSource = data;
            settingDgvNCC();

        }

        private void settingDgvNCC()
        {
            // Bỏ cột mặc định dataGridView
            dgvDataNCC.RowHeadersVisible = false;
            // Thiết lập font đậm cho dòng header của DataGridView
            dgvDataNCC.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 12, FontStyle.Bold);

            dgvDataNCC.Columns[0].HeaderText = " Mã NCC ";
            dgvDataNCC.Columns[1].HeaderText = "Tên NCC";
            dgvDataNCC.Columns[2].HeaderText = "Địa chỉ";
            dgvDataNCC.Columns[3].HeaderText = "Điện thoại";
            dgvDataNCC.Columns[4].HeaderText = "Email";
            dgvDataNCC.Columns[5].HeaderText = "Người đại diện";

            foreach (DataGridViewColumn col in dgvDataNCC.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void txtTimNCC_MouseClick(object sender, MouseEventArgs e)
        {
            txtTimNCC.Text = "";
            txtTimNCC.ForeColor = Color.Black; // Đen
        }

        private void btnInNCC_Click(object sender, EventArgs e)
        {
            DoPrintNCC();
        }

        string GenHtmlFromDgvNCC()
        {
            //chuẩn bị trước chuỗi html để hiển thị
            //trang print: có sẵn cố định ko đổi: logo, tiêu đề
            string html = "<table border=1 align='center' class='border-thin'>"; //đây là nội dung se hiển thị
            //duyeetj dgv -> html
            int stt = 0;
            html += "<thead><tr>";
            html += $"<th>STT</th>";
            html += $"<th>Tên NCC</th>";
            html += $"<th>Địa chỉ</th>";
            html += $"<th>Điện thoại</th>";
            html += $"<th>Email</th>";
            html += $"<th>Người đại diện</th>";
            html += "</tr></thead>";
            html += "<tbody>";
            foreach (DataGridViewRow r in dgvDataNCC.Rows)
            {
                html += "<tr>";
                html += $"<td align=center>{++stt}</td>";
                html += $"<td>{r.Cells[1].Value}</td>";
                html += $"<td>{r.Cells[2].Value}</td>";
                html += $"<td>{r.Cells[3].Value}</td>";
                html += $"<td>{r.Cells[4].Value}</td>";
                html += $"<td>{r.Cells[5].Value}</td>";
                html += "</tr>";
            }
            html += "</tbody></table>";
            return html;
        }

        finGlobal finNCC;
        void DoPrintNCC()
        {
            string tieude_print;
            //chuẩn bị trước chuỗi html để hiển thị
            //trang print: có sẵn cố định ko đổi: logo, tiêu đề
            string html = GenHtmlFromDgvNCC();

            if (finNCC == null || finNCC.IsDisposed)
                finNCC = new finGlobal();

            tieude_print = txtPrintNCC.Text.ToUpper();
            if (tieude_print == null || tieude_print == "")
            {
                tieude_print = "-- THÔNG TIN --";
            }
            finNCC.ShowPrint(tieude_print, html); //bố truyền html sang để hiển thị sang
        }


        private void btnInDSNhanVien_Click(object sender, EventArgs e)
        {
            DoPrintNV();
        }

        void DoPrintNV()
        {
            string tieude_print;
            //chuẩn bị trước chuỗi html để hiển thị
            //trang print: có sẵn cố định ko đổi: logo, tiêu đề
            string html = GenHtmlFromDgvNV();

            if (finNCC == null || finNCC.IsDisposed)
                finNCC = new finGlobal();

            tieude_print = txtPrintNhanVien.Text.ToUpper();
            if (tieude_print == null || tieude_print == "")
            {
                tieude_print = "-- THÔNG TIN --";
            }
            finNCC.ShowPrint(tieude_print, html); //bố truyền html sang để hiển thị sang
        }
        string GenHtmlFromDgvNV()
        {
            //chuẩn bị trước chuỗi html để hiển thị
            //trang print: có sẵn cố định ko đổi: logo, tiêu đề
            string html = "<table border=1 align='center' class='border-thin'>"; //đây là nội dung se hiển thị
            //duyeetj dgv -> html
            int stt = 0;
            html += "<thead><tr>";
            html += $"<th>STT</th>";
            html += $"<th>Họ và tên</th>";
            html += $"<th>Giới tính</th>";
            html += $"<th>Ngày sinh</th>";
            html += $"<th>Điện thoại</th>";
            html += $"<th>Lương CB</th>";
            html += $"<th>Phụ cấp</th>";
            html += $"<th>Địa chỉ</th>";
            html += "</tr></thead>";
            html += "<tbody>";
            foreach (DataGridViewRow r in dgvDataNV.Rows)
            {
                html += "<tr>";
                html += $"<td align=center>{++stt}</td>";
                html += $"<td>{r.Cells[1].Value}</td>";   // họ tên
                html += $"<td text-align: center;>{r.Cells[2].Value}</td>"; // giới tính
                html += $"<td align=center>{DateTime.Parse(r.Cells[3].Value.ToString()).ToString("dd/MM/yyyy")}</td>";// ngày sinh
                html += $"<td>{r.Cells[5].Value}</td>"; // dienj thọai
                string temp = r.Cells[6].Value.ToString();
                string[] arr = temp.Split(',');
                int luongSO = Convert.ToInt32(arr[0]);
                string luong = string.Format("{0:#,###}", luongSO);
                html += $"<td>{luong}</td>";  // luong
                string temp2 = r.Cells[7].Value.ToString();
                string[] arr2 = temp2.Split(',');
                int pc_ = Convert.ToInt32(arr2[0]);
                string pc = string.Format("{0:#,###}", pc_);
                html += $"<td>{pc}</td>";  // phu cap
                html += $"<td>{r.Cells[8].Value}</td>"; // chia chi
                html += "</tr>";
            }
            html += "</tbody></table>";
            return html;
        }

        private void btnDSDonHang_Click(object sender, EventArgs e)
        {
            DoPrintDH();
        }

        public void DoPrintDH()
        {
            string tieude_print;
            //chuẩn bị trước chuỗi html để hiển thị
            //trang print: có sẵn cố định ko đổi: logo, tiêu đề
            string html = GenHtmlFromDgvDH();

            if (finNCC == null || finNCC.IsDisposed)
                finNCC = new finGlobal();

            tieude_print = txtDSDonHang.Text.ToUpper();
            if (tieude_print == null || tieude_print == "")
            {
                tieude_print = "-- THÔNG TIN --";
            }
            finNCC.ShowPrint(tieude_print, html); //bố truyền html sang để hiển thị sang
        }

        private string GenHtmlFromDgvDH()
        {
            //chuẩn bị trước chuỗi html để hiển thị
            //trang print: có sẵn cố định ko đổi: logo, tiêu đề
            string html = "<table border=1 align='center' class='border-thin'>"; //đây là nội dung se hiển thị
            //duyeetj dgv -> html
            int stt = 0;
            html += "<thead><tr>";
            html += $"<th>STT</th>";
            html += $"<th>Số đơn hàng</th>";
            html += $"<th>Mã KH</th>";
            html += $"<th>Mã NV</th>";
            html += $"<th>Ngày đặt</th>";
            html += $"<th>Ngày giao</th>";
            html += $"<th>Thanh toán</th>";
            html += $"<th>Địa chỉ giao hàng</th>";
            html += "</tr></thead>";
            html += "<tbody>";
            foreach (DataGridViewRow r in dgvDataDH.Rows)
            {
                html += "<tr>";
                html += $"<td align=center>{++stt}</td>";
                html += $"<td>{r.Cells[0].Value}</td>";
                html += $"<td>{r.Cells[1].Value}</td>";
                html += $"<td>{r.Cells[2].Value}</td>";
                html += $"<td align=center>{DateTime.Parse(r.Cells[3].Value.ToString()).ToString("dd/MM/yyyy")}</td>";
                html += $"<td align=center>{DateTime.Parse(r.Cells[4].Value.ToString()).ToString("dd/MM/yyyy")}</td>";
                html += $"<td>{r.Cells[5].Value}</td>";
                html += $"<td>{r.Cells[6].Value}</td>";
                html += "</tr>";
            }
            html += "</tbody></table>";
            return html;
        }

        Dictionary<string, string> dicLoaiHang;
        private void btnIn_Click(object sender, EventArgs e)
        {
            DoPrintMH();
        }

        public Dictionary<string, string> layDicLoaiHang()
        {
            string query = "select * from LoaiHang;";

            using (SqlConnection sqlCon = new SqlConnection(strCon))
            {
                try
                {
                    Dictionary<string, string> dicLoaiHang = new Dictionary<string, string>();
                    sqlCon.Open();

                    // Thực hiện các câu truy vấn và xử lý dữ liệu
                    SqlCommand cmd = sqlCon.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = query;

                    SqlDataReader sdr = cmd.ExecuteReader();
                    // Tạo đối tượng DataTable để lưu trữ dữ liệu trả về
                    while (sdr.Read())
                    {
                        string key = sdr.GetString(0);
                        string value = sdr.GetString(1);
                        dicLoaiHang.Add(key, value);
                    }
                    return dicLoaiHang;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    return null;
                }

            }
        }

        public void DoPrintMH()
        {
            string tieude_print;
            //chuẩn bị trước chuỗi html để hiển thị
            //trang print: có sẵn cố định ko đổi: logo, tiêu đề
            string html = GenHtmlFromDgvMH();

            if (finNCC == null || finNCC.IsDisposed)
                finNCC = new finGlobal();

            tieude_print = txtMatHang.Text.ToUpper();
            if (tieude_print == null || tieude_print == "")
            {
                tieude_print = "-- THÔNG TIN --";
            }
            finNCC.ShowPrint(tieude_print, html); //bố truyền html sang để hiển thị sang
        }

        public string GenHtmlFromDgvMH()
        {
            //chuẩn bị trước chuỗi html để hiển thị
            //trang print: có sẵn cố định ko đổi: logo, tiêu đề
            string html = "<table border=1 align='center' class='border-thin'>"; //đây là nội dung se hiển thị
            //duyeetj dgv -> html
            int stt = 0;
            html += "<thead><tr>";
            html += $"<th>STT</th>";
            html += $"<th>Mã hàng</th>";
            html += $"<th>Tên hàng</th>";
            html += $"<th>Mã NCC</th>";
            html += $"<th>Mã LH</th>";
            html += $"<th>Số lượng</th>";
            html += $"<th>ĐV tính</th>";
            html += $"<th>Giá nhập</th>";
            html += $"<th>Giá bán</th>";
            html += "</tr></thead>";
            html += "<tbody>";
            foreach (DataGridViewRow r in dgvDataMH.Rows)
            {
                html += "<tr>";
                html += $"<td align=center>{++stt}</td>";
                html += $"<td>{r.Cells[0].Value}</td>";
                html += $"<td>{r.Cells[1].Value}</td>";
                html += $"<td>{r.Cells[2].Value}</td>";
                html += $"<td>{r.Cells[3].Value}</td>";
                html += $"<td>{r.Cells[4].Value}</td>";
                html += $"<td>{r.Cells[5].Value}</td>";
                string temp = r.Cells[6].Value.ToString();
                string[] arr = temp.Split(',');
                int giaNhap = Convert.ToInt32(arr[0]);
                string gia = string.Format("{0:#,###}", giaNhap);
                html += $"<td>{gia}</td>";
                string temp2 = r.Cells[7].Value.ToString();
                string[] arr2 = temp2.Split(',');
                int giaBan = Convert.ToInt32(arr2[0]);
                string giab = string.Format("{0:#,###}", giaBan);
                html += $"<td>{giab}</td>";
                html += "</tr>";
            }
            html += "</tbody></table>";
            return html;
        }

        private void btnInDSKhachHang_Click(object sender, EventArgs e)
        {
            DoPrintKH();
        }

        public void DoPrintKH()
        {
            string tieude_print;
            //chuẩn bị trước chuỗi html để hiển thị
            //trang print: có sẵn cố định ko đổi: logo, tiêu đề
            string html = GenHtmlFromDgvKH();

            if (finNCC == null || finNCC.IsDisposed)
                finNCC = new finGlobal();

            tieude_print = txtKhachHang.Text.ToUpper();
            if (tieude_print == null || tieude_print == "")
            {
                tieude_print = "-- THÔNG TIN --";
            }
            finNCC.ShowPrint(tieude_print, html); //bố truyền html sang để hiển thị sang
        }

        public string GenHtmlFromDgvKH()
        {
            //chuẩn bị trước chuỗi html để hiển thị
            //trang print: có sẵn cố định ko đổi: logo, tiêu đề
            string html = "<table border=1 align='center' class='border-thin'>"; //đây là nội dung se hiển thị
            //duyeetj dgv -> html
            int stt = 0;
            html += "<thead><tr>";
            html += $"<th>STT</th>";
            html += $"<th>Tên KH</th>";
            html += $"<th>Giới tính</th>";
            html += $"<th>Tên CTy</th>";
            html += $"<th>Điện thoại</th>";
            html += $"<th>Email</th>";
            html += $"<th>Địa chỉ</th>";
            html += "</tr></thead>";
            html += "<tbody>";
            foreach (DataGridViewRow r in dgvDataKH.Rows)
            {
                html += "<tr>";
                html += $"<td align=center>{++stt}</td>";
                html += $"<td>{r.Cells[1].Value}</td>";
                html += $"<td>{r.Cells[2].Value}</td>";
                html += $"<td>{r.Cells[3].Value}</td>";
                html += $"<td>{r.Cells[6].Value}</td>";
                html += $"<td>{r.Cells[5].Value}</td>";
                html += $"<td>{r.Cells[4].Value}</td>";
                html += "</tr>";
            }
            html += "</tbody></table>";
            return html;
        }
    }
}
