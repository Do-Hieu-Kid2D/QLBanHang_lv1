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

namespace GUI
{

    public partial class fAddEditNhaCC : Form
    {
        string ma;
        string ten;
        string diaChi;
        string dienThoai;
        string email;
        string nguoiDaiDien;
        NhaCungCapDTO nhaCCMoi;
        NhaCungCapDTO nhaCCCu;
        SqlServer libDB;
        formQuanLy fQL;
        string command;
        string strCon = Properties.Settings.Default.strCon;
        public fAddEditNhaCC(formQuanLy fQL, string command, NhaCungCapDTO ncccu)
        {
            InitializeComponent();
            this.fQL = fQL;
            this.command = command;
            this.nhaCCCu = ncccu;
            this.StartPosition = FormStartPosition.CenterParent;
            settingTXT();
        }

        private void settingTXT()
        {
            if (command == "ADD")
            {
                labTitle.Text = "--  THÊM NHÀ CUNG CẤP  --";
                btnCommand.Text = "Thêm";
            }
            else
            {
                labTitle.Text = "--  SỬA NHÀ CUNG CẤP  --";
                btnCommand.Text = "Sửa";
                duaThongTinLenForm();
            }
        }

        private void fAddEditNhaCC_Load(object sender, EventArgs e)
        {

        }

        private void btnCommand_Click(object sender, EventArgs e)
        {
            if (command == "ADD")
            {
                nhaCCMoi = layThongTinForm();
                if (nhaCCMoi == null) return;
                if (dienThoai.Length > 10)
                {
                    MessageBox.Show($"Đảm bảo điện thoại có đúng 10 chữ số!", "Thông báo!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                libDB = new SqlServer(strCon);

                string query = "INSERT INTO [dbo].[NHACUNGCAP]" +
                    "([maNhaCC],[tenNhaCC],[diaChi],[dienThoai],[email],[nguoiDaiDien])" +
                    "VALUES" +
                    $"('{ma}',N'{ten}',N'{diaChi}','{dienThoai}',N'{email}',N'{nguoiDaiDien}');";
                try
                {
                    SqlCommand cmd = libDB.GetCmdSQLChay(query);
                    int kq = libDB.QueryNon(cmd);
                    if (kq > 0)
                    {
                        fQL.hienThiAllNhaCC("");
                        MessageBox.Show($"Đã thêm nhà cung cấp mã: {ma} thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnQuayLai_Click(sender, e);
                    }
                    else
                    {
                        MessageBox.Show($"Lỗi này chưa fix - chưa thêm đc NCC!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        btnQuayLai_Click(sender, e);
                    }
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message,"Thông báo!!",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    Console.WriteLine(ex.Message);
                    string loi = ex.Message;
                    if (loi.Contains("pk_nhaCungCap"))
                    {
                        MessageBox.Show($"Mã nhà cung cấp: {ma} đã có rồi! không thêm mã này được nữa!!", "Thông báo!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    if (loi.Contains("CHK_dienThoaiNCC"))
                    {
                        MessageBox.Show($"Đảm bảo điện thoại có đúng 10 chữ số!", "Thông báo!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                // Đây là edit:
                nhaCCMoi = layThongTinForm();
                if (nhaCCMoi == null) return;
                if (dienThoai.Length > 10)
                {
                    MessageBox.Show($"Đảm bảo điện thoại có đúng 10 chữ số!", "Thông báo!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                libDB = new SqlServer(strCon);
                string query = "UPDATE [dbo].[NHACUNGCAP]  SET" +
                    $" [maNhaCC] ='{nhaCCMoi.ma}' ,[tenNhaCC] = N'{nhaCCMoi.ten}' ,[diaChi] =N'{nhaCCMoi.diaChi}' ," +
                    $"[dienThoai] = '{nhaCCMoi.dienThoai}',[email] = '{nhaCCMoi.email}' ,[nguoiDaiDien] = N'{nhaCCMoi.nguoiDaiDien}'" +
                    $" WHERE maNhaCC = '{nhaCCCu.ma}';" ;
                try
                {
                    SqlCommand cmd = libDB.GetCmdSQLChay(query);
                    int kq = libDB.QueryNon(cmd);
                    if (kq > 0)
                    {
                        fQL.hienThiAllNhaCC("");
                        MessageBox.Show($"Đã sửa nhà cung cấp mã: {nhaCCCu.ma} thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnQuayLai_Click(sender, e);
                    }
                    else
                    {
                        MessageBox.Show($"Lỗi này chưa fix - chưa sửa đc NCC!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        btnQuayLai_Click(sender, e);
                    }
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message,"Thông báo!!",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    Console.WriteLine(ex.Message);
                    string loi = ex.Message;
                    if (loi.Contains("pk_nhaCungCap"))
                    {
                        MessageBox.Show($"Mã nhà cung cấp: {ma} đã có rồi! không thêm mã này được nữa!!", "Thông báo!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    if (loi.Contains("CHK_dienThoaiNCC"))
                    {
                        MessageBox.Show($"Đảm bảo điện thoại có đúng 10 chữ số!", "Thông báo!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void duaThongTinLenForm()
        {
            txtMaNHaCC.Text = nhaCCCu.ma;
            txtTenNhaCC.Text = nhaCCCu.ten;
            txtDiaChi.Text = nhaCCCu.diaChi;
            txtDienThoai.Text = nhaCCCu.dienThoai;
            txtEmail.Text = nhaCCCu.email;
            txtNguoiDaiDien.Text = nhaCCCu.nguoiDaiDien;
        }

        private NhaCungCapDTO layThongTinForm()
        {
            ma = txtMaNHaCC.Text;
            ten = txtTenNhaCC.Text;
            diaChi = txtDiaChi.Text;
            dienThoai = txtDienThoai.Text;
            email = txtEmail.Text;
            nguoiDaiDien = txtNguoiDaiDien.Text;
            if (checkRong())
            {
                MessageBox.Show("Bạn chưa nhập đủ thông tin!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            else
                return new NhaCungCapDTO(ma, ten, diaChi, dienThoai, email, nguoiDaiDien);
        }

        private bool checkRong()
        {
            return ma == "" || ten == "" || diaChi == "" || dienThoai == "" || email == "" || nguoiDaiDien == "";
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
