using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace DAL
{
    public class DonHangDAL
    {
        static string strCon = Properties.Settings.Default.strCon;
        static string soHDCu;
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

        public static string them1DonHang(DonHangDTO donhangMoi)
        {
            string query = "ADD_EDIT_DONHANG";
            string viecCanLam = "ADD";
            using (SqlConnection sqlCon = new SqlConnection(strCon))
            {
                try
                {
                    sqlCon.Open();
                    SqlCommand cmd = new SqlCommand(query, sqlCon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    setParameter(ref cmd, donhangMoi, viecCanLam);
                    int kq = cmd.ExecuteNonQuery();
                    if(kq > 0)
                    {
                        return $"Đã thêm đơn hàng mã: {donhangMoi.soHD} thành công!";
                    }
                    else
                    {
                        return "Lỗi này chưa fix <> chưa thêm đc đơn hàng!";
                    }

                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
        }

        private static void setParameter(ref SqlCommand command, DonHangDTO dh, string viecCanLam)
        {
            command.Parameters.Add("@action", SqlDbType.NVarChar, 50).Value = viecCanLam;
            command.Parameters.Add("@soHD", SqlDbType.NVarChar, 20).Value = dh.soHD;
            command.Parameters.Add("@soHDCu", SqlDbType.NVarChar, 20).Value = soHDCu;
            command.Parameters.Add("@maKH", SqlDbType.NVarChar, 20).Value = dh.maKH;
            command.Parameters.Add("@maNV", SqlDbType.NVarChar, 20).Value = dh.maNv;
            command.Parameters.Add("@ngayDat", SqlDbType.Date).Value = dh.datHang;
            command.Parameters.Add("@ngayGiao", SqlDbType.Date).Value = dh.giaoHang;
            command.Parameters.Add("@diaChiGiaoHang", SqlDbType.NVarChar, 50).Value = dh.diaChiGiaoHang;
            command.Parameters.Add("@maHTTT", SqlDbType.NVarChar, 20).Value = dh.maHTTT;
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
        public static string sua1DonHang(DonHangDTO dhMoi, DonHangDTO dhCu)
        {
            string query = "ADD_EDIT_DONHANG";
            string viecCanLam = "EDIT";
            soHDCu = dhCu.soHD;
            using (SqlConnection sqlCon = new SqlConnection(strCon))
            {
                try
                {
                    sqlCon.Open();
                    SqlCommand cmd = new SqlCommand(query, sqlCon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    setParameter(ref cmd, dhMoi, viecCanLam);
                    // Đã có connection, cmd cũng có đủ parameter - tên pro - connect -> thực thi thôi
                    int kq = cmd.ExecuteNonQuery();
                    if (kq > 0)
                    {
                        return $"Đã sửa thông tin số hóa đơn: {soHDCu} thành công!";
                    }
                    else
                        return "Lỗi này tôi chưa fix?<> chưa sửa đc đơn hàng";

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return ex.Message;
                }
            }
        }
    }

}


