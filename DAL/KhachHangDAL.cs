using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class KhachHangDAL
    {
        static string strCon = Properties.Settings.Default.strCon;
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
    }
}
