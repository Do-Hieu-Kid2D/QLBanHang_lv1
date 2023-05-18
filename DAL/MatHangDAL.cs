using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;
using System.Text.RegularExpressions;
using System.Runtime.CompilerServices;

namespace DAL
{
    public class MatHangDAL
    {
        static string strCon = Properties.Settings.Default.strCon;

        public static DataTable layALLMatHang(string dk)
        {
            string query;
            if (dk == "")
            {
                query = $"select * from MATHANG;";
            }
            else
            {
                query = $"select * from MATHANG where tenHang like '%{dk}%';";
            }

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
        //MatHangDTO matHangCanThem;
        public static string them1MatHang(MatHangDTO matHang)
        {
            // Cần thêm mặt hàng này xuống!
            // Tên proceduce 
            string query = "ADD_EDIT_MATHANG";
            string viecCanLam = "ADD";
            using (SqlConnection sqlCon = new SqlConnection(strCon))
            {
                try
                {
                    sqlCon.Open();
                    SqlCommand cmd = new SqlCommand(query, sqlCon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    caiDatParameter(ref cmd, matHang, viecCanLam);
                    // Đã có connection, cmd cũng có đủ parameter - tên pro - connect -> thực thi thôi
                    int kq = cmd.ExecuteNonQuery();
                    if (kq > 0)
                    {
                        return $"Đã thêm mặt hàng: {matHang.tenHang} thành công!";
                    }
                    else
                        return "Lỗi này tôi chưa fix?<> chưa thêm đc mặt hàng";

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return ex.Message;
                }
            }

        }
        static string maHangCu = "";
        private static void caiDatParameter(ref SqlCommand cmd, MatHangDTO matHang, string viecCanLam)
        {
            cmd.Parameters.Add("@action", SqlDbType.NVarChar, 50).Value = viecCanLam;
            cmd.Parameters.Add("@maMH", SqlDbType.NVarChar, 20).Value = matHang.maHang;
            cmd.Parameters.Add("@maMHCu", SqlDbType.NVarChar, 20).Value = maHangCu;
            cmd.Parameters.Add("@ten", SqlDbType.NVarChar, 50).Value = matHang.tenHang;
            cmd.Parameters.Add("@maNCC", SqlDbType.NVarChar, 20).Value = matHang.maNCC;
            cmd.Parameters.Add("@maLH", SqlDbType.NVarChar, 20).Value = matHang.maLoaiHang;
            cmd.Parameters.Add("@sl", SqlDbType.Int).Value = matHang.soLuong;
            cmd.Parameters.Add("@dvTinh", SqlDbType.NVarChar, 50).Value = matHang.donViTinh;
            cmd.Parameters.Add("@giaNhap", SqlDbType.Money).Value = matHang.giaNhap;
            cmd.Parameters.Add("@giaBan", SqlDbType.Money).Value = matHang.giaBan;
            cmd.Parameters.Add("@hinhAnh", SqlDbType.NVarChar, 100).Value = matHang.hinhAnh;
        }

        public static int xoaMH(string maMHXoa)
        {
            string query = $"delete from MATHANG where maHang ='{maMHXoa}';";
            using (SqlConnection sqlCon = new SqlConnection(strCon))
            {
                using (SqlCommand cmd = sqlCon.CreateCommand())
                {
                    sqlCon.Open();
                    cmd.CommandText = query;
                    cmd.CommandType = CommandType.Text;
                    return cmd.ExecuteNonQuery();
                }
            }
        }
        public static string capNhat1MatHang(MatHangDTO matHang, string maHang)
        {
            string query = "ADD_EDIT_MATHANG";
            string viecCanLam = "EDIT";
            maHangCu = maHang;
            using (SqlConnection sqlCon = new SqlConnection(strCon))
            {
                try
                {
                    sqlCon.Open();
                    SqlCommand cmd = new SqlCommand(query, sqlCon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    caiDatParameter(ref cmd, matHang, viecCanLam);
                    // Đã có connection, cmd cũng có đủ parameter - tên pro - connect -> thực thi thôi
                    int kq = cmd.ExecuteNonQuery();
                    if (kq > 0)
                    {
                        return $"Đã sửa thông tin mã hàng: {maHangCu} thành công!";
                    }
                    else
                        return "Lỗi này tôi chưa fix?<> chưa sửa đc mặt hàng";

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
