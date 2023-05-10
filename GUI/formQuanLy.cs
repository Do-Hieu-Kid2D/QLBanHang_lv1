using BLL;
using Project_CSDLBanHang;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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
            this.Size = new Size(1010, 600);
            txtTimKiem.ForeColor = Color.Gray; // Màu xám

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
            txtTimKiem.Text = "";
            txtTimKiem.ForeColor = Color.Black; // Màu xám
        }

        private void formQuanLy_Load(object sender, EventArgs e)
        {
        //    hienThiALLMatHang();
        //    settingDgv();
        }

        public void settingDgv()
        {
            //try
            //{
            //    int index = dgvData.FirstDisplayedScrollingRowIndex;
            //    int selected_index = -1;
            //    //string masv_selected = "";
            //    // Không cho phép thay đổi kích thước khi chạy CT
            //    dgvData.AllowUserToResizeColumns = false;
            //    dgvData.AllowUserToResizeRows = false;
            //    // Bỏ cột mặc định dataGridView
            //    dgvData.RowHeadersVisible = false;
            //    // đặt chiều cao của từng hàng là 50
            //    dgvData.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            //    dgvData.RowTemplate.Height = 50;

            //    if (dgvData.SelectedRows.Count > 0)
            //    {
            //        selected_index = dgvData.SelectedRows[0].Index;
            //        //masv_selected = dgvData.SelectedRows[0].Cells[0].Value.ToString();
            //    }
            //    dgvData.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            //    dgvData.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            //    dgvData.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            //    dgvData.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            //    dgvData.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            //    dgvData.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            //    dgvData.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            //    dgvData.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            //    dgvData.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            //    dgvData.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //    dgvData.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //    dgvData.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //    dgvData.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //    dgvData.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //    dgvData.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //    dgvData.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //    dgvData.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //    Font fHeader = new Font("Tahoma", 10F, FontStyle.Bold, GraphicsUnit.Point);
            //    dgvData.Columns[0].HeaderText = "Mã hàng";
            //    dgvData.Columns[1].HeaderText = "Tên hàng";
            //    dgvData.Columns[2].HeaderText = "Mã NCC";
            //    dgvData.Columns[3].HeaderText = "Mã LH";
            //    dgvData.Columns[4].HeaderText = "Số lượng";
            //    dgvData.Columns[5].HeaderText = "ĐV tính";
            //    dgvData.Columns[6].HeaderText = "Giá nhập";
            //    dgvData.Columns[7].HeaderText = "Giá bán";
            //    dgvData.Columns[8].HeaderText = "Hình ảnh";

            //    dgvData.Columns[0].HeaderCell.Style.Font = fHeader;
            //    dgvData.Columns[1].HeaderCell.Style.Font = fHeader;
            //    dgvData.Columns[2].HeaderCell.Style.Font = fHeader;
            //    dgvData.Columns[3].HeaderCell.Style.Font = fHeader;
            //    dgvData.Columns[4].HeaderCell.Style.Font = fHeader;
            //    dgvData.Columns[5].HeaderCell.Style.Font = fHeader;
            //    dgvData.Columns[6].HeaderCell.Style.Font = fHeader;
            //    dgvData.Columns[7].HeaderCell.Style.Font = fHeader;
            //    dgvData.Columns[8].HeaderCell.Style.Font = fHeader;

            //    dgvData.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //    dgvData.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //    dgvData.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //    dgvData.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //    dgvData.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //    dgvData.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //    dgvData.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //    dgvData.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //    dgvData.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //    if (index >= 0 && index < dgvData.Rows.Count)
            //        dgvData.FirstDisplayedScrollingRowIndex = index;

                //if (selected_index >= 0 && selected_index < dgvData.Rows.Count)
                //{
                //    dgvData.Rows[selected_index].Selected = true;
                //    foreach (DataGridViewRow dr in dgvData.Rows)
                //    {
                //        if (dr.Cells[0].Value.ToString() == masv_selected)
                //        {
                //            dr.Selected = true;
                //            break;
                //        }
                //    }
                //}
            //}
            //catch { }

        }

        public void hienThiALLMatHang()
        {
            DataTable data = MatHangBLL.layALLMatHang();
            dgvDataMH.DataSource = data;
        }

        private void btnALlHang_Click(object sender, EventArgs e)
        {
            hienThiALLMatHang();
        }
    }
}
