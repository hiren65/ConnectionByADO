using ConnectionByADO.Implementations;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.SqlServer.Server;
using ConnectionByADO.Models;

namespace ConnectionByADO.Services
{
    public class GetServerInformation:IFetchServerInformation
    {
        public IConfiguration _configuration;
        public string ConnectionString { get; set; }
        public GetServerInformation(IConfiguration configuration)
        {
            _configuration = configuration;
            ConnectionString = _configuration.GetSection("ConnectionStrings").GetSection("DBConnection").Value;
            //ConnectionString = ConfigurationExtensions.GetConnectionString(_configuration, "DefaultConnection");
        }

        public  List<ServerData> GetInformationOfDataServer()
        {
            string str = "";
            //str = ConnectionString;
            List<ServerData> list = new List<ServerData>();
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                ServerData sd = new ServerData();
                con.Open();
                var str1 = ConnectionString +"  " ;
                var str2 = con.State + "  ";
                var str3 = con.Database + "  ";
                var str4 = con.DataSource + "  ";
                var str5 = con.ServerVersion + "  ";
                var str6 = con.WorkstationId + "  ";

                sd.ServerString = ConnectionString;
                sd.State = str1;
                sd.DataSource = str4;
                sd.ServerName = str3;
                sd.ServerId = str6;
                sd.Version = str5;
                try
                {
                    sd.ConnectionTimeOut = Convert.ToString( con.ConnectionTimeout);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                   
                }
                try
                {
                    sd.PacketSize = Convert.ToInt32(con.PacketSize);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);

                }

                list.Add(sd);
                str = str1 + str2 + str3 + str4 + str5 + str6;


            }

            return list;
        }





    }
}
