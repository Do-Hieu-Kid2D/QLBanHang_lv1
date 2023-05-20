﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Common;

namespace GUI
{
    
    public partial class fViewDonHang : Form
    {
        static string strCon = Properties.Settings.Default.strCon;
        GUI.SqlServer liBSQL = new SqlServer(strCon);
        string soDHCanView;
        public fViewDonHang(string soHD)
        {
            InitializeComponent();
            this.soDHCanView = soHD;
            this.StartPosition = FormStartPosition.CenterParent;
            labTitle.Text = $"--  CHI TIẾT ĐƠN HÀNG: {soHD.ToUpper()}  --";
        }

        private void fViewDonHang_Load(object sender, EventArgs e)
        {
            DoListALL();
        }

        private void DoListALL()
        {
            string query = "PRO_VIEW_DONHANG";
            string action = "LIST_ALL_WITH_1_DONHANG";
            SqlCommand cmd = liBSQL.GetCmd(query, action);
            setParameter(ref cmd); // thường thì sẽ truyền theo sau 1 class để vào hàm lấy giá trị ra để set
            displayData(cmd);

        }

        private void setParameter(ref SqlCommand cmd)
        {
            cmd.Parameters.Add("@soHD", SqlDbType.NVarChar, 20).Value = soDHCanView;
        }

        private void displayData(SqlCommand cmd)
        {
            dgvDataViewDonHang.DataSource = liBSQL.Query(cmd);
            Font fHeader = new Font("Tahoma", 8.5F, FontStyle.Bold, GraphicsUnit.Point);

            dgvDataViewDonHang.Columns[0].HeaderText = "Số HĐ";
            dgvDataViewDonHang.Columns[1].HeaderText = "Mã hàng";
            dgvDataViewDonHang.Columns[2].HeaderText = "Số lượng";
            dgvDataViewDonHang.Columns[3].HeaderText = "giảm giá(%)";

            dgvDataViewDonHang.RowHeadersVisible = false;
            dgvDataViewDonHang.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvDataViewDonHang.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvDataViewDonHang.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvDataViewDonHang.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvDataViewDonHang.Columns[0].HeaderCell.Style.Font = fHeader;
            dgvDataViewDonHang.Columns[1].HeaderCell.Style.Font = fHeader;
            dgvDataViewDonHang.Columns[2].HeaderCell.Style.Font = fHeader;
            dgvDataViewDonHang.Columns[3].HeaderCell.Style.Font = fHeader;

            dgvDataViewDonHang.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDataViewDonHang.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDataViewDonHang.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDataViewDonHang.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            foreach (DataGridViewColumn col in dgvDataViewDonHang.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

        }

    }
}
