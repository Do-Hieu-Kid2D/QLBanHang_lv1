﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DonHangDAL
    {
        static string strCon = Properties.Settings.Default.strCon;
        public static DataTable layALLDonHang(string dk)
        {
            if (dk == "")
            {
                string query = "select sohoadon,makhachhang,manhanvien,ngaydathang,ngayGiaoHang, mahinhThucThanhToan,diaChigiaoHang from DONDATHANG;";

                using (SqlConnection sqlCon = new SqlConnection(strCon))
                {
                    try
                    {
                        sqlCon.Open();

                        // Thực hiện các câu truy vấn và xử lý dữ liệu
                        SqlCommand cmd = sqlCon.CreateCommand();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = query;

                        SqlDataReader sdr = cmd.ExecuteReader();
                        // Tạo đối tượng DataTable để lưu trữ dữ liệu trả về
                        DataTable kq = new DataTable();
                        kq.Load(sdr); //lấy toàn bộ dữ liệu trong sdr vào dt
                        return kq;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                        return null;
                    }
                }

            }
            else
            {
                string query = "lisAllDonHangDk";

                using (SqlConnection sqlCon = new SqlConnection(strCon))
                {
                    try
                    {
                        sqlCon.Open();

                        // Thực hiện các câu truy vấn và xử lý dữ liệu
                        SqlCommand cmd = sqlCon.CreateCommand();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = query;
                        cmd.Parameters.Add("@dk", SqlDbType.NVarChar).Value = dk;

                        SqlDataReader sdr = cmd.ExecuteReader();
                        // Tạo đối tượng DataTable để lưu trữ dữ liệu trả về
                        DataTable kq = new DataTable();
                        kq.Load(sdr); //lấy toàn bộ dữ liệu trong sdr vào dt
                        return kq;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                        return null;
                    }
                }
            }
        }

        public static int xoaDH(string maDHXoa)
        {
            string query = "xoaDonHang";
            using (SqlConnection sqlCon = new SqlConnection(strCon))
            {
                sqlCon.Open();

                using (SqlCommand cmd = sqlCon.CreateCommand())
                {
                    cmd.CommandText = query;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@soHoaDon", SqlDbType.NVarChar).Value = maDHXoa;
                    return cmd.ExecuteNonQuery();
                }
            }
        }
    }

}


