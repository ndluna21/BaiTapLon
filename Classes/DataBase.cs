using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BaiTapLon.Classes
{
    class DataBase
    {
        //B1: Tạo kết nối
        string connectString = "Data Source=DUCLUAN;Initial Catalog=BTL_LTTQ;Integrated Security=True";
        SqlConnection sqlConnect = null;
        void OpenConnect()
        {
            sqlConnect = new SqlConnection(connectString);
            if (sqlConnect.State != ConnectionState.Open)
            {
                sqlConnect.Open();
            }
        }
        void CloseConnect()
        {
            if (sqlConnect.State != ConnectionState.Closed)
            {
                sqlConnect.Close();
                sqlConnect.Dispose();
            }
        }
        //Phương thức thực hiện cập nhật
        public void UpdateData(string sql)
        {
            SqlCommand sqlComm = new SqlCommand();
            OpenConnect();
            sqlComm.Connection = sqlConnect;
            sqlComm.CommandText = sql;
            sqlComm.ExecuteNonQuery();
            CloseConnect();
            sqlComm.Dispose();
        }
        //Phương thức thực hiện lấy dữ liệu
        public DataTable DataReader(string sqlSelect)
        {
            DataTable dtResult = new DataTable();
            OpenConnect();
            SqlDataAdapter sqlData = new SqlDataAdapter(sqlSelect, sqlConnect);
            sqlData.Fill(dtResult);
            sqlData.Dispose();
            CloseConnect();
            return dtResult;
        }
    }
}
