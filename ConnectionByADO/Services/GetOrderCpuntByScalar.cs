using ConnectionByADO.Implementations;
using Microsoft.Data.SqlClient;

namespace ConnectionByADO.Services
{

    public class GetOrderCpuntByScalar:ICountOrders
    {
        private IConfiguration _con;
        private string configurationString;
        public GetOrderCpuntByScalar(IConfiguration con)
        {
            _con = con;
            configurationString = con.GetSection("ConnectionStrings").GetSection("DBConnection").Value;
        }

        public string CountOrdersByScalar()
        {
            int cnt = 0;
            string str = "";
            string sql = "select count(*) from tblReceived";
            using (SqlConnection connection = new SqlConnection( configurationString))
            {
                using (SqlCommand command = new SqlCommand(sql,connection))
                {
                    connection.Open();
                    cnt = (int)command.ExecuteScalar();
                   
                }

            }
            str = $"Row Affected {cnt}";

            return str;
        }



    }
}
