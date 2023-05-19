using BLL;
using DTO;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;


namespace GUI
{
    public partial class fEditAddMatHang : Form
    {
        string strCon = Properties.Settings.Default.strCon;
        formQuanLy fQL;
        string maLoaiHang = "";
        string maNhaCC = "";
        string duongDanAnh = "";
        string command = "";

        MatHangDTO matHangCanSua;

        public fEditAddMatHang(formQuanLy fQL, string action, MatHangDTO mh)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
            this.fQL = fQL;
            cbxMaLoaiHang.Font = new Font("Arial", 10);
            cbxMaNCC.Font = new Font("Arial", 10);
            command = action;
            matHangCanSua = mh;
            loadDataCbxNCC();
            loadDataCbxLH();
            settingtext(action);
            
        }
        private void settingtext(string ac)
        {
            if (ac == "add")
            {
                labTitle.Text = "--   THÊM MẶT HÀNG   --";
                btnCommand.Text = "Thêm MH";
            }
            else
            {
                labTitle.Text = "--   SỬA MẶT HÀNG    --";
                btnCommand.Text = "Sửa MH";
                duaDuLieuLen();
            }
        }

        private void fEditAngAddMatHang_Load(object sender, EventArgs e)
        {
            txtMaHang.Focus();
           

        }

