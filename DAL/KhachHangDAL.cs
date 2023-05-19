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
    public class KhachHangDAL
    {
        static string strCon = Properties.Settings.Default.strCon;
        static string maKHCu = "";
        public static DataTable layALLKhachHang(string dk)
        {
            string procedureName;
            if (dk == "")
                procedureName = "listALLKhachHang";
            else
            {
                procedureName = "listALLKhachHangDk";
            }

            // Khởi tạo đối tượng SqlConnection
            using (SqlConnection connection = new SqlConnection(strCon))
            {
                // Khởi tạo đối tượng SqlCommand và thiết lập tên stored procedure và kết nối
                using (SqlCommand command = new SqlCommand(procedureName, connection))
                {
                    if (dk != "")
                    {
                        command.Parameters.Add("@dk", SqlDbType.NVarChar).Value = dk;
                    }
                    // Thiết lập kiểu lệnh của đối tượng SqlCommand là stored procedure
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    // Mở kết nối đến SQL Server
                    connection.Open();

                    DataTable dataTable = new DataTable();
                    // Thực thi lệnh SQL và lấy kết quả trả về
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        dataTable.Load(reader);
                        return dataTable;
                    }
                }
            }

        }

        public static string sua1KhachHang(KhachHangDTO khMoi, KhachHangDTO khCu)
        {
            string query = "ADD_EDIT_KHACHHANG";
            string viecCanLam = "EDIT";
            using(SqlConnection sqlCon = new SqlConnection(strCon))
            {
                try
                {
                    sqlCon.Open();
                    SqlCommand cmd = new SqlCommand(query, sqlCon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    maKHCu = khCu.maKh;
                    setParamater(ref cmd, khMoi, viecCanLam);
                    int kq = cmd.ExecuteNonQuery();
                    if (kq > 0)
                    {
                        return $"Đã chỉnh sửa khách hàng mã: {khCu.maKh} thành công!";
                    }
                    else
                    {
                        return $"Có lỗi sảy ra <> chưa sửa đc khách hàng!";
                    }
                }catch (Exception ex)
                {
                    return ex.Message;
                }
            }
        }

        public static string them1KhachHang(KhachHangDTO khCanThem)
        {
            // Thực hiện proceduce để thêm 1 khách hàng!!
            string query = "ADD_EDIT_KHACHHANG";
            string viecCanLam = "ADD";
            using (SqlConnection conn = new SqlConnection(strCon))
            {
                try
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand(query, conn);
                    command.CommandType = CommandType.StoredProcedure;
                    setParamater(ref command, khCanThem, viecCanLam);
                    // có đủ para rồi - thực thi truy vấn thôi!
                    int kq = command.ExecuteNonQuery();
                    if(kq > 0)
                    {
                        return $"Thêm khách hàng mã: {khCanThem.maKh} thành công!";
                    }
                    else
                    {
                        return $"Có lỗi sảy ra <> chưa thêm đc khách hàng!";
                    }
                }
                catch (Exception e)
                {
                    return e.Message;
                }
            }
        }

            public static int xoaKH(string maKHXoa)
            {
                string query = $"delete from KHACHHANG where maKhachHang = '{maKHXoa}';";
                using (SqlConnection connection = new SqlConnection(strCon))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.CommandType = CommandType.Text;
                        return command.ExecuteNonQuery();
                    }
                }
            }
        

        private static void setParamater(ref SqlCommand command, KhachHangDTO kh, string viecCanLam)
        {
            command.Parameters.Add("@action", SqlDbType.NVarChar, 50).Value = viecCanLam;
            command.Parameters.Add("@maKH", SqlDbType.NVarChar, 20).Value = kh.maKh;
            command.Parameters.Add("@maKHCu", SqlDbType.NVarChar, 20).Value = maKHCu;
            command.Parameters.Add("@tenKH", SqlDbType.NVarChar, 50).Value = kh.tenKH;
            command.Parameters.Add("@gioiTinh", SqlDbType.Bit).Value = kh.gioiTinh;
            command.Parameters.Add("@tenCT", SqlDbType.NVarChar, 50).Value = kh.tenCT;
            command.Parameters.Add("@diaChi", SqlDbType.NVarChar, 100).Value = kh.diaChi;
            command.Parameters.Add("@email", SqlDbType.NVarChar, 30).Value = kh.Email;
            command.Parameters.Add("@sdt", SqlDbType.NVarChar, 10).Value = kh.sdt;

        }
    }
}
