namespace GUI
{
    partial class fLapHoaDon
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbnKiemTraDH = new System.Windows.Forms.Button();
            this.dateGiaoHang = new System.Windows.Forms.DateTimePicker();
            this.dateDatHang = new System.Windows.Forms.DateTimePicker();
            this.cbxMaKH = new System.Windows.Forms.ComboBox();
            this.cbxThanhToan = new System.Windows.Forms.ComboBox();
            this.txtDiaChiGH = new System.Windows.Forms.TextBox();
            this.txtSoHD = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnHuyTao = new System.Windows.Forms.Button();
            this.labTongTien = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btnHoanThanhDonHang = new System.Windows.Forms.Button();
            this.livSanPhamDonHang = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnThemSP = new System.Windows.Forms.Button();
            this.txtGiamGia = new System.Windows.Forms.TextBox();
            this.txtSoLuong = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxSanPham = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.tbnKiemTraDH);
            this.groupBox1.Controls.Add(this.dateGiaoHang);
            this.groupBox1.Controls.Add(this.dateDatHang);
            this.groupBox1.Controls.Add(this.cbxMaKH);
            this.groupBox1.Controls.Add(this.cbxThanhToan);
            this.groupBox1.Controls.Add(this.txtDiaChiGH);
            this.groupBox1.Controls.Add(this.txtSoHD);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(635, 186);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tạo đơn hàng mới:";
            // 
            // tbnKiemTraDH
            // 
            this.tbnKiemTraDH.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.tbnKiemTraDH.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tbnKiemTraDH.Location = new System.Drawing.Point(499, 114);
            this.tbnKiemTraDH.Name = "tbnKiemTraDH";
            this.tbnKiemTraDH.Size = new System.Drawing.Size(112, 63);
            this.tbnKiemTraDH.TabIndex = 6;
            this.tbnKiemTraDH.Text = "Kiểm tra đơn hàng";
            this.tbnKiemTraDH.UseVisualStyleBackColor = false;
            this.tbnKiemTraDH.Click += new System.EventHandler(this.button1_Click);
            // 
            // dateGiaoHang
            // 
            this.dateGiaoHang.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateGiaoHang.Location = new System.Drawing.Point(500, 29);
            this.dateGiaoHang.Name = "dateGiaoHang";
            this.dateGiaoHang.Size = new System.Drawing.Size(109, 24);
            this.dateGiaoHang.TabIndex = 38;
            // 
            // dateDatHang
            // 
            this.dateDatHang.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateDatHang.Location = new System.Drawing.Point(300, 29);
            this.dateDatHang.Name = "dateDatHang";
            this.dateDatHang.Size = new System.Drawing.Size(109, 24);
            this.dateDatHang.TabIndex = 37;
            // 
            // cbxMaKH
            // 
            this.cbxMaKH.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbxMaKH.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxMaKH.FormattingEnabled = true;
            this.cbxMaKH.Location = new System.Drawing.Point(81, 61);
            this.cbxMaKH.Name = "cbxMaKH";
            this.cbxMaKH.Size = new System.Drawing.Size(133, 26);
            this.cbxMaKH.TabIndex = 36;
            // 
            // cbxThanhToan
            // 
            this.cbxThanhToan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxThanhToan.FormattingEnabled = true;
            this.cbxThanhToan.Location = new System.Drawing.Point(348, 64);
            this.cbxThanhToan.Name = "cbxThanhToan";
            this.cbxThanhToan.Size = new System.Drawing.Size(133, 26);
            this.cbxThanhToan.TabIndex = 35;
            // 
            // txtDiaChiGH
            // 
            this.txtDiaChiGH.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiaChiGH.Location = new System.Drawing.Point(35, 114);
            this.txtDiaChiGH.Margin = new System.Windows.Forms.Padding(5);
            this.txtDiaChiGH.Multiline = true;
            this.txtDiaChiGH.Name = "txtDiaChiGH";
            this.txtDiaChiGH.Size = new System.Drawing.Size(426, 63);
            this.txtDiaChiGH.TabIndex = 32;
            // 
            // txtSoHD
            // 
            this.txtSoHD.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoHD.Location = new System.Drawing.Point(81, 29);
            this.txtSoHD.Name = "txtSoHD";
            this.txtSoHD.Size = new System.Drawing.Size(133, 21);
            this.txtSoHD.TabIndex = 28;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(21, 91);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(137, 18);
            this.label8.TabIndex = 25;
            this.label8.Text = "Địa chỉ giao hàng:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(258, 66);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 21);
            this.label7.TabIndex = 24;
            this.label7.Text = "Thanh toán:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(409, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 17);
            this.label6.TabIndex = 23;
            this.label6.Text = "Ngày giao:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(216, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 17);
            this.label5.TabIndex = 22;
            this.label5.Text = "Ngày đặt:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 17);
            this.label3.TabIndex = 20;
            this.label3.Text = "Mã KH:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 17);
            this.label2.TabIndex = 19;
            this.label2.Text = "Số HĐ:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.btnHuyTao);
            this.groupBox2.Controls.Add(this.labTongTien);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.btnHoanThanhDonHang);
            this.groupBox2.Controls.Add(this.livSanPhamDonHang);
            this.groupBox2.Controls.Add(this.btnThemSP);
            this.groupBox2.Controls.Add(this.txtGiamGia);
            this.groupBox2.Controls.Add(this.txtSoLuong);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.cbxSanPham);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 199);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(635, 298);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thêm sản phẩm cho đơn hàng:";
            // 
            // btnHuyTao
            // 
            this.btnHuyTao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnHuyTao.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHuyTao.Location = new System.Drawing.Point(409, 255);
            this.btnHuyTao.Name = "btnHuyTao";
            this.btnHuyTao.Size = new System.Drawing.Size(86, 35);
            this.btnHuyTao.TabIndex = 49;
            this.btnHuyTao.Text = "Hủy tạo";
            this.btnHuyTao.UseVisualStyleBackColor = false;
            this.btnHuyTao.Click += new System.EventHandler(this.btnHuyTao_Click);
            // 
            // labTongTien
            // 
            this.labTongTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labTongTien.Location = new System.Drawing.Point(91, 265);
            this.labTongTien.Name = "labTongTien";
            this.labTongTien.Size = new System.Drawing.Size(136, 18);
            this.labTongTien.TabIndex = 48;
            this.labTongTien.Text = "...VNĐ";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(20, 265);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(72, 17);
            this.label10.TabIndex = 47;
            this.label10.Text = "Tổng tiền:";
            // 
            // btnHoanThanhDonHang
            // 
            this.btnHoanThanhDonHang.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnHoanThanhDonHang.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHoanThanhDonHang.Location = new System.Drawing.Point(240, 253);
            this.btnHoanThanhDonHang.Name = "btnHoanThanhDonHang";
            this.btnHoanThanhDonHang.Size = new System.Drawing.Size(112, 37);
            this.btnHoanThanhDonHang.TabIndex = 46;
            this.btnHoanThanhDonHang.Text = "CHỐT ĐƠN";
            this.btnHoanThanhDonHang.UseVisualStyleBackColor = false;
            this.btnHoanThanhDonHang.Click += new System.EventHandler(this.btnHoanThanhDonHang_Click);
            // 
            // livSanPhamDonHang
            // 
            this.livSanPhamDonHang.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.livSanPhamDonHang.ForeColor = System.Drawing.SystemColors.WindowText;
            this.livSanPhamDonHang.GridLines = true;
            this.livSanPhamDonHang.HideSelection = false;
            this.livSanPhamDonHang.Location = new System.Drawing.Point(26, 74);
            this.livSanPhamDonHang.MultiSelect = false;
            this.livSanPhamDonHang.Name = "livSanPhamDonHang";
            this.livSanPhamDonHang.Size = new System.Drawing.Size(585, 173);
            this.livSanPhamDonHang.TabIndex = 45;
            this.livSanPhamDonHang.UseCompatibleStateImageBehavior = false;
            this.livSanPhamDonHang.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Tên sản phẩm";
            this.columnHeader1.Width = 350;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Số lượng";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 115;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Giảm giá(%)";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 115;
            // 
            // btnThemSP
            // 
            this.btnThemSP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnThemSP.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThemSP.Location = new System.Drawing.Point(531, 40);
            this.btnThemSP.Name = "btnThemSP";
            this.btnThemSP.Size = new System.Drawing.Size(80, 26);
            this.btnThemSP.TabIndex = 44;
            this.btnThemSP.Text = "Thêm";
            this.btnThemSP.UseVisualStyleBackColor = false;
            this.btnThemSP.Click += new System.EventHandler(this.btnThemSP_Click);
            // 
            // txtGiamGia
            // 
            this.txtGiamGia.Location = new System.Drawing.Point(405, 42);
            this.txtGiamGia.Name = "txtGiamGia";
            this.txtGiamGia.Size = new System.Drawing.Size(100, 24);
            this.txtGiamGia.TabIndex = 43;
            this.txtGiamGia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Location = new System.Drawing.Point(275, 42);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Size = new System.Drawing.Size(100, 24);
            this.txtSoLuong.TabIndex = 42;
            this.txtSoLuong.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(402, 19);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(103, 17);
            this.label9.TabIndex = 41;
            this.label9.Text = "Giảm giá(%)";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(275, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 17);
            this.label4.TabIndex = 40;
            this.label4.Text = "Số lượng:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(227, 17);
            this.label1.TabIndex = 39;
            this.label1.Text = "Tên sản phẩm:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbxSanPham
            // 
            this.cbxSanPham.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbxSanPham.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxSanPham.FormattingEnabled = true;
            this.cbxSanPham.Location = new System.Drawing.Point(24, 42);
            this.cbxSanPham.Name = "cbxSanPham";
            this.cbxSanPham.Size = new System.Drawing.Size(224, 26);
            this.cbxSanPham.TabIndex = 37;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Location = new System.Drawing.Point(530, 253);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(78, 38);
            this.button1.TabIndex = 51;
            this.button1.Text = "Clear All";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // fLapHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 509);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MinimumSize = new System.Drawing.Size(700, 508);
            this.Name = "fLapHoaDon";
            this.Text = "fLapHoaDon";
            this.Load += new System.EventHandler(this.fLapHoaDon_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dateGiaoHang;
        private System.Windows.Forms.DateTimePicker dateDatHang;
        private System.Windows.Forms.ComboBox cbxMaKH;
        private System.Windows.Forms.ComboBox cbxThanhToan;
        private System.Windows.Forms.TextBox txtDiaChiGH;
        private System.Windows.Forms.TextBox txtSoHD;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button tbnKiemTraDH;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView livSanPhamDonHang;
        private System.Windows.Forms.Button btnThemSP;
        private System.Windows.Forms.TextBox txtGiamGia;
        private System.Windows.Forms.TextBox txtSoLuong;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxSanPham;
        private System.Windows.Forms.Button btnHoanThanhDonHang;
        private System.Windows.Forms.Label labTongTien;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button btnHuyTao;
        private System.Windows.Forms.Button button1;
    }
}