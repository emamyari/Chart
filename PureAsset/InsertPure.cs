using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Main.PureAsset
{
    class InsertPure
    {
        public async Task Main()
        {
            SqlConnection con = new SqlConnection(@"Data Source=HANA;Initial Catalog=ParseSQL;Integrated Security=True");
            string query = "INSERT INTO TSOI (NAV, JalaliDate, PurchaseNAVPerShare ) VALUES (@NAV, @JalaliDate, @PurchaseNAVPerShare)";

            try
            {
                await con.OpenAsync();
                Connection connection = new Connection();
                List<Object> data = await connection.GetData();
                foreach (var item in data)
                {

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@NAV", item.NAV);
                    cmd.Parameters.AddWithValue("@JalaliDate", item.JalaliDate);
                    cmd.Parameters.AddWithValue("@PurchaseNAVPerShare", item.PurchaseNAVPerShare);
                    await cmd.ExecuteNonQueryAsync();
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine("ERROR" + e.ToString());

            }
            finally
            {
                con.Close();
                Console.ReadKey();
            }

            Console.WriteLine("Data inserted successfully!");
        }
    }
}
