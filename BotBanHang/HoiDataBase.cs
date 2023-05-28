using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//ta đang dùng .NET 6.0 (chứ ko phải .Net FrameWork xx)
//nuget GUI: cài Microsoft.Data.SqlClient vào
//using Microsoft.Data.SqlClient;

namespace BotBanHang
{
    public class HoiDataBase
    {
        public string strCon = Properties.Settings.Default.strCon;

        // Cả class này sẽ chỉ thực hiện ExecuteScalar() mk sử lý database để trả về 1 chuỗi string để mk chỉ việc hiển thị.
        public string baoMotHoaDon(string soHoaDon, string action)
        {
            // Trả về kết quả 1 hóa đơn khi biết số hóa đơn
            string kq = "";
            try
            {
                using (SqlConnection cn = new SqlConnection(strCon))
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandText = "BAO_DONHANG";
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.Parameters.Add("@soHD", SqlDbType.NVarChar, 50).Value = soHoaDon;
                        cm.Parameters.Add("@action", SqlDbType.NVarChar, 10).Value = action;
                        object obj = cm.ExecuteScalar(); //lấy col1 of row1
                        if (obj != null)
                            kq = (string)obj;
                        else
                            kq = $"không có dữ liệu về đơn hàng số có mã: {soHoaDon}";
                    }
                }
            }
            catch (Exception ex)
            {
                kq += $"Error: {ex.Message}";
            }
            return kq;
        }
    }
}
