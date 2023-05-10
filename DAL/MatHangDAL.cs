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
    public class MatHangDAL
    {
        static string strCon = @"Data Source=DKID\SEVERTEN;Initial Catalog=lastNha;Integrated Security=True";

        public static DataTable layALLMatHang()
        {
            string query = "select * from MATHANG;";

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

    }
}
