using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GUI
{
    public partial class fAddEditDonHang : Form
    {
        formQuanLy fQL;
        string command;
        string maNV = "";
        string maKH = "";
        string maHTTT = "";
        string soHD = "";
        string diaChiGiaoHang = "";
        DateTime datHang;
        DateTime giaoHang;
        DonHangDTO dhCu;
        DonHangDTO dhMoi;
        DataTable dataHTTT = new DataTable();
        public fAddEditDonHang(formQuanLy fQL, string command, DonHangDTO dh)
        {
            InitializeComponent();
            cbxMaKH.Font = new Font("Arial", 10);
            cbxMaNV.Font = new Font("Arial", 10);
            cbxThanhToan.Font = new Font("Arial", 10);
            loaDatacbxMaKH();
            loaDatacbxMaNV();
            loaDatacbxThanhToan();
            this.fQL = fQL;
            this.command = command;
            this.StartPosition = FormStartPosition.CenterParent;
            this.dhCu = dh;
            settingTxt();
        }

        private void settingTxt()
        {
            if (command == "ADD")
            {
                labTitle.Text = "--    THÊM ĐƠN HÀNG    --";
                btnCommand.Text = "Thêm";
            }
            else
            {
                //loadThongTinCanSua();
                labTitle.Text = "--    SỬA ĐƠN HÀNG    --";
                btnCommand.Text = "Sửa";
                duaDuLieuLenForm();
            }
        }

        private void loaDatacbxThanhToan()
        {
            
            try
            {
                string strCon = Properties.Settings.Default.strCon;
                // câu lệnh mk mu
                string query = "select * from THANHTOAN;";


                SqlConnection sqlCon = new SqlConnection(strCon);
                sqlCon.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlCon;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = query;

                SqlDataReader reader = cmd.ExecuteReader();
                dataHTTT.Load(reader);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            //cbxMaNV.Items.Clear();
            cbxThanhToan.DataSource = dataHTTT;
            cbxThanhToan.ValueMember = "mahinhThucThanhToan";
            cbxThanhToan.DisplayMember = "tenhinhThucThanhToan";
            cbxThanhToan.SelectedIndex = -1;

        }

        private void loaDatacbxMaNV()
        {
            DataTable data = NhanVienBLL.layAllNhanVien();
            //cbxMaNV.Items.Clear();
            cbxMaNV.DataSource = data;
            cbxMaNV.ValueMember = "maNhanVien";
            cbxMaNV.DisplayMember = "maNhanVien";
            cbxMaNV.SelectedIndex = -1;

        }

        private void loaDatacbxMaKH()
        {
            DataTable data = KhachHangBLL.layALLKhachHang("");
            //cbxMaKH.Items.Clear();
            cbxMaKH.DataSource = data;
            cbxMaKH.ValueMember = "maKhachHang";
            cbxMaKH.DisplayMember = "maKhachHang";
            // Setting để có thể nhập chữ vào tìm kiếm ở combox!
            cbxMaKH.DropDownStyle = ComboBoxStyle.DropDown;
            cbxMaKH.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbxMaKH.AutoCompleteSource = AutoCompleteSource.ListItems;
            cbxMaKH.SelectedIndex = -1;
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void layThongTinForm()
        {
            if (cbxMaKH.SelectedIndex == -1 || cbxMaNV.SelectedIndex == -1 || cbxThanhToan.SelectedIndex == -1)
            {
                return;
            }
            soHD = txtSoHD.Text;
            maKH = cbxMaKH.SelectedValue.ToString();
            maNV = cbxMaNV.SelectedValue.ToString();
            maHTTT = cbxThanhToan.SelectedValue.ToString();
            diaChiGiaoHang = txtDiaChiGH.Text;
            datHang = dateDatHang.Value;
            giaoHang = dateGiaoHang.Value;
            //MessageBox.Show(giaoHang.ToString());

        }
        private void btnCommand_Click(object sender, EventArgs e)
        {
            if (command == "ADD")
            {
                layThongTinForm();
                // check 
                Boolean ok = checkDataDuChua();
                if (cbxMaKH.SelectedIndex < 0 || cbxMaNV.SelectedIndex < 0 || cbxThanhToan.SelectedIndex < 0)
                {
                    MessageBox.Show("Bạn chưa nhập đủ thông tin!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!ok)
                {
                    MessageBox.Show("Bạn chưa nhập đủ thông tin!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                // Song đk rồi
                DonHangDTO donhangMoi = new DonHangDTO(soHD, maKH, maNV, datHang, giaoHang, diaChiGiaoHang, maHTTT);
                string kq = fQL.them1DonHang(donhangMoi);
                if (kq.EndsWith("thành công!"))
                {
                    fQL.hienThiAllDonHang("");
                    MessageBox.Show(kq, "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnQuayLai_Click(sender, e);
                }
                else
                {
                    if (kq.Contains("CHK_ngayDatVaGiao"))
                    {
                        MessageBox.Show("Bạn chọn ngày đặt > ngày giao rồi! >VÔ LÝ<", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        MessageBox.Show(kq, "Thông báo!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Console.WriteLine(kq);
                    }
                }
            }
            else
            {
                // ĐÂY LÀ EDIT -> load data cũ lên rồi
                // Nếu nó ấn sửa thì check lại:
                layThongTinForm();
                // check 
                Boolean ok = checkDataDuChua();
                if (cbxMaKH.SelectedIndex < 0 || cbxMaNV.SelectedIndex < 0 || cbxThanhToan.SelectedIndex < 0)
                {
                    MessageBox.Show("Bạn chưa nhập đủ thông tin!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!ok)
                {
                    MessageBox.Show("Bạn chưa nhập đủ thông tin!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                DonHangDTO donhangMoi = new DonHangDTO(soHD, maKH, maNV, datHang, giaoHang, diaChiGiaoHang, maHTTT);
                string kq = fQL.sua1DonHang(donhangMoi,dhCu);
                if (kq.EndsWith("thành công!"))
                {
                    fQL.hienThiAllDonHang("");
                    MessageBox.Show(kq, "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnQuayLai_Click(sender, e);
                }
                else
                {
                    if (kq.Contains("CHK_ngayDatVaGiao"))
                    {
                        MessageBox.Show("Bạn chọn ngày đặt > ngày giao rồi! >VÔ LÝ<", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        MessageBox.Show(kq, "Thông báo!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Console.WriteLine(kq);
                    }
                }
            }
        }

        private void duaDuLieuLenForm()
        {
            int i = -1;
            // Duyệt qua từng dòng của DataTable
            foreach (DataRow row in dataHTTT.Rows)
            {
                
                // Lấy giá trị của một cột cụ thể trong dòng
                string giaTriMa = row["mahinhThucThanhToan"].ToString();

                // So sánh giá trị của cột với giá trị cần so sánh
                if (giaTriMa == dhCu.maHTTT)
                {
                    i++;
                    break;
                }
                else
                    i++;
            }
            txtSoHD.Text = dhCu.soHD;
            cbxMaKH.SelectedValue = dhCu.maKH;
            cbxMaNV.SelectedValue = dhCu.maNv;
            cbxThanhToan.SelectedIndex = i;
            // cần là tên Hình thức thanh toán cơ
            diaChiGiaoHang = txtDiaChiGH.Text;
            dateDatHang.Value = dhCu.datHang;
            dateGiaoHang.Value = dhCu.giaoHang;
            txtDiaChiGH.Text = dhCu.diaChiGiaoHang;
        }

        private bool checkDataDuChua()
        {
            return soHD != "" && maKH != "" && maNV != "" && maHTTT != "" && diaChiGiaoHang != "";
        }
    }
}
