using BLL;
using DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GUI
{
    public partial class fLapHoaDon : Form
    {
        string command = "ADD";
        string maNV = "";
        string maKH = "";
        string maHTTT = "";
        string soHD = "";
        string diaChiGiaoHang = "";
        DateTime datHang;
        DateTime giaoHang;
        string tenDNNV;
        NhanVienDTO nhanVienHienTai;
        formQuanLy fQL = new formQuanLy(new Project_CSDLBanHang.formDangNhap());
        SqlServer libDB = new SqlServer(Properties.Settings.Default.strCon);
        string strCon = Properties.Settings.Default.strCon;
        Boolean coDonRoi = false;
        Dictionary<string, decimal> mangGiaBan = new Dictionary<string, decimal>();
        Dictionary<string, string> mangmaHangTenHang = new Dictionary<string, string>();
        Decimal tongTien = 0;
        public fLapHoaDon(string tenDN)
        {
            InitializeComponent();
            loaDatacbxMaKH();
            loaDatacbxThanhToan();
            this.tenDNNV = tenDN;
            nhanVienHienTai = layNhanVienHienTai();
            groupBox2.Visible = false;
        }

        private void fLapHoaDon_Load(object sender, EventArgs e)
        {
            loadMangGiaBan();
            loadMangmaHangDonHang();

        }

        private void loadMangmaHangDonHang()
        {
            string query = $"select maHang, tenHang from MATHANG;";
            using (SqlConnection con = new SqlConnection(strCon))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        string maMH = reader.GetString(0);
                        string tenHang = reader.GetString(1);
                        mangmaHangTenHang.Add(maMH, tenHang);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "Chưa load đc mã hàng tên hàng !", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            foreach (KeyValuePair<string, string> entry in mangmaHangTenHang)
            {
                string key = entry.Key;
                string value = entry.Value;
                Console.WriteLine("Key: " + key + ", Value: " + value);
            }
        }

        private void loadMangGiaBan()
        {
            string query = $"select maHang, giaBan from MATHANG;";
            using (SqlConnection con = new SqlConnection(strCon))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        string maMH = reader.GetString(0);
                        decimal giaMH = Convert.ToDecimal(reader.GetDecimal(1));
                        mangGiaBan.Add(maMH, giaMH);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "Chưa load đc mảng tiền!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

        }
        private NhanVienDTO layNhanVienHienTai()
        {
            string query = $"select * from NHANVIEN where taiKhoan ='{this.tenDNNV}';";
            SqlCommand cmd = libDB.GetCmdSQLChay(query);
            DataTable dataTable = new DataTable();
            try
            {
                dataTable = libDB.Query(cmd);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "   > Lỗi j đó chưa fixx");
                return null;
            }

            try
            {
                string ma = dataTable.Rows[0][0].ToString();
                string hoVaTen = dataTable.Rows[0][1].ToString();
                Boolean gioiTinh = dataTable.Rows[0][2].ToString() == "Nam" ? true : false;
                DateTime ngaySinh = DateTime.Parse(dataTable.Rows[0][3].ToString());
                DateTime ngayLamViec = DateTime.Parse(dataTable.Rows[0][4].ToString());
                string diaChi = dataTable.Rows[0][5].ToString();
                string dienthoai = dataTable.Rows[0][6].ToString();
                decimal luong = decimal.Parse(dataTable.Rows[0][7].ToString());
                decimal phuCap = decimal.Parse(dataTable.Rows[0][8].ToString());
                string taiKhoan = dataTable.Rows[0][9].ToString();
                string matKhau = dataTable.Rows[0][10].ToString();
                return new NhanVienDTO(ma, hoVaTen, gioiTinh, ngaySinh, ngayLamViec, diaChi, dienthoai, luong, phuCap, taiKhoan, matKhau);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " Lỗi ép kiểu dữ liệu");
                return null;
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

                DataTable data = new DataTable();
                SqlDataReader reader = cmd.ExecuteReader();
                data.Load(reader);

                //cbxMaNV.Items.Clear();
                //cbxThanhToan.Items.Clear();
                cbxThanhToan.DataSource = data;
                cbxThanhToan.ValueMember = "mahinhThucThanhToan";
                cbxThanhToan.DisplayMember = "tenhinhThucThanhToan";
                cbxThanhToan.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
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


        private void button1_Click(object sender, EventArgs e)
        {
            DoADD();
        }

        private void DoADD()
        {
            layThongTinForm();
            // check 
            Boolean ok = checkDataDuChua();
            if (cbxMaKH.SelectedIndex < 0 || cbxThanhToan.SelectedIndex < 0)
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
                MessageBox.Show($"Tạo đơn hàng thành công! Hãy thêm sản phẩm cho đơn hàng này.", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                groupBox1.Enabled = false;
                coDonRoi = true;
                if (coDonRoi)
                {
                    groupBox2.Visible = true;
                }
                loadCbxSanPham();
                // oke! Hết nhiệm vụ thằng này
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
        DataTable dataTable = new DataTable();
        private void loadCbxSanPham()
        {
            // Datatable sản phẩm gồm 2 hàng mã và ten thôi
            string query = "select maHang, tenHang from MATHANG;";
            SqlCommand cmd = libDB.GetCmdSQLChay(query);


            dataTable = libDB.Query(cmd);

            // có dữ liệu về rồi -> đổ lên cbx
            cbxSanPham.DataSource = dataTable;
            cbxSanPham.ValueMember = "maHang";
            cbxSanPham.DisplayMember = "tenHang";
            // Setting để có thể nhập chữ vào tìm kiếm ở combox!
            cbxSanPham.DropDownStyle = ComboBoxStyle.DropDown;
            cbxSanPham.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbxSanPham.AutoCompleteSource = AutoCompleteSource.ListItems;
            cbxSanPham.MaxDropDownItems = 10;
            cbxSanPham.SelectedIndex = -1;

        }

        private void layThongTinForm()
        {
            if (cbxMaKH.SelectedIndex == -1 || cbxThanhToan.SelectedIndex == -1)
            {
                return;
            }
            soHD = txtSoHD.Text;
            maKH = cbxMaKH.SelectedValue.ToString();
            maHTTT = cbxThanhToan.SelectedValue.ToString();
            diaChiGiaoHang = txtDiaChiGH.Text;
            datHang = dateDatHang.Value;
            giaoHang = dateGiaoHang.Value;
            maNV = nhanVienHienTai.ma;
            //MessageBox.Show("Mã NV " + maNV );
            //MessageBox.Show(nhanVienHienTai.ToString() );

        }

        private bool checkDataDuChua()
        {
            return soHD != "" && maKH != "" && maNV != "" && maHTTT != "" && diaChiGiaoHang != "";
        }

        private void btnThemSP_Click(object sender, EventArgs e)
        {
            if (cbxSanPham.SelectedIndex < 0)
            {
                MessageBox.Show("Bạn chưa chọn mặt hàng hàng.", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtSoLuong.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập số lượng.", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string tenMHThem = "";
            int soLuongMHThem = 1;
            decimal giamGiaMHTHem = 0;
            Boolean ok = layMatHangMuonTHem(ref tenMHThem, ref soLuongMHThem, ref giamGiaMHTHem);
            if (!ok) return;
            // Có data rồi thì đưa lên listView!
            ListViewItem lvi = new ListViewItem(tenMHThem);
            lvi.SubItems.Add(soLuongMHThem.ToString());
            lvi.SubItems.Add(giamGiaMHTHem.ToString("0.##"));
            livSanPhamDonHang.Items.Add(lvi);

            // Tính tổng tiền
            string maHangDangChon = cbxSanPham.SelectedValue.ToString();
            Decimal giaBan = mangGiaBan[maHangDangChon];
            decimal giaConLai = giaBan - (giaBan * (giamGiaMHTHem / 100));
            tongTien += soLuongMHThem * giaConLai;
            string formatTongTien = tongTien.ToString("N0", new NumberFormatInfo { NumberGroupSeparator = ".", NumberDecimalDigits = 0 });
            labTongTien.Text = formatTongTien + " VNĐ";

            // Xóa data đang chọn đi để chọn tiếp thì sao:
            cbxSanPham.SelectedIndex = -1;
            txtGiamGia.Text = "";
            txtSoLuong.Text = "";

        }

        private Boolean layMatHangMuonTHem(ref string tenMHThem, ref int soLuongMHThem, ref decimal giamGiaMHTHem)
        {
            int ttMatHangDangChon = cbxSanPham.SelectedIndex;
            if (ttMatHangDangChon == -1)
            {
                MessageBox.Show("Chọn sản phẩm muốn thêm đi <<", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            tenMHThem = dataTable.Rows[ttMatHangDangChon][1].ToString();
            try
            {
                soLuongMHThem = Convert.ToInt32(txtSoLuong.Text.ToString());
                if (txtGiamGia.Text != "")
                {
                    giamGiaMHTHem = Convert.ToDecimal(txtGiamGia.Text.ToString());
                }
                else
                {
                    giamGiaMHTHem = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Nhập số lượng hay giảm giá là số nha.", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void btnHoanThanhDonHang_Click(object sender, EventArgs e)
        {
            // Khi ấn chốt đơn cần lấy tổng tiền update vào đơn hàng vừa tạo
            // thêm các thằng trên list view vào bảng chi tiết đơn hàng!
            try
            {

                String tienCanLuu = labTongTien.Text;
                tienCanLuu = tienCanLuu.Replace(" VNĐ", "");
                tienCanLuu = tienCanLuu.Replace(".", "");
                luuTongTienXuong(tienCanLuu);
                foreach (ListViewItem item in livSanPhamDonHang.Items)
                {
                    // Lấy giá trị của các cột từ item và sử dụng chúng theo nhu cầu
                    string tenMH = item.SubItems[0].Text;
                    string soLuong = item.SubItems[1].Text;
                    string GiamGia = item.SubItems[2].Text;
                    string soHD = txtSoHD.Text;

                    // Cần lấy mã hàng từ tên hàng
                    string maHang = null;
                    foreach (KeyValuePair<string, string> pair in mangmaHangTenHang)
                    {
                        if (pair.Value == tenMH)
                        {
                            maHang = pair.Key;
                            // Phải đẩy xuống DB luôn:
                            dayChiTietXuongDB(soHD, maHang, soLuong, GiamGia);
                            break;
                        }
                    }

                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message + " Lỗi j đó khi CHỐT ĐƠN", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            MessageBox.Show("Tạo đơn hàng thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            resetTatCa();
        }

        private void resetTatCa()
        {
            txtSoHD.Text = "";
            txtSoLuong.Text = "";
            txtGiamGia.Text = "";
            txtDiaChiGH.Text = "";
            labTongTien.Text = "... VNĐ";
            cbxMaKH.SelectedIndex = -1;
            cbxSanPham.SelectedIndex = -1;
            cbxThanhToan.SelectedIndex = -1;
            livSanPhamDonHang.Items.Clear();
            dateDatHang.Value = DateTime.Now;
            dateGiaoHang.Value = DateTime.Now;
            groupBox1.Visible = true;
            groupBox2.Visible = false;

        }

        private void dayChiTietXuongDB(string soHD, string maHang, string soLuong, string giamGia)
        {
            // Biến đổi số lượng và giảm giá đã
            int soLuongINT = Convert.ToInt32(soLuong);
            decimal giamGiaDEC = Convert.ToDecimal(giamGia);
            string query = $"INSERT INTO [dbo].[CHITIETDONHANG]" +
                $"([soHoaDon],[maHang],[soLuong],[mucGiamGia])" +
                $"VALUES('{soHD}','{maHang}',{soLuongINT},{giamGiaDEC})";
            try
            {
                libDB.RunSQL(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "Lỗi j đó khi lưu chi tiết đơn hàng", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
        }

        private void luuTongTienXuong(string tienCanLuu)
        {
            string query = $"update  dondathang  set tongTien = '{tienCanLuu}' where soHoaDon = '{txtSoHD.Text}'";
            try
            {
                libDB.RunSQL(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " Lỗi j đó khi lưu tổng tiền", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