        private void loadDataCbxLH()
        {
            try
            {
                DataTable data = layAllLH();
                cbxMaLoaiHang.Items.Clear();
                cbxMaLoaiHang.DropDownStyle = ComboBoxStyle.DropDownList;
                cbxMaLoaiHang.DataSource = data;
                cbxMaLoaiHang.ValueMember = "maLoaiHang"; // Tên cột dùng để hiển thị dữ liệu
                cbxMaLoaiHang.DisplayMember = "tenLoaiHang"; // Tên cột dùng để lấy giá trị khi được chọn

            }
            catch (Exception ex)
            {
                Console.WriteLine("errr +" + ex.Message);
            }


        }
        private DataTable layAllLH()
        {
            string query = "select * from LOAIHANG;";
            DataTable kq = new DataTable();
            using (SqlConnection con = new SqlConnection(strCon))
            {
                try
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.CommandType = CommandType.Text;
                        SqlDataReader reader = cmd.ExecuteReader();
                        kq.Load(reader);
                        return kq;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    return null;
                }
            }
        }
        private void loadDataCbxNCC()
        {
            DataTable data = NhaCungCapBLL.layAllNhaCC("");
            cbxMaNCC.Items.Clear();
            cbxMaNCC.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxMaNCC.DataSource = data;
            cbxMaNCC.ValueMember = "maNhaCC"; // Tên cột dùng để hiển thị dữ liệu
            cbxMaNCC.DisplayMember = "tenNhaCC"; // Tên cột dùng để lấy giá trị khi được chọn

        }

        private void cbxMaLoaiHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            object maLoaiHangDangChon = cbxMaLoaiHang.SelectedValue;
            maLoaiHang = maLoaiHangDangChon.ToString();

        }

        private void cbxMaNCC_SelectedIndexChanged(object sender, EventArgs e)
        {
            object maNhaCCDangChon = cbxMaNCC.SelectedValue;
            maNhaCC = maNhaCCDangChon.ToString();
        }

        private void btnHinhAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            // Thiết lập các tùy chọn cho hộp thoại mở tệp tin
            openFileDialog.Filter = "Tệp tin ảnh (*.jpg; *.png; *.gif)|*.jpg;*.png;*.gif";
            openFileDialog.Title = "Chọn một tệp tin ảnh";

            // Hiển thị hộp thoại mở tệp tin
            DialogResult result = openFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                // Lấy đường dẫn của tệp tin ảnh
                duongDanAnh = openFileDialog.FileName;
                picMatHang.BackgroundImage = Image.FromFile(duongDanAnh);
                picMatHang.BackgroundImageLayout = ImageLayout.Zoom;

            }
            else
            {
                return;
            }
        }

        private void btnCommand_Click(object sender, EventArgs e)
        {
            // Lấy all dữ liệu để trả về 1 đối tượng mặt hàng đê <<>>!
            string maHang = txtMaHang.Text;
            string tenHang = txtTenHang.Text;
            string soLuong = txtSoLuong.Text;
            string dvTinh = txtDVTinh.Text;
            string giaNhap = txtGiaNhap.Text; // money
            string giaBan = txtGiaBan.Text;   // money\
            cbxMaLoaiHang_SelectedIndexChanged(sender, e);
            cbxMaNCC_SelectedIndexChanged(sender, e);
            // còn 2 cái mã kia lưu toàn cục sự kiện của combox kiểm soát
            Boolean ok;
            /*
                                    Đoạn sử lý lỗi nhập thông tin này áp dụng cho cả add và edit
            // Các lỗi có thể sảy ra -> 
                // Sử lý người dùng nhập:
                   -  Nhập chưa đủ thông tin
                   - số lượng - giá nhập - giá bán: Là số
                // Về triger và check của DB:
                   -  số lượng - giá nhập - giá bán: - lớn hơn 0 
                   - 
                // 
                // .Mã hàng -> trùng với mã hàng trên DB rồi!

            */
            ok = isRong(maHang) && isRong(tenHang) && isRong(soLuong) && isRong(dvTinh) && isRong(giaNhap) && isRong(giaBan) && isRong(maLoaiHang) && isRong(maNhaCC) && isRong(duongDanAnh);
            if (!ok)
            {
                MessageBox.Show("Bạn chưa nhập đủ thông tin!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            decimal giaNhap_So;
            decimal giaBan_So;
            int soLuong_So;
            try
            {
                soLuong_So = Convert.ToInt32(soLuong);
            }
            catch
            {
                MessageBox.Show("Số lượng bạn nhập không đúng định dạng!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                giaNhap_So = Convert.ToDecimal(giaNhap);
            }
            catch
            {
                MessageBox.Show("Giá nhập bạn nhập không đúng định dạng!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                giaBan_So = Convert.ToDecimal(giaBan);
            }
            catch
            {
                MessageBox.Show("Giá bán bạn nhập không đúng định dạng!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (giaBan_So < 0)
            {
                MessageBox.Show("Giá bán cần >0 ", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (giaNhap_So < 0)
            {
                MessageBox.Show("Giá nhập cần >0 ", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ok = true;
            // Sử lý lỗi song! -> theo cách người ta muốn thì chạy add or edit!
            if(ok)
            {
                if (command == "add")
                {
                    // Nếu mà là thêm thì sử lý giá nhập > giá bán
                    if (giaNhap_So > giaBan_So)
                    {
                        MessageBox.Show("Giá nhập cần > giá bán chứ !!! ", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    // Hết lỗi - đủ 9 thông tin rồi -> // Gọi thằng bố nó ra và thêm ở đây cũng đc mà >> 
                    MatHangDTO mh = new MatHangDTO(maHang, tenHang, maNhaCC, maLoaiHang, soLuong_So, dvTinh, giaNhap_So, giaBan_So, duongDanAnh);
                    try
                    {
                        string kq = fQL.them1MatHang(mh);  
                        if(kq.EndsWith("thành công!"))
                        {
                            fQL.hienThiALLMatHang("");
                            MessageBox.Show(kq, "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            button3_Click(sender, e);
                        }
                        else
                        {
                            MessageBox.Show(kq, "Thông báo!!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                    }
                    catch (Exception ex)
                    {
                        //ex.Message là nội dung trong SQL chuẩn bị sẵn
                        MessageBox.Show(ex.Message, "Thông báo!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else // comman = "edit"
                {
                    // Mặt hàng cần sửa đã đc bố gán sang! -> đưa dữ liệu trở lên giao diện
                   
                    MatHangDTO mh = new MatHangDTO(maHang, tenHang, maNhaCC, maLoaiHang, soLuong_So, dvTinh, giaNhap_So, giaBan_So, duongDanAnh);
                    try
                    {
                        string kq = MatHangBLL.capNhat1MatHang(mh, matHangCanSua.maHang);

                        if (kq.EndsWith("thành công!"))
                        {
                            fQL.hienThiALLMatHang("");
                            MessageBox.Show(kq, "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            button3_Click(sender, e);
                        }
                        else
                        {
                            MessageBox.Show(kq, "Thông báo!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        //ex.Message là nội dung trong SQL chuẩn bị sẵn
                        MessageBox.Show(ex.Message, "Thông báo!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void duaDuLieuLen()
        {
            txtMaHang.Text = matHangCanSua.maHang;
            txtTenHang.Text = matHangCanSua.tenHang;
            cbxMaLoaiHang.SelectedValue = matHangCanSua.maLoaiHang;
            //cbxMaLoaiHang.SelectedItem = "hocTap";
            cbxMaNCC.SelectedValue = matHangCanSua.maNCC;
            txtSoLuong.Text = matHangCanSua.soLuong.ToString();
            txtGiaBan.Text = matHangCanSua.giaBan.ToString("0.##");
            txtGiaNhap.Text = matHangCanSua.giaNhap.ToString("0.##");
            txtDVTinh.Text = matHangCanSua.donViTinh;
            picMatHang.BackgroundImage = Image.FromFile(matHangCanSua.hinhAnh);
            picMatHang.BackgroundImageLayout = ImageLayout.Zoom;
            duongDanAnh = matHangCanSua.hinhAnh;
        }
        private Boolean isRong(string txt)
        {
            // Rỗng về fasle 
            return txt != "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}

