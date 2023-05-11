using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class NhaCungCapDAL
    {
        static string strCon = Properties.Settings.Default.strCon;
        public static DataTable layAllNhaCC()
        {
            string query = "select * from NHACUNGCAP;";
            // Khởi tạo đối tượng SqlConnection
            using (SqlConnection connection = new SqlConnection(strCon))
            {
                // Khởi tạo đối tượng SqlCommand và thiết lập tên stored procedure và kết nối
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    
                    command.CommandType = CommandType.Text;
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
