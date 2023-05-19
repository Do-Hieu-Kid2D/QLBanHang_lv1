using DTO;
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
    public partial class fAddEditKhachHang : Form
    {
        public formQuanLy fQL;
        public string command;
        public KhachHangDTO khCu;
        String maKh ="";
        string tenKH ="";
        Boolean gioiTinh;
        string tenCT = "";
        string diaChi = "";
        string Email = "";
        string sdt = "";

        public fAddEditKhachHang(formQuanLy f, string action, KhachHangDTO khcanS)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
            fQL = f;
            command = action;
            this.khCu = khcanS;
            settingTxt();
        }

        private void settingTxt()
        {
            if(command == "ADD")
            {
                labTitle.Text = "--    THÊM KHÁCH HÀNG    --";
                btnCommand.Text = "Thêm";
            }
            else
            {
                loadThongTinCanSua();
                labTitle.Text = "--    SỬA KHÁCH HÀNG    --";
                btnCommand.Text = "Sửa";
            }
        }

        private void btnCommand_Click(object sender, EventArgs e)
        {
            if (command == "ADD")
            {
                Boolean ok = checkData();
                if (!ok)
                {
                    MessageBox.Show("Bạn chưa nhập đủ thông tin!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                // check song chưa nhập đủ thông tin! - là đủ rồi - cùng lắm thêm lỗi trùng mã KH thôi
                try
                {
                    KhachHangDTO khCanThem = layThongTinform();
                    if (khCanThem == null) return;
                    string kq = fQL.them1KhachHang(khCanThem);

                    if (kq.EndsWith("thành công!"))
                    {
                        fQL.hienThiALLKhachHang("");
                        MessageBox.Show(kq, "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnQuayLai_Click(sender, e);
                    }
                    else
                    {
                        if (kq.Contains("CHK_dienThoaikhachHang")) 
                            MessageBox.Show("Đảm bảo SĐT chứa đúng 10 chữ số!", "Thông báo!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else
                            MessageBox.Show(kq, "Thông báo!!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông báo ERR!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // Phần edit
                Boolean ok = checkData();
                if (!ok)
                {
                    MessageBox.Show("Bạn chưa nhập đủ thông tin!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                // check song chưa nhập đủ thông tin! - là đủ rồi - cùng lắm thêm lỗi trùng mã KH thôi
                try
                {
                    
                    KhachHangDTO khMoi = layThongTinform();
                    if (khMoi == null) return;
                    string kq = fQL.sua1KhachHang(khMoi,khCu);

                    if (kq.EndsWith("thành công!"))
                    {
                        fQL.hienThiALLKhachHang("");
                        MessageBox.Show(kq, "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnQuayLai_Click(sender, e);
                    }
                    else
                    {
                        if (kq.Contains("CHK_dienThoaikhachHang"))
                            MessageBox.Show("Đảm bảo SĐT chứa đúng 10 chữ số!", "Thông báo!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else
                            MessageBox.Show(kq, "Thông báo!!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông báo ERR!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void loadThongTinCanSua()
        {
            txtMaKH.Text = khCu.maKh;
            txtTenKH.Text = khCu.tenKH;
            if (khCu.gioiTinh) radNam.Checked = true; else radNu.Checked = true;
            txtTenCT.Text = khCu.tenCT;
            txtDiaChi.Text = khCu.diaChi;
            txtEmail.Text = khCu.Email;
            txtSDT.Text = khCu.sdt;
        }

        private KhachHangDTO layThongTinform()
        {
            maKh = txtMaKH.Text;
            tenKH = txtTenKH.Text;
            if (radNam.Checked) gioiTinh = true;
            if (radNu.Checked) gioiTinh = false;
            tenCT = txtTenCT.Text;
            diaChi = txtDiaChi.Text;
            Email = txtEmail.Text;
            sdt = txtSDT.Text;
            if(sdt.Length != 10)
            {
                MessageBox.Show("Đảm bảo SĐT chứa đúng 10 chữ số!", "Thông báo!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            return new KhachHangDTO(maKh, tenKH, gioiTinh,tenCT,diaChi,Email,sdt);
        }

        private bool checkData()
        {
            maKh = txtMaKH.Text;
            tenKH = txtTenKH.Text;
            if (radNam.Checked) gioiTinh = true;
            if (radNu.Checked) gioiTinh = false;
            tenCT = txtTenCT.Text;
            diaChi = txtDiaChi.Text;
            Email = txtEmail.Text;
            sdt = txtSDT.Text;
            if (!radNam.Checked && !radNu.Checked) return false;
            return isRong(maKh) && isRong(tenKH) && isRong(tenCT) && isRong(diaChi) && isRong(Email) && isRong(sdt);

        }

        private bool isRong(string txt)
        {
            return txt != "";
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
