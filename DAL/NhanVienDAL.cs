using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class NhanVienDAL
    {
        static string strCon = Properties.Settings.Default.strCon;

        public static NhanVienDTO dangNhapNhanVien(string tk, string mk)
        {
            NhanVienDTO kq = null;
            string query = "select * from NHANVIEN where taiKhoan = '" + tk + "' and matKhau ='" + mk + "';";
            
            using (SqlConnection sqlCon = new SqlConnection(strCon))
            {
                try
                { 
                    sqlCon.Open();

                    // Thực hiện các câu truy vấn và xử lý dữ liệu
                    SqlCommand cmd = sqlCon.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = query;
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        string ma = reader.GetString(0);
                        string hoTen = reader.GetString(1);
                        Boolean gioiTinh = reader.GetBoolean(2);
                        DateTime ngaySinh = (DateTime)reader.GetDateTime(3);
                        DateTime ngayLamViec = (DateTime)reader.GetDateTime(4);
                        string diaChi = reader.GetString(5);
                        string dienThoai = reader.GetString(6);
                        decimal luong = reader.GetDecimal(7);
                        decimal phuCap = reader.GetDecimal(8);

                        kq = new NhanVienDTO(ma,hoTen,gioiTinh,ngaySinh,ngayLamViec,diaChi,dienThoai,luong,phuCap,tk,mk);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
                return kq;
            }
        }

        public static DataTable layAllNhanVien()
        {
            string procedureName = "listALLNhanVien";

            // Khởi tạo đối tượng SqlConnection
            using (SqlConnection connection = new SqlConnection(strCon))
            {
                // Khởi tạo đối tượng SqlCommand và thiết lập tên stored procedure và kết nối
                using (SqlCommand command = new SqlCommand(procedureName, connection))
                {
                    // Thiết lập kiểu lệnh của đối tượng SqlCommand là stored procedure
                    command.CommandType = CommandType.StoredProcedure;
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


    }
}
