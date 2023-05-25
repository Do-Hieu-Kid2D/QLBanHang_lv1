using BLL;
using DTO;
using Project_CSDLBanHang;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
// Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Server;
using System.IO;
using static System.Net.WebRequestMethods;
using System.ComponentModel;

namespace GUI
{
    public partial class formQuanLy : Form
    {
        string strCon = Properties.Settings.Default.strCon;
        formDangNhap fDN;
        List<string> listFileBackup = new List<string>();
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
            setUpRestore();
            loadTrangThaiDB();
            panel31.BackColor = Color.Transparent;
            panel31.BackColor = Color.FromArgb(70, Color.White);
        }
        private void txtTimKiem_MouseClick(object sender, MouseEventArgs e)
        {
            txtTimMatHang.Text = "";
            txtTimMatHang.ForeColor = Color.Black; // Đen
        }

        private void formQuanLy_Load(object sender, EventArgs e)
        {
            loadAllBang();
        }

        private void loadAllBang()
        {
            hienThiALLMatHang("");
            hienThiALLKhachHang("");
            hienThiAllDonHang("");
            hienThiAllNhanVien();
            hienThiAllNhaCC("");
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

        public void hienThiALLMatHang(string dk)
        {
            DataTable data = MatHangBLL.layALLMatHang(dk);
            if (data.Rows.Count == 0)
            {
                MessageBox.Show("Không có bản ghi nào phù hợp!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //dgvDataMH.Rows.Clear();
            dgvDataMH.DataSource = data;
            dgvDataMH.Rows[0].Selected = false;
            settingDgvMH();
        }

        public void btnALlHang_Click(object sender, EventArgs e)
        {
            hienThiALLMatHang("");
        }

        private void btnAllKhachHang_Click(object sender, EventArgs e)
        {
            hienThiALLKhachHang("");
        }

        public void hienThiALLKhachHang(string dk)
        {
            DataTable data = KhachHangBLL.layALLKhachHang(dk);
            if (data.Rows.Count == 0)
            {
                MessageBox.Show("Không có bản ghi nào phù hợp!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //dgvDataMH.Rows.Clear();
            dgvDataKH.DataSource = data;
            dgvDataKH.Rows[0].Selected = false;
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
            hienThiAllDonHang("");
        }

        public void hienThiAllDonHang(string dk)
        {
            DataTable data = DonHangBLL.layALLDonHang(dk);
            //dgvDataMH.Rows.Clear();
            if (data.Rows.Count == 0)
            {
                MessageBox.Show("Không có bản ghi nào phù hợp!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            dgvDataDH.DataSource = data;
            dgvDataDH.Rows[0].Selected = false;
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
            if (data.Rows.Count == 0)
            {
                MessageBox.Show("Không có bản ghi nào phù hợp!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            dgvDataNV.DataSource = data;
            dgvDataNV.Rows[0].Selected = false;
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
            hienThiAllNhaCC("");
        }
        public void hienThiAllNhaCC(string dk)
        {
            DataTable data = NhaCungCapBLL.layAllNhaCC(dk);
            //dgvDataMH.Rows.Clear();
            if (data.Rows.Count == 0)
            {
                MessageBox.Show("Không có bản ghi nào phù hợp!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            dgvDataNCC.DataSource = data;
            dgvDataNCC.Rows[0].Selected = false;
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

        private void btnTim_Click(object sender, EventArgs e)
        {
            hienThiALLMatHang(txtTimMatHang.Text.Trim());
        }

        private void btnTimKiemKhachHang_Click(object sender, EventArgs e)
        {
            hienThiALLKhachHang(txtTimKhachHang.Text.Trim());
        }

        private void btnTKDonHang_Click(object sender, EventArgs e)
        {
            hienThiAllDonHang(txtTimDonHang.Text.Trim());
        }

        private void btnTimNCC_Click(object sender, EventArgs e)
        {
            hienThiAllNhaCC(txtTimNCC.Text.Trim());
        }

        private void btnXoaNCC_Click_1(object sender, EventArgs e)
        {
            if (dgvDataNCC.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Cần chọn đối tượng muốn xóa trên bảng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult chon = MessageBox.Show("Bạn chắc chắn muốn xóa Nhà cung cấp này?", "Thông báo!", MessageBoxButtons.YesNo,
            MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (chon == DialogResult.Yes)
            {
                if (XoaNCC() == 1)
                {
                    MessageBox.Show("Đã xóa Nhà cung cấp!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    hienThiAllNhaCC("");
                }
                else
                {
                    MessageBox.Show("Chưa xóa Nhà cung cấp!");
                }
            }
        }
        private int XoaNCC()
        {
            string maNCCXoa = layMaNCCDangChon();
            return NhaCungCapBLL.xoaNCC(maNCCXoa);
        }
        string layMaNCCDangChon()
        {

            if (dgvDataNCC.SelectedRows.Count > 0)
            {
                string maNCC = (string)(dgvDataNCC.SelectedRows[0].Cells[0].Value);
                return maNCC;
            }
            return null;
        }

        private void btnXoaNhanVien_Click(object sender, EventArgs e)
        {
            if (dgvDataNV.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Cần chọn đối tượng muốn xóa trên bảng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult chon = MessageBox.Show("Bạn chắc chắn muốn xóa Nhân viên này?", "Thông báo!", MessageBoxButtons.YesNo,
            MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (chon == DialogResult.Yes)
            {
                if (XoaNV() == 1)
                {
                    MessageBox.Show("Đã xóa Nhân viên!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    hienThiAllNhanVien();
                }
                else
                {
                    MessageBox.Show("Chưa xóa Nhân viên!");
                }
            }
        }

        private int XoaNV()
        {
            string maNVXoa = layMaNVDangChon();
            return NhanVienBLL.xoaNV(maNVXoa);
        }

        private string layMaNVDangChon()
        {

            if (dgvDataNV.SelectedRows.Count > 0)
            {
                string maNV = (string)(dgvDataNV.SelectedRows[0].Cells[0].Value);
                return maNV;
            }
            return null;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvDataMH.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Cần chọn đối tượng muốn xóa trên bảng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult chon = MessageBox.Show("Bạn chắc chắn muốn xóa Mặt hàng này?", "Thông báo!", MessageBoxButtons.YesNo,
            MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (chon == DialogResult.Yes)
            {
                if (XoaMH() == 1)
                {
                    MessageBox.Show("Đã xóa Mặt hàng!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    hienThiALLMatHang("");
                }
                else
                {
                    MessageBox.Show("Chưa xóa Mặt hàng!");
                }
            }
        }

        private int XoaMH()
        {
            string maMHXoa = layMaMHDangChon();
            return MatHangBLL.xoaMH(maMHXoa);
        }

        private string layMaMHDangChon()
        {
            if (dgvDataMH.SelectedRows.Count > 0)
            {
                string maMH = (string)(dgvDataMH.SelectedRows[0].Cells[0].Value);
                return maMH;
            }
            return null;
        }

        private void btnXoaKhachHang_Click(object sender, EventArgs e)
        {
            if (dgvDataKH.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Cần chọn đối tượng muốn xóa trên bảng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult chon = MessageBox.Show("Bạn chắc chắn muốn xóa Khách hàng này?", "Thông báo!", MessageBoxButtons.YesNo,
            MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (chon == DialogResult.Yes)
            {
                if (XoaKH() == 1)
                {
                    MessageBox.Show("Đã xóa Khách hàng!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    hienThiALLKhachHang("");
                }
                else
                {
                    MessageBox.Show("Chưa xóa Khách hàng!");
                }
            }
        }

        private int XoaDH()
        {
            string maDHXoa = layMaDHDangChon();
            return DonHangBLL.xoaDH(maDHXoa);
        }

        private string layMaDHDangChon()
        {
            return dgvDataDH.SelectedRows[0].Cells[0].Value.ToString();
        }

        private int XoaKH()
        {
            string maKHXoa = layMaKHDangChon();
            return KhachHangBLL.xoaKH(maKHXoa);
        }

        private string layMaKHDangChon()
        {
            return dgvDataKH.SelectedRows[0].Cells[0].Value.ToString();
        }

        private void btnXoaDonHang_Click(object sender, EventArgs e)
        {
            if (dgvDataDH.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Cần chọn đối tượng muốn xóa trên bảng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult chon = MessageBox.Show("Bạn chắc chắn muốn xóa Đơn hàng này?", "Thông báo!", MessageBoxButtons.YesNo,
            MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (chon == DialogResult.Yes)
            {
                if (XoaDH() == 1)
                {
                    MessageBox.Show("Đã xóa Đơn hàng!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    hienThiAllDonHang("");
                }
                else
                {
                    MessageBox.Show("Chưa xóa Đơn hàng!");
                }
            }
        }

        private void btnHoZo_Click(object sender, EventArgs e)
        {
            PlaySound.playNeedText(txtHoZo.Text);

        }

        private void btnChiTietHTTT_Click(object sender, EventArgs e)
        {
            fChiTietHTTT f = new fChiTietHTTT(this);
            f.ShowDialog();

        }

        private void btnCacLoaiHang_Click(object sender, EventArgs e)
        {
            fLoaiHang f = new fLoaiHang(this);
            f.ShowDialog();
        }

        private void btnSuaDonHang_Click(object sender, EventArgs e)
        {
            DonHangDTO dhCu = getDHDataDGV();
            if (dhCu == null) return;
            fAEDonHang = new fAddEditDonHang(this, "EDIT", dhCu);
            fAEDonHang.ShowDialog();
        }

        private DonHangDTO getDHDataDGV()
        {
            if (dgvDataDH.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Bạn phải chọn đối tượng muốn chỉnh sửa trên bảng!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            DataGridViewRow dtr = dgvDataDH.SelectedRows[0];

            string soHD = dtr.Cells[0].Value.ToString();
            string maKH = dtr.Cells[1].Value.ToString();
            string maNv = dtr.Cells[2].Value.ToString();
            string datHang_S = dtr.Cells[3].Value.ToString();
            string giaoHang_S = dtr.Cells[4].Value.ToString();
            // Hàm chuyển kia chuyển về ngon mà:
            // cho 1 chuỗi string trên dgv thì nó chuyển về datetime - còn nếu 
            // lấy value từ datepicker thì nó là datetime sẵn r
            DateTime datHang = chuyenStrToDatime(datHang_S);
            DateTime giaoHang = chuyenStrToDatime(giaoHang_S);
            //MessageBox.Show(datHang_S);
            //MessageBox.Show(datHang.ToString("dd/mm/yyyy"));
            string diaChiGiaoHang = dtr.Cells[6].Value.ToString();
            string maHTTT = dtr.Cells[5].Value.ToString();
            return new DonHangDTO(soHD, maKH, maNv, datHang, giaoHang, diaChiGiaoHang, maHTTT);
        }

        private DateTime chuyenStrToDatime(string txtDate)
        {
            try
            {
                if (txtDate == null || txtDate == "")
                    return DateTime.Now;
                else
                    return
                         DateTime.Parse(txtDate);
            }
            catch
            {
                return DateTime.Now;
            }
        }

        fAddEditDonHang fAEDonHang;
        private void btnThemDonHang_Click(object sender, EventArgs e)
        {
            fAEDonHang = new fAddEditDonHang(this, "ADD", new DonHangDTO());
            fAEDonHang.ShowDialog();
        }

        fEditAddMatHang fAEMatHang;
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvDataMH.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Cần chọn đối tượng muốn chỉnh sửa trên bảng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DataGridViewRow selectedRow = dgvDataMH.SelectedRows[0];
            // Lấy giá trị của các ô dữ liệu trong hàng đó
            string maH = selectedRow.Cells[0].Value.ToString();
            string tenH = selectedRow.Cells[1].Value.ToString();
            string maNCC = selectedRow.Cells[2].Value.ToString();
            string maLH = selectedRow.Cells[3].Value.ToString();
            int soLuong = Convert.ToInt32(selectedRow.Cells[4].Value.ToString());
            string dvTinh = selectedRow.Cells[5].Value.ToString();
            decimal giaNhap = Convert.ToDecimal(selectedRow.Cells[6].Value.ToString());
            decimal giaBan = Convert.ToDecimal(selectedRow.Cells[7].Value.ToString());
            string hinhAnh = selectedRow.Cells[8].Value.ToString();
            MatHangDTO mh = new MatHangDTO(maH, tenH, maNCC, maLH, soLuong, dvTinh, giaNhap, giaBan, hinhAnh);
            fAEMatHang = new fEditAddMatHang(this, "edit", mh);
            fAEMatHang.ShowDialog();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            fAEMatHang = new fEditAddMatHang(this, "add", new MatHangDTO());
            fAEMatHang.ShowDialog();
        }
        //MatHangDTO matHangThem;
        public string them1MatHang(MatHangDTO matHang)
        {
            return MatHangBLL.them1MatHang(matHang);

        }

        private void txtTimMatHang_MouseClick(object sender, MouseEventArgs e)
        {
            txtTimMatHang.Text = "";
            txtTimMatHang.ForeColor = Color.Black; // Đen
        }

        private void btnTim_Click_1(object sender, EventArgs e)
        {
            hienThiALLMatHang(txtTimMatHang.Text.Trim());
        }
        fAddEditKhachHang fAEKhachHang;
        private void btnThemKhachHang_Click(object sender, EventArgs e)
        {
            fAEKhachHang = new fAddEditKhachHang(this, "ADD", new KhachHangDTO());
            fAEKhachHang.ShowDialog();
        }

        private KhachHangDTO getKhachHangDGV()
        {

            if (dgvDataKH.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Bạn cần chọn đối tượng muốn chỉnh sửa trên bảng!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            DataGridViewRow selectedRow = dgvDataKH.SelectedRows[0];
            // Lấy giá trị của các ô dữ liệu trong hàng đó
            String maKh = selectedRow.Cells[0].Value.ToString();
            string tenKH = selectedRow.Cells[1].Value.ToString();
            Boolean gioiTinh;
            if (selectedRow.Cells[2].Value.ToString() == "Nam")
                gioiTinh = true;
            else
                gioiTinh = false;
            string tenCT = selectedRow.Cells[3].Value.ToString();
            string diaChi = selectedRow.Cells[4].Value.ToString();
            string Email = selectedRow.Cells[5].Value.ToString();
            string sdt = selectedRow.Cells[6].Value.ToString();
            KhachHangDTO kq = new KhachHangDTO(maKh, tenKH, gioiTinh, tenCT, diaChi, Email, sdt);
            return kq;
        }

        internal string them1KhachHang(KhachHangDTO khCanThem)
        {
            return KhachHangBLL.them1KhachHang(khCanThem);
        }

        private void btnDangXuat_Click_1(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn đăng xuất không?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)
            {
                fDN.Show();
                this.Close();
            }
        }

        private void btnSuaKhachHang_Click(object sender, EventArgs e)
        {
            KhachHangDTO kh = getKhachHangDGV();
            if (kh == null) return;
            fAEKhachHang = new fAddEditKhachHang(this, "EDIT", kh);
            fAEKhachHang.ShowDialog();
        }

        internal string sua1KhachHang(KhachHangDTO khMoi, KhachHangDTO khCu)
        {
            return KhachHangBLL.sua1KhachHang(khMoi, khCu);
        }

        internal string them1DonHang(DonHangDTO donhangMoi)
        {
            return DonHangBLL.them1DonHang(donhangMoi);
        }

        internal string sua1DonHang(DonHangDTO dhMoi, DonHangDTO dhCu)
        {
            return DonHangBLL.sua1DonHang(dhMoi, dhCu);
        }

        private void btnChiTiet_Click(object sender, EventArgs e)
        {
            string soDH = "";
            if (dgvDataDH.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Bạn cần chọn đơn hàng muốn xem chi tiết trên bảng", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DataGridViewRow viewRow = dgvDataDH.SelectedRows[0];
            soDH = viewRow.Cells[0].Value.ToString();
            fViewDonHang f = new fViewDonHang(soDH);
            f.ShowDialog();
        }
        fAddEditNhaCC fAENCC;
        private void btnThemNCC_Click(object sender, EventArgs e)
        {
            fAENCC = new fAddEditNhaCC(this, "ADD", new NhaCungCapDTO());
            fAENCC.ShowDialog();

        }

        private void btnSuaNCC_Click(object sender, EventArgs e)
        {
            NhaCungCapDTO nccSua = layThongTinDGV();
            if (nccSua == null) return;
            fAENCC = new fAddEditNhaCC(this, "EDIT", nccSua);
            fAENCC.ShowDialog();
        }

        private NhaCungCapDTO layThongTinDGV()
        {
            if (dgvDataNCC.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Bạn phải chọn đối tượng muốn chỉnh sửa trên bảng!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            DataGridViewRow dtr = dgvDataNCC.SelectedRows[0];

            string ma = dtr.Cells[0].Value.ToString();
            string ten = dtr.Cells[1].Value.ToString();
            string diaChi = dtr.Cells[2].Value.ToString();
            string dienThoai = dtr.Cells[3].Value.ToString();
            string email = dtr.Cells[4].Value.ToString();
            string nguoiDaiDien = dtr.Cells[5].Value.ToString();
            return new NhaCungCapDTO(ma, ten, diaChi, dienThoai, email, nguoiDaiDien);
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/Do-Hieu-Kid2D/QLBanHang_lv1");
        }

        public void loadTrangThaiDB()
        {
            // Đầu tiên lấy data về đã:
            SqlServer libDB = new SqlServer(strCon);
            string query = "THONG_KE_TONG";
            SqlCommand cm = libDB.GetCmd(query);
            DataTable data = new DataTable();
            try
            {
               data =  libDB.Query(cm);
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message); return;
            }
            txtTongMH.Text = data.Rows[0][0].ToString();
            txtTongKH.Text = data.Rows[0][1].ToString();
            txtSLDonHang.Text = data.Rows[0][2].ToString();
            txtSLNhanVien.Text =data.Rows[0][3].ToString();
            txtSLNhaCC.Text =data.Rows[0][4].ToString();
        }

        private void btnLuuLai_Click(object sender, EventArgs e)
        {
            // Tạo nơi chứa thư mục backup đã!
            string pathBackUp = Application.StartupPath + "\\backup\\";
            // Kiểm tra xem thư mục đã tồn tại hay chưa
            if (!Directory.Exists(pathBackUp))
                // Tạo thư mục mới
                Directory.CreateDirectory(pathBackUp);
            // Lấy tên file bak <-> ngày hiện tại! 
            DateTime currentDate = DateTime.Now;
            string day = currentDate.Day.ToString();
            string month = currentDate.Month.ToString();
            string year = currentDate.Year.ToString();
            string bienx = day + "/" + month + "/" + year;
            string tenFileBAK = day + "_" + month + "_" + year + ".bak";
            string duongdanBackup = pathBackUp + tenFileBAK;

            //if (!File.Exists(duongdanBackup))
            //    File.Create(duongdanBackup).Close();
            try
            {
                // Tạo chuỗi query!
                string tenDB = "BanHanglv1";
                string query = $"BACKUP DATABASE {tenDB} TO DISK = '{duongdanBackup}' WITH INIT, FORMAT;";
                // oke backup lại thôi
                SqlServer libDB = new SqlServer(strCon);
                SqlCommand cmd = libDB.GetCmdSQLChay(query);
                int kq = libDB.QueryNon(cmd);
                MessageBox.Show($"Đã lưu lại trạng thái CSDL ngày: {bienx}.", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //listFileBackup.Add("Ngày: " + bienx);
                //listBox1.Items.Add("Ngày: " + bienx);
                setUpRestore();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "    -> Chưa backup được!", "Thông báo!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void btnPhucHoi_Click(object sender, EventArgs e)
        {
            string pathBackUp = Application.StartupPath + "\\backup";
            // chọn được file bak muốn backup! ở listBox mk đã setup rồi!
            string fileDuocChon = chonFile();
            if (fileDuocChon == null)
            {
                MessageBox.Show("Bạn chưa chọn thời gian muốn khôi phục CSDL!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Có đc tên file bacup dang: Ngày: dd//mm/yyy:
            string fileChonDeBackUp = fileDuocChon.Substring(6);
            string bienx = fileChonDeBackUp;
            fileChonDeBackUp = fileChonDeBackUp.Replace('/', '_');
            // Đường dẫn để backup đây
            string duongDanBackUp = pathBackUp + "\\" + fileChonDeBackUp + ".bak";
            Console.WriteLine("Cuối cùng =>" + duongDanBackUp);
            // Lấy được file backup rồi hỏi xem chắc chắn k?
            DialogResult chanChan = MessageBox.Show($"Bạn chắc chắn muốn phục hồi CSDL về ngày: {fileChonDeBackUp}", "Thông báo!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (chanChan == DialogResult.OK)
            {
                try
                {
                    // Oke backup thôi
                    SqlServer libDB = new SqlServer(strCon); // sử dụng Thư viện anh Cốp viết
                    string tenDB = "BanHanglv1";
                    string query = $"use master" +
                        $" ALTER DATABASE {tenDB} SET SINGLE_USER WITH ROLLBACK IMMEDIATE;" +
                        $" RESTORE DATABASE {tenDB} FROM DISK = '{duongDanBackUp}' WITH REPLACE;";
                    SqlCommand cmd = libDB.GetCmdSQLChay(query);
                    int kq = libDB.QueryNon(cmd);
                    MessageBox.Show($"Đã khôi phục CSDL về trạng thái ngày: {bienx}.", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                    Refresh_Click(sender, e);
                   

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + " Chưa khôi phục đc rồi -> lỗi này chưa fix", "Thông báo!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                listBox1.SelectedIndex = -1;
                return;
            }

        }


        private string chonFile()
        {
            if (listBox1.SelectedIndex == -1) return null;
            string selectedItem = listBox1.SelectedItem.ToString();
            return selectedItem;
        }

        private void setUpRestore()
        {

            //string pathBackUp = @"C:\Users\Dkid_22\Desktop\NGHE";
            string pathBackUp = Application.StartupPath + "\\backup";

            // Lấy danh sách các file trong thư mục
            string[] files = Directory.GetFiles(pathBackUp);
            listBox1.Items.Clear();
            foreach (string filePath in files)
            {
                // Lấy ra tên file:
                string fileName = Path.GetFileName(filePath);
                string[] arr = fileName.Split('.');
                string tenFile = arr[0];
                //Console.WriteLine(tenFile);
                // Đã có tên file là dd_mm_yyyy -> giờ replace -> hiển thị cho nười ta chọn!
                tenFile = tenFile.Replace('_', '/');
                tenFile = "Ngày: " + tenFile;
                listBox1.Items.Add(tenFile);
                Console.WriteLine(tenFile);
            }
            listBox1.SelectedIndex = -1;

        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            loadTrangThaiDB();
            loadAllBang();
        }
        int a = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
           
            if(a== 0)
            {
                picThangHieu.BackgroundImage = global::GUI.Properties.Resources.dfd8dabcc3d01a8e43c1;
                a++;
                return;
            }
            if (a == 1)
            {
                picThangHieu.BackgroundImage = global::GUI.Properties.Resources._1fe739a32dcff491adde;
                a++;
                return;
            }
            if (a == 2)
            {
                picThangHieu.BackgroundImage = global::GUI.Properties.Resources._50bbfcb39552530c0a43;
                a = 0;
                return;
            }
        }
    }
}


