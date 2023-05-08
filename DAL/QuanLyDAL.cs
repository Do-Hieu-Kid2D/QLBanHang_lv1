using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace DAL
{
    public class QuanLyDAL
    {
        static string strCon = @"Data Source=DKID\SEVERTEN;Initial Catalog=Cuoi;Integrated Security=True";

        public static QuanLyDTO dangNhapQuanLy(string tk, string mk)
        {
            QuanLyDTO kq = null;
            string query = "select * from Quanly where taiKhoan = '" + tk + "' and matKhau ='" + mk + "';";
            using (SqlConnection sqlCon = new SqlConnection(strCon))
            {
                try
                {
                    // Mở kết nối
                    sqlCon.Open();

                    // Thực hiện các câu truy vấn và xử lý dữ liệu
                    SqlCommand cmd = sqlCon.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = query;
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        string id = reader.GetString(0);
                        string ten = reader.GetString(3);
                        DateTime ngaySinh = (DateTime)reader.GetDateTime(4);
                        kq = new QuanLyDTO(id, tk, mk, ten, ngaySinh);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
                return kq;
            }
        }
    }
}
