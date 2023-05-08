namespace GUI
{
    partial class formQuanLy
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formQuanLy));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.labTenQuanLy = new System.Windows.Forms.Label();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabMatHang = new System.Windows.Forms.TabPage();
            this.tabKhachHang = new System.Windows.Forms.TabPage();
            this.tabDonHang = new System.Windows.Forms.TabPage();
            this.tabNhanVien = new System.Windows.Forms.TabPage();
            this.tabTKBC = new System.Windows.Forms.TabPage();
            this.tabHeThong = new System.Windows.Forms.TabPage();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnDangXuat = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.splitContainer1.Panel1.Controls.Add(this.btnDangXuat);
            this.splitContainer1.Panel1.Controls.Add(this.labTenQuanLy);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.pictureBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabMain);
            this.splitContainer1.Size = new System.Drawing.Size(1178, 944);
            this.splitContainer1.SplitterDistance = 68;
            this.splitContainer1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AllowDrop = true;
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(467, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(257, 32);
            this.label1.TabIndex = 1;
            this.label1.Text = "QUYỀN QUẢN LÝ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labTenQuanLy
            // 
            this.labTenQuanLy.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labTenQuanLy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labTenQuanLy.Location = new System.Drawing.Point(109, 18);
            this.labTenQuanLy.Name = "labTenQuanLy";
            this.labTenQuanLy.Size = new System.Drawing.Size(195, 36);
            this.labTenQuanLy.TabIndex = 3;
            this.labTenQuanLy.Text = "Admin";
            this.labTenQuanLy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabMatHang);
            this.tabMain.Controls.Add(this.tabKhachHang);
            this.tabMain.Controls.Add(this.tabDonHang);
            this.tabMain.Controls.Add(this.tabNhanVien);
            this.tabMain.Controls.Add(this.tabTKBC);
            this.tabMain.Controls.Add(this.tabHeThong);
            this.tabMain.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabMain.ImageList = this.imageList1;
            this.tabMain.Location = new System.Drawing.Point(0, 0);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(1178, 872);
            this.tabMain.TabIndex = 0;
            this.tabMain.Tag = "";
            // 
            // tabMatHang
            // 
            this.tabMatHang.BackColor = System.Drawing.Color.Transparent;
            this.tabMatHang.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tabMatHang.ImageIndex = 0;
            this.tabMatHang.Location = new System.Drawing.Point(4, 38);
            this.tabMatHang.Margin = new System.Windows.Forms.Padding(10);
            this.tabMatHang.Name = "tabMatHang";
            this.tabMatHang.Padding = new System.Windows.Forms.Padding(3);
            this.tabMatHang.Size = new System.Drawing.Size(1170, 830);
            this.tabMatHang.TabIndex = 0;
            this.tabMatHang.Text = " Mặt hàng ";
            // 
            // tabKhachHang
            // 
            this.tabKhachHang.ImageKey = "rating.png";
            this.tabKhachHang.Location = new System.Drawing.Point(4, 38);
            this.tabKhachHang.Margin = new System.Windows.Forms.Padding(10);
            this.tabKhachHang.Name = "tabKhachHang";
            this.tabKhachHang.Padding = new System.Windows.Forms.Padding(3);
            this.tabKhachHang.Size = new System.Drawing.Size(1170, 830);
            this.tabKhachHang.TabIndex = 1;
            this.tabKhachHang.Text = " Khách hàng ";
            this.tabKhachHang.UseVisualStyleBackColor = true;
            // 
            // tabDonHang
            // 
            this.tabDonHang.ImageKey = "cargo.png";
            this.tabDonHang.Location = new System.Drawing.Point(4, 38);
            this.tabDonHang.Margin = new System.Windows.Forms.Padding(10);
            this.tabDonHang.Name = "tabDonHang";
            this.tabDonHang.Size = new System.Drawing.Size(1170, 830);
            this.tabDonHang.TabIndex = 2;
            this.tabDonHang.Text = " Đơn hàng ";
            this.tabDonHang.UseVisualStyleBackColor = true;
            // 
            // tabNhanVien
            // 
            this.tabNhanVien.ImageKey = "staff.png";
            this.tabNhanVien.Location = new System.Drawing.Point(4, 38);
            this.tabNhanVien.Margin = new System.Windows.Forms.Padding(10);
            this.tabNhanVien.Name = "tabNhanVien";
            this.tabNhanVien.Size = new System.Drawing.Size(1170, 830);
            this.tabNhanVien.TabIndex = 3;
            this.tabNhanVien.Text = " Nhân viên ";
            this.tabNhanVien.UseVisualStyleBackColor = true;
            // 
            // tabTKBC
            // 
            this.tabTKBC.ImageKey = "report.png";
            this.tabTKBC.Location = new System.Drawing.Point(4, 38);
            this.tabTKBC.Margin = new System.Windows.Forms.Padding(10);
            this.tabTKBC.Name = "tabTKBC";
            this.tabTKBC.Size = new System.Drawing.Size(1170, 830);
            this.tabTKBC.TabIndex = 4;
            this.tabTKBC.Text = "Thống kê-Báo cáo";
            this.tabTKBC.UseVisualStyleBackColor = true;
            // 
            // tabHeThong
            // 
            this.tabHeThong.ImageKey = "cogwheel.png";
            this.tabHeThong.Location = new System.Drawing.Point(4, 38);
            this.tabHeThong.Name = "tabHeThong";
            this.tabHeThong.Size = new System.Drawing.Size(1170, 830);
            this.tabHeThong.TabIndex = 5;
            this.tabHeThong.Text = "Quản lý hệ thống ";
            this.tabHeThong.UseVisualStyleBackColor = true;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "groceries.png");
            this.imageList1.Images.SetKeyName(1, "rating.png");
            this.imageList1.Images.SetKeyName(2, "cargo.png");
            this.imageList1.Images.SetKeyName(3, "report.png");
            this.imageList1.Images.SetKeyName(4, "cogwheel.png");
            this.imageList1.Images.SetKeyName(5, "staff.png");
            this.imageList1.Images.SetKeyName(6, "exit.png");
            // 
            // btnDangXuat
            // 
            this.btnDangXuat.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDangXuat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDangXuat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDangXuat.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDangXuat.ImageKey = "exit.png";
            this.btnDangXuat.ImageList = this.imageList1;
            this.btnDangXuat.Location = new System.Drawing.Point(1013, 13);
            this.btnDangXuat.Name = "btnDangXuat";
            this.btnDangXuat.Size = new System.Drawing.Size(128, 41);
            this.btnDangXuat.TabIndex = 4;
            this.btnDangXuat.Text = " Đăng Xuất";
            this.btnDangXuat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDangXuat.UseVisualStyleBackColor = true;
            this.btnDangXuat.Click += new System.EventHandler(this.btnDangXuat_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.BackgroundImage = global::GUI.Properties.Resources.admin;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(41, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(50, 40);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // formQuanLy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1178, 944);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1200, 1000);
            this.Name = "formQuanLy";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cửa Hàng Dkid";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labTenQuanLy;
        private System.Windows.Forms.Button btnDangXuat;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabMatHang;
        private System.Windows.Forms.TabPage tabKhachHang;
        private System.Windows.Forms.TabPage tabDonHang;
        private System.Windows.Forms.TabPage tabNhanVien;
        private System.Windows.Forms.TabPage tabTKBC;
        private System.Windows.Forms.TabPage tabHeThong;
        private System.Windows.Forms.ImageList imageList1;
    }
}